using BestEnglish.Services.Extensions.Logger;
using Microsoft.Extensions.DependencyInjection;
using SellPhones.Service.Implementation;
using SellPhones.Service.Interfaces;

namespace SellPhones.Services.DI
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServiceCollection(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();

            //---------------------------------Account ----------------------------------------------------------
            services.AddScoped<IAccountService, AccountService>();

            //---------------------------------Branch Product Color ---------------------------------------------
            services.AddScoped<IBranchProductColorService, BranchProductColorService>();

            //---------------------------------Branch Promotion Product -----------------------------------------
            services.AddScoped<IBranchPromotionProductService, BranchPromotionProductService>();

            //---------------------------------Branch ----------------------------------------------------------
            services.AddScoped<IBranchService, BranchService>();

            //---------------------------------Color -----------------------------------------------------------
            services.AddScoped<IColorService, ColorService>();

            //---------------------------------Vocabulary Service-----------------------------------------------
            services.AddScoped<ICommentService, CommentService>();

            //---------------------------------Earphone---------------------------------------------------------
            services.AddScoped<IEarphoneService, EarphoneService>();

            //---------------------------------ImageProduct-----------------------------------------------------
            services.AddScoped<IImageProductService, ImageProductService>();

            //---------------------------------Laptop-----------------------------------------------------------
            services.AddScoped<ILaptopService, LaptopService>();

            //---------------------------------Manufacture------------------------------------------------------
            services.AddScoped<IManufactureService, ManufactureService>();

            //---------------------------------OrderDetail------------------------------------------------------
            services.AddScoped<IOrderDetailService, OrderDetailService>();

            //---------------------------------Order------------------------------------------------------------
            services.AddScoped<IOrderService, OrderService>();

            //---------------------------------ProductColor-----------------------------------------------------
            services.AddScoped<IProductColorService, ProductColorService>();

            //---------------------------------IProduct---------------------------------------------------------
            services.AddScoped<IProductService, ProductService>();

            //---------------------------------Promotion--------------------------------------------------------
            services.AddScoped<IPromotionService, PromotionService>();

            //---------------------------------Review-----------------------------------------------------------
            services.AddScoped<IReviewService, ReviewService>();

            //---------------------------------Smartphone-------------------------------------------------------
            services.AddScoped<ISmartphoneService, SmartphoneService>();

            //
            services.AddScoped<IPayment, PaymentService>();

            return services;
        }
    }
}