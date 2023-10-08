using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SellPhones.Data.Interfaces;
using SellPhones.DTO.Commons;
using SellPhones.DTO.Product;
using SellPhones.Service.Interfaces;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using SellPhones.Commons;

namespace SellPhones.Service.Implementation
{
    public class PaymentService : BaseService, IPayment
    {
        public PaymentService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }

        public ResponseData PaymentStripeAsync(PaymentStripeDTO dto)
        {
            decimal amount = (decimal)dto.Amount;
            List<ProductPaymentStripeDTO> products = dto.Products;
            CustomerPaymentStripeDTO customer = dto.Customer;

            var productsPost = new List<object>();
            foreach (var item in products)
            {
                productsPost.Add(new
                {
                    name = item.Name,
                    id_branch_product_color = item.BranchProductColorId,
                    currentPrice = item.CurrentPrice
                });
            }

            try
            {
                //StripeConfiguration.ApiKey = "sk_test_51Mm6CAJTSCX72rEN0osGovCVaSKimGjDCkJjqJmA4vxPFvOav5pfxsJwuaNsm2GQOObTWTsiyY5zPog6FIrVBSgf00zDD66h8d";

                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long?)amount, // Convert to cents
                    Currency = "vnd",
                    PaymentMethodTypes = new List<string> { "card" },
                    Metadata = new Dictionary<string, string>
            {
                { "customer_name", customer.Name ?? "" },
                { "customer_phone", customer.DeliveryPhone ?? "" },
                { "customer_address", customer.DeliveryAddress ?? "" },
                { "products", JsonConvert.SerializeObject(productsPost) }
            },
                    PaymentMethodOptions = new PaymentIntentPaymentMethodOptionsOptions
                    {
                        Card = new PaymentIntentPaymentMethodOptionsCardOptions
                        {
                            RequestThreeDSecure = "automatic"
                        }
                    }
                };

                var service = new PaymentIntentService();
                var intent = service.Create(options);
                var rs = new StripePaymentTokent() { ClientSecret = intent.ClientSecret };

                return new ResponseData(rs);
            }
            catch (StripeException ex)
            {
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }
    }
}
