using AkarSoft.Managers.Abstract;
using AkarSoft.Managers.Concrete.ComplexTypes.OptionPatternModels;
using AkarSoft.Repositories.EntityFramework.Abstract;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace AkarSoft.Managers.Concrete.Managers.Media
{
    public class CloudinaryManager : BaseManager, IMediaService
    {
        private readonly CloudinaryVerables _Cloudinaryverables;
        private readonly Cloudinary _cloudinary;
        public CloudinaryManager(IUnitOfWork unitOfWork, IMapper mapper, IOptions<CloudinaryVerables> cloudinaryverables) : base(unitOfWork, mapper)
        {
            _Cloudinaryverables = cloudinaryverables.Value;
            var account = new Account(_Cloudinaryverables.CloudName, _Cloudinaryverables.CloudinaryApiKey, _Cloudinaryverables.CloudinaryApiSecrets);
            _cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> AddMediaAsync(IFormFile file)
        {
            var uploadresult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadparams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                };

                uploadresult = await _cloudinary.UploadAsync(uploadparams);

            }

            return uploadresult;

        }

        public async Task<DeletionResult> DeleteMediaAsync(string MediaId)
        {
            var deleteParams = new DeletionParams(MediaId);
            var result = await _cloudinary.DestroyAsync(deleteParams);
            return result;
                 
        }
    }
}
