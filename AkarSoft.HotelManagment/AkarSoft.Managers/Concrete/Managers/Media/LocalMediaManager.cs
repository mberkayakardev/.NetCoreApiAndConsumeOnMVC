using AkarSoft.Managers.Abstract;
using AkarSoft.Repositories.EntityFramework.Abstract;
using AutoMapper;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace AkarSoft.Managers.Concrete.Managers.Media
{
    // Olası bir senaryoda Cloudinary yerine Lokalden çalışabilmesi için backend hazırlanmış ve ilgili implementasyonlar yapılmıştır. 
    public class LocalMediaManager : BaseManager, IMediaService
    {
        public LocalMediaManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public Task<ImageUploadResult> AddMediaAsync(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Task<DeletionResult> DeleteMediaAsync(string MediaId)
        {
            throw new NotImplementedException();
        }
    }
}
