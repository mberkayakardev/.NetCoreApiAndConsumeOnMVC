using AkarSoft.Core.DataAccess.EntityFramework.Abstract;
using AkarSoft.Core.Entities.Abstract;

namespace AkarSoft.Repositories.EntityFramework.Abstract
{
    public interface IUnitOfWork
    {
        #region CostumeRepositories
        // İlgili alanda Costume Serivcelerin Abstract Versionları çağrılması gerekecketir. 
        #endregion

        /// <summary>
        /// Generic olarak Entity Bazında Repositoryler çağırmak isterseniz kullanacağınız Methodlar
        /// </summary>
        IEfGenericRepository<T> GetGenericRepositories<T>() where T: class, IEntity, new();
        
        /// <summary>
        ///  Transaction işleminin asenkronik bir şekilde işlemesi için kullanılır
        /// </summary>
        Task SaveChangesAsync();

        /// <summary>
        ///  Transaction işleminin senkron bir şekilde işlemesi için kullanılır
        /// </summary>
        void SaveChanges();

        // public TRepository ReturnRepository<T, TRepository>() where T : BaseEntity, new() where TRepository : IEfGenericRepository<T>, new();
    }
}
