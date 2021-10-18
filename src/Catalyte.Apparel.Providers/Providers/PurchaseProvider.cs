﻿using System;
using AutoMapper;
using Catalyte.Aquitas.Data.Interfaces;
using Catalyte.Aquitas.Data.Model;
using Catalyte.Aquitas.DTOs.Products;
using Catalyte.Aquitas.DTOs.Purchases;
using Catalyte.Aquitas.Providers.Interfaces;
using Catalyte.Aquitas.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.Providers.Providers
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
            var purchases = await _purchaseRepository.GetPurchasesAsync(page, pageSize);

            if (purchases == default)
            {
                return new ProviderResponse<List<PurchaseDTO>>(
                    new List<PurchaseDTO>(),
                    ResponseTypes.Success,
                    Constants.Success);

            }

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

        public async Task<ProviderResponse<PurchaseDTO>> CreatePurchasesAsync(CreatePurchaseDTO model)
        {
            var newPurchase = new Purchase
            {
                OrderDate = DateTime.UtcNow,
            };
            newPurchase = _mapper.Map(model.DeliveryAddress, newPurchase);
            newPurchase = _mapper.Map(model.BillingAddress, newPurchase);

            var savedPurchase = await _purchaseRepository.CreatePurchaseAsync(newPurchase);

            return new ProviderResponse<PurchaseDTO>(
                new PurchaseDTO()
                {
                    OrderDate = savedPurchase.OrderDate,
                    Id = savedPurchase.Id,
                    DeliveryAddress = _mapper.Map<DeliveryAddressDTO>(savedPurchase),
                    BillingAddress= _mapper.Map<BillingAddressDTO>(savedPurchase)
                },
                ResponseTypes.Created,
                Constants.Success);
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
                    CreatePurchaseDTO(purchase),
                    ResponseTypes.Success,
                    Constants.Success);
        }

        private PurchaseDTO CreatePurchaseDTO(Purchase purchase)
        {
            return new PurchaseDTO()
            {
                Id = purchase.Id,
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
                cfg.CreateMap<Purchase, DeliveryAddressDTO>().ReverseMap();
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<Purchase, CreditCardDTO>();
                cfg.CreateMap<CreatePurchaseDTO, Purchase>();
                cfg.CreateMap<Purchase, BillingAddressDTO>()
                    .ForMember(dest => dest.Email,
                        opt => opt.MapFrom(src => src.BillingEmail))
                    .ForMember(dest => dest.Phone,
                        opt => opt.MapFrom(src => src.BillingPhone))
                    .ReverseMap();
                cfg.CreateMap<LineItem, LineItemDTO>();

            }));
        }
    }
}
