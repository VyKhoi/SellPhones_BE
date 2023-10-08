﻿using SellPhones.DTO.Commons;
using SellPhones.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhones.Service.Interfaces
{
    public interface IPayment
    {
        ResponseData PaymentStripeAsync(PaymentStripeDTO dto);
    }
}
