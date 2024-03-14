using AkarSoft.Core.Extentions.FluentValidation;
using AkarSoft.Core.Utilities.Result.Api;
using AkarSoft.Core.Utilities.Result.Api.ComplexTypes;
using AkarSoft.Dtos.Concrete.Staffs;
using AkarSoft.Entities.Concrete.Hotels;
using AkarSoft.Managers.Abstract;
using AkarSoft.Managers.Concrete.ConstVerables;
using AkarSoft.Repositories.EntityFramework.Abstract;
using AutoMapper;
using CloudinaryDotNet.Actions;
using FluentValidation;
using Newtonsoft.Json;

namespace AkarSoft.Managers.Concrete.Managers
{
    public class StaffManager : BaseManager, IStaffService
    {
        private readonly IValidator<StaffCreateDto> _StaffCreateDtoValidator;
        private readonly IValidator<StaffUpdateDto> _StaffUpdateDtoValidator;


        private readonly IMediaService _mediaService;
        public StaffManager(IUnitOfWork unitOfWork, IMapper mapper, IValidator<StaffCreateDto> staffCreateDtoValidator, IMediaService mediaService, IValidator<StaffUpdateDto> staffUpdateDtoValidator) : base(unitOfWork, mapper)
        {
            _StaffCreateDtoValidator = staffCreateDtoValidator;
            _StaffUpdateDtoValidator = staffUpdateDtoValidator;
            _mediaService = mediaService;

        }

        public async Task<ApiResponseDto<StaffListDto>> CreateNewPerson(StaffCreateDto dto)
        {
            var validationresult = _StaffCreateDtoValidator.Validate(dto);
            if (validationresult.IsValid)
            {
                var ImageUploadResult = new ImageUploadResult();
                if (dto.StaffImage != null && dto.StaffImage.Length > 0)
                {
                    ImageUploadResult = await _mediaService.AddMediaAsync(dto.StaffImage);
                    if (ImageUploadResult.Error != null)
                        return ApiResponseDto<StaffListDto>.FailResult(Messages.Status.MediaUploadError + ImageUploadResult.Error.Message.ToString(), ApiResponseStatus.BadRequest);
                }

                var mappingData = _mapper.Map<Staff>(dto);
                mappingData.StaffImage = ImageUploadResult.Url.OriginalString;
                var repository = _unitOfWork.GetGenericRepositories<Staff>();
                var Saveresult = await repository.CreateAsync(mappingData);
                await _unitOfWork.SaveChangesAsync();
                if (Saveresult != null)
                {
                    var createdResult = _mapper.Map<StaffListDto>(Saveresult);
                    return ApiResponseDto<StaffListDto>.SuccessResult(ApiResponseStatus.Created, createdResult);
                }
                else
                    return ApiResponseDto<StaffListDto>.FailResult(Messages.Status.NotCreated, ApiResponseStatus.BadRequest);



            }
            return ApiResponseDto<StaffListDto>.FailResult(JsonConvert.SerializeObject(validationresult.GetErrors()), ApiResponseStatus.BadRequest);

        }

        public async Task<ApiResponseDto<NoContentDto>> DeletedPersonSafe(int id)
        {
            var repository = _unitOfWork.GetGenericRepositories<Staff>();
            var model = await repository.GetAsync(x=>x.Id == id);
            if (model == null)
                return ApiResponseDto<NoContentDto>.FailResult(Messages.Status.NotFound, ApiResponseStatus.NotFound);

            await repository.SoftDeleteAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return ApiResponseDto<NoContentDto>.FailResult(Messages.CRUD.Deleted, ApiResponseStatus.NoContent);

        }

        public async Task<ApiResponseDto<List<StaffListDto>>> GetAllActivePersons()
        {
            var repository = _unitOfWork.GetGenericRepositories<Staff>();
            var result = await repository.GetAllAsync(x => x.IsActive == true);

            if (result == null || result.Count == 0)
                return ApiResponseDto<List<StaffListDto>>.FailResult(Messages.Status.NotFound, ApiResponseStatus.NotFound);

            var mappingresult = _mapper.Map<List<StaffListDto>>(result);

            return ApiResponseDto<List<StaffListDto>>.SuccessResult(ApiResponseStatus.OK, mappingresult);
        }

        public async Task<ApiResponseDto<List<StaffListDto>>> GetAllPersons()
        {
            var repository = _unitOfWork.GetGenericRepositories<Staff>();
            var result = await repository.GetAllAsync();

            if (result == null || result.Count == 0)
                return ApiResponseDto<List<StaffListDto>>.FailResult(Messages.Status.NotFound, ApiResponseStatus.NotFound);

            var mappingresult = _mapper.Map<List<StaffListDto>>(result);

            return ApiResponseDto<List<StaffListDto>>.SuccessResult(ApiResponseStatus.OK, mappingresult);

        }

        public async Task<ApiResponseDto<StaffListDto>> GetPersonsById(int id)
        {
            var repository = _unitOfWork.GetGenericRepositories<Staff>();
            var result = await repository.GetAsync(x => x.Id == id);

            if (result == null)
                return ApiResponseDto<StaffListDto>.FailResult(Messages.Status.NotFound, ApiResponseStatus.NotFound);

            var mappingresult = _mapper.Map<StaffListDto>(result);

            return ApiResponseDto<StaffListDto>.SuccessResult(ApiResponseStatus.OK, mappingresult);
        }

        public async Task<ApiResponseDto<NoContentDto>> UpdatePersonDto(StaffUpdateDto dto)
        {
            var validationresult = _StaffUpdateDtoValidator.Validate(dto);
            if (validationresult.IsValid)
            {
                var repository = _unitOfWork.GetGenericRepositories<Staff>();

                var oldpersondatas = await repository.GetAsync(x => x.Id == dto.Id);
                var ImageUploadResult = new ImageUploadResult();


                if (dto.StaffNewImage.Length > 0)
                {
                    var ImageRemoveResult = await _mediaService.DeleteMediaAsync(Path.GetFileNameWithoutExtension(oldpersondatas.StaffImage));
                    if (ImageRemoveResult.Error != null)
                        return ApiResponseDto<NoContentDto>.FailResult(Messages.Status.MediaUploadError + ImageRemoveResult.Error.Message.ToString(), ApiResponseStatus.BadRequest);

                    ImageUploadResult = await _mediaService.AddMediaAsync(dto.StaffNewImage);

                    if (ImageUploadResult.Error != null)
                        return ApiResponseDto<NoContentDto>.FailResult(Messages.Status.MediaUploadError + ImageUploadResult.Error.Message.ToString(), ApiResponseStatus.BadRequest);
                }


                oldpersondatas.StaffImage = (dto.StaffNewImage.Length > 0 ? ImageUploadResult.Uri.OriginalString : dto.StaffCurrentImage);
                oldpersondatas.Title = dto.Title;
                oldpersondatas.Name = dto.Name;
                oldpersondatas.IsActive = dto.IsActive;

                await repository.UpdateAsync(oldpersondatas);
                await _unitOfWork.SaveChangesAsync();
                
                return ApiResponseDto<NoContentDto>.SuccessResult(ApiResponseStatus.NoContent);

            }
            return ApiResponseDto<NoContentDto>.FailResult(JsonConvert.SerializeObject(validationresult.GetErrors()), ApiResponseStatus.BadRequest);

        }
    }
}
