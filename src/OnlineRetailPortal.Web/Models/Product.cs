﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace OnlineRetailPortal.Web
{
    public class Product
    {
        public string Id { get; set; }
        public string SellerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HeroImage { get; set; }
        public Price Price { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public DateTime PostDateTime { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public List<string> Images { get; set; }
        public DateTime? PurchasedDate { get; set; }
        public Address PickupAddress { get; set; }

    }

}