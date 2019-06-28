using Cf.Libs.Core.Infrastructure.UnitOfWork;

namespace Cf.Libs.Core.Infrastructure.Service
{
    public class BaseService : IBaseService
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}