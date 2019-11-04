﻿using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnlineRetailPortal.Mock
{
    public static class AddProductTranslator
    {
        public static Product ToProduct(this AddProductStoreRequest request)
        {
            var product = new Product()
            {
                SellerId = request.SellerId,
                Name = request.Name,
                Description = request.Description,
                HeroImage = new Image() { Url = request.HeroImage.Url },
                Price = new Price() { Value = new Value(request.Price.Value.Amount,request.Price.Value.Currency), IsNegotiable = request.Price.IsNegotiable },
                Category = (Category)request.Category,
                Images = GetImages(request.Images),
                PurchasedDate = GetPurchasedDates(request.PurchasedDate),
                PickupAddress = GetAddress(request.PickupAddress)
            };

            return product;
        }

        private static Contracts.Address GetAddress(Address pickupAddress)
        {
            if (pickupAddress == null)
                return null;
            return new Product().PickupAddress = new Address()
            {
                Line1 = pickupAddress.Line1,
                Line2 = pickupAddress.Line2,
                City =pickupAddress.City,
                Pincode = pickupAddress.Pincode,
                State = pickupAddress.State
            };
        }

        private static DateTime? GetPurchasedDates(DateTime? purchasedDate)
        {
            if (purchasedDate == null)
                return null;
            return new Product().PurchasedDate = purchasedDate;
        }

        private static List<Contracts.Image> GetImages(List<Image> images)
        {
            if (images == null)
                return null;
            return new Product().Images = images.Select(x => new Image
            {
                Url = x.Url
            }).ToList();
        }

        public static AddProductStoreResponse ToEntityResponse(this Product product)
        {
            var entityPostResponse = new AddProductStoreResponse() {
                SellerId = product.SellerId,
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                HeroImage = new Image() { Url = product.HeroImage.Url },
                Price = new Price() { Value = new Contracts.Value(product.Price.Value.Amount, product.Price.Value.Currency), IsNegotiable = product.Price.IsNegotiable },
                Category = (Category)product.Category,
                Status = (Status)product.Status,
                PostDateTime = product.PostDateTime,
                ExpirationDate = product.ExpirationDate,
                Images = product.Images.Select(x => new Image
                {
                    Url = x.Url
                }).ToList(),
                PurchasedDate = product.PurchasedDate,
                PickupAddress = new Address()
                {
                    Line1 = product.PickupAddress.Line1,
                    Line2 = product.PickupAddress.Line2,
                    City = product.PickupAddress.City,
                    Pincode = product.PickupAddress.Pincode,
                    State = product.PickupAddress.State
                }
            };

            return entityPostResponse;
        }
    }
}
