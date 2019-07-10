using AutoMapper;
using Cf.Libs.Core.Infrastructure.UnitOfWork;

namespace Cf.Libs.Core.Infrastructure.Service
{
    public class BaseService : IBaseService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}