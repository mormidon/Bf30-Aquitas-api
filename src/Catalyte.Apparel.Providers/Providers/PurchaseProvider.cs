using AutoMapper;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Providers
{
    public class PurchaseProvider : IPurchaseProvider
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly Mapper _mapper;

        public PurchaseProvider(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
            _mapper = InitializeMapper();
        }


        public async Task<ProviderResponse<PurchaseDTO>> GetPurchaseByIdAsync(int purchaseId)
        {
            var purchase = await _purchaseRepository.GetPurchaseByIdAsync(purchaseId);

            return purchase == default
                ? new ProviderResponse<PurchaseDTO>(
                    null,
                    ResponseTypes.NotFound,
                    $"Purchase with Id:{purchaseId} not found")
                : new ProviderResponse<PurchaseDTO>(
                    _mapper.Map<PurchaseDTO>(purchase),
                    ResponseTypes.Success,
                    Constants.Success);

        }

        private Mapper InitializeMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Purchase, PurchaseDTO>();
                cfg.CreateMap<Purchase, DeliveryAddress>();
            }));
        }
    }
}
