﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhones.DTO.Product
{
    public class ProductDTOPaymentStripeDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? NameManufacture { get; set; }
        public int? BranchProductColorId { get; set; }
        public decimal? CurrentPrice { get; set; }
    }

    public class CustomerPaymentStripeDTO
    {
        public string? Name { get; set; }
        public string? DeliveryPhone { get; set; }
        public string? DeliveryAddress { get; set; }
    }

    public class PaymentStripeDTO
    {
        public decimal? Amount { get; set; }
        public List<ProductDTOPaymentStripeDTO>? Products { get; set; }
        public CustomerPaymentStripeDTO? Customer { get; set; }

    }

    public class StripePaymentTokent
    {
        public string? ClientSecret { get; set; }

    }
}