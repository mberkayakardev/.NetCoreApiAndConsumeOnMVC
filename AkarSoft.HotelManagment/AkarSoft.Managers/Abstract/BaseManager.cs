using AkarSoft.Repositories.EntityFramework.Abstract;
using AutoMapper;

namespace AkarSoft.Managers.Abstract
{
    public abstract class BaseManager
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;

        protected BaseManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
    }
}
