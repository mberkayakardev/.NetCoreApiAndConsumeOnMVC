using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace AkarSoft.Managers.Abstract
{
    public interface IMediaService
    {
        Task<ImageUploadResult> AddMediaAsync(IFormFile file);
        Task<DeletionResult> DeleteMediaAsync(string MediaId);
    }
}
