using AutoMapper;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities;
using System;
using System.Collections.Generic;
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

        public async Task<ProviderResponse<List<PurchaseDTO>>> GetPurchasesAsync(int page, int pageSize)
        {
            try
            {
                var purchases = await _purchaseRepository.GetPurchases(page, pageSize);

                var purchaseDTOs = new List<PurchaseDTO>();
                purchases.ForEach(p =>
                {
                    purchaseDTOs.Add(CreatePurchaseDTO(p));
                });

                return new ProviderResponse<List<PurchaseDTO>>(
                    purchaseDTOs,
                    ResponseTypes.Success,
                    Constants.Success);
            }
            catch (Exception ex)
            {
                // Log error.
                return new ProviderResponse<List<PurchaseDTO>>(
                    null,
                    ResponseTypes.Exception,
                    ex.Message);
            }

        }


        public async Task<ProviderResponse<PurchaseDTO>> GetPurchaseByIdAsync(int purchaseId)
        {
            var purchase = await _purchaseRepository.GetPurchaseByIdAsync(purchaseId);

            try
            {
                return purchase == default
                    ? new ProviderResponse<PurchaseDTO>(
                        null,
                        ResponseTypes.NotFound,
                        $"Purchase with Id:{purchaseId} not found")
                    : new ProviderResponse<PurchaseDTO>(
                        CreatePurchaseDTO(purchase),
                        ResponseTypes.Success,
                        Constants.Success);
            }
            catch (Exception ex)
            {
                // Log error.
                return new ProviderResponse<PurchaseDTO>(
                    null,
                    ResponseTypes.Exception,
                    ex.Message);
            }

        }

        private PurchaseDTO CreatePurchaseDTO(Purchase purchase)
        {
                return new PurchaseDTO()
                {
                    OrderDate = purchase.OrderDate,
                    LineItems = _mapper.Map<List<LineItemDTO>>(purchase.LineItems),
                    DeliveryAddress = _mapper.Map<DeliveryAddressDTO>(purchase),
                    BillingAddress = _mapper.Map<BillingAddressDTO>(purchase),
                    CreditCard = _mapper.Map<CreditCardDTO>(purchase)
                };
        }

        private Mapper InitializeMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Purchase, PurchaseDTO>();
                cfg.CreateMap<Purchase, DeliveryAddressDTO>();
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<Purchase, CreditCardDTO>();
                cfg.CreateMap<Purchase, BillingAddressDTO>()
                    .ForMember(dest => dest.Email,
                        opt => opt.MapFrom(src => src.BillingEmail))
                    .ForMember(dest => dest.Phone,
                        opt => opt.MapFrom(src => src.BillingPhone));
                cfg.CreateMap<LineItem, LineItemDTO>();

            }));
        }
    }
}
