using SellPhones.Data.Interfaces;
using SellPhones.Domain.Entity;
using SellPhones.Domain.Entity.Identity;
using SellPhones.DTO.Commons;
using SellPhones.DTO.Order;
using SellPhones.DTO.Product;
using SellPhones.Service.Interfaces;

namespace SellPhones.Service.Implementation
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }

        public async Task<ResponseData> AddOrderAsync(OrderRequestDTO dto)
        {
            // Lưu thông tin khách hàng
            Dictionary<int, int> amountEachProduct = dto.AmountEachProduct;
            List<ProductPaymentStripeDTO> products = dto.Products;
            CustomerPaymentStripeDTO customer = dto.Customer;
            DateTime orderDate = dto.OrderDate;
            Console.WriteLine("Thông tin khách hàng là: " + customer);
            Console.WriteLine("Số lượng: " + amountEachProduct);
            Console.WriteLine("Ngày đặt hàng là: " + orderDate);

            // Kiểm tra và tạo đối tượng Role "customer" nếu chưa tồn tại
            //var role = context.CellphoneappRoles.SingleOrDefault(r => r.NameRole == "customer");

            //var role = UnitOfWork.RoleRepository.FirstOrDefault(r => r.Name);
            //if (role == null)
            //{
            //    role = new Role { Name = "customer" };
            //    context.CellphoneappRoles.Add(role);
            //    context.SaveChanges();
            //}

            // Tạo đối tượng User với thông tin khách hàng và Role "customer"
            var user_order = new User
            {
                Name = customer.Name,
                Gender = 0,
                BirthDay = DateTime.MinValue,
                Email = string.Empty,
                UserName = string.Empty,
                PassWord = string.Empty,
                PhoneNumber = customer.DeliveryPhone,
                Hometown = customer.DeliveryAddress,               
            };
            // Lưu đối tượng User vào CSDL
            UnitOfWork.UserRepository.Add(user_order);
            UnitOfWork.SaveChanges();

            var order_user = new Order
            {
                OrderDate = orderDate,
                DeliveryAddress = customer.DeliveryAddress,
                DeliveryPhone = customer.DeliveryPhone,
                Status = "1",
                User = user_order
            };
            UnitOfWork.OrderRepository.Add(order_user);
            UnitOfWork.SaveChanges();

            // Console.WriteLine("Số lượng cửa hàng: " + products.Count);
            List<OrderDetail> List_Order_detail = new List<OrderDetail>();
            foreach (ProductPaymentStripeDTO product in products)
            {
                int id_branch_product_color = (int)product.BranchProductColorId;
                BranchProductColor branch_product_color = UnitOfWork.BranchProductColorRepository.Find(id_branch_product_color);

                OrderDetail order_detail = new OrderDetail
                {
                    Oder = order_user,
                    BrandProductColor = branch_product_color,
                    Quantity = amountEachProduct.GetValueOrDefault(id_branch_product_color),
                    UnitPrice = (int)product.CurrentPrice
                };
                List_Order_detail.Add(order_detail);
            }
            // Console.WriteLine("Số lượng chi tiết đơn hàng: " + List_Order_detail.Count);

            // lay doc nhat
            HashSet<BranchProductColor> unique_ids = new HashSet<BranchProductColor>();
            List<OrderDetail> unique_items = new List<OrderDetail>();
            foreach (OrderDetail item in List_Order_detail)
            {
                if (!unique_ids.Contains(item.BrandProductColor))
                {
                    unique_ids.Add(item.BrandProductColor);
                    unique_items.Add(item);
                }
            }

            // Lặp qua các phần tử độc nhất
            foreach (OrderDetail item in unique_items)
            {
                Console.WriteLine(item);
            }
            UnitOfWork.OrderDetailRepository.Add(unique_items);
            UnitOfWork.SaveChanges();

            Console.WriteLine("Thông tin sau khi lưu vào CSDL là: " + user_order);
            Console.WriteLine("Thông tin đơn hàng là: " + order_user);

            return new ResponseData(new { message = "Order created successfully!" });
        }
    }
}