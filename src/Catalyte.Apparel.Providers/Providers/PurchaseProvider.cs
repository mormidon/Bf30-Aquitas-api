using System;
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

            try
            {
                if (purchase == default)
                {

                    return new ProviderResponse<PurchaseDTO>(
                        null,
                        ResponseTypes.NotFound,
                        $"Purchase with Id:{purchaseId} not found");
                }
                else
                {
                    return new ProviderResponse<PurchaseDTO>(
                        new PurchaseDTO()
                        {
                            OrderDate = purchase.OrderDate,
                            DeliveryAddress = _mapper.Map<DeliveryAddressDTO>(purchase),
                            BillingAddress = _mapper.Map<BillingAddressDTO>(purchase)
                        },
                        ResponseTypes.Success,
                        Constants.Success);
                }
            }
            catch (Exception ex)
            {
                var t = ex;
            }

            return null;


        }

        private Mapper InitializeMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Purchase, PurchaseDTO>();
                cfg.CreateMap<Purchase, DeliveryAddressDTO>();
                cfg.CreateMap<Purchase, BillingAddressDTO>()
                    .ForMember(dest => dest.Email,
                        opt => opt.MapFrom(src => src.BillingEmail))
                    .ForMember(dest => dest.Phone,
                        opt => opt.MapFrom(src => src.BillingPhone));

            }));
        }
    }
}
