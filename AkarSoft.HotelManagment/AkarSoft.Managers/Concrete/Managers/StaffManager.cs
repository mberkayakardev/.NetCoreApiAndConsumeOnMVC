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
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AkarSoft.Managers.Concrete.Managers
{
    public class StaffManager : BaseManager, IStaffService
    {
        private readonly IValidator<StaffCreateDto> _StaffCreateDtoValidator;

        private readonly IMediaService _mediaService;
        public StaffManager(IUnitOfWork unitOfWork, IMapper mapper, IValidator<StaffCreateDto> staffCreateDtoValidator, IMediaService mediaService) : base(unitOfWork, mapper)
        {
            _StaffCreateDtoValidator = staffCreateDtoValidator;
            _mediaService = mediaService;
        }

        public async Task<ApiResponseDto<StaffListDto>> CreateNewPerson(StaffCreateDto dto)
        {
            var validationresult = _StaffCreateDtoValidator.Validate(dto);
            if (validationresult.IsValid)
            {
                var ImageUploadResult = new ImageUploadResult();
                if ( dto.StaffImage != null && dto.StaffImage.Length > 0 )
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
            return ApiResponseDto<StaffListDto>.FailResult(JsonConvert.SerializeObject(validationresult.GetErrors()),ApiResponseStatus.BadRequest);

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
    }
}
