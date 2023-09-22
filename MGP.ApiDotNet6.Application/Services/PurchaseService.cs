using AutoMapper;
using MGP.ApiDotNet6.Application.Dtos;
using MGP.ApiDotNet6.Application.Services.Interfaces;
using MGP.ApiDotNet6.Domain.Repositories;

namespace MGP.ApiDotNet6.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;
        public PurchaseService(IPurchaseRepository purchaseRepository, IMapper mapper)
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }

        public Task<ResultService<PurchaseDto>> CreateAsync(PurchaseDto person)
        {
            throw new NotImplementedException();
        }

        public Task<ResultService> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultService<ICollection<PurchaseDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResultService<PurchaseDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultService<PurchaseDto>> UpdateAsync(PurchaseDto person)
        {
            throw new NotImplementedException();
        }
    }
}
