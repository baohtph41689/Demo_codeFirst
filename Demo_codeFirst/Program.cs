
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;
using System.Transactions;

namespace EF
{   
   
    public class Program
    {
        // su dung transaction de insert products
        static void insertPro()
        {
            using var context = new AppliCationDbContext();
            //được sử dụng để bắt đầu một giao dịch (transaction) trong Entity Framework Core
            using IDbContextTransaction trans = context.Database.BeginTransaction();
            try
            {
                var categorys = new Object[]
                {
                    new Category {CategoryName = "iphone"},
                    new Category {CategoryName = "SamSung"},
                    new Category {CategoryName = "Oppo"}
                };
                context.AddRange(categorys);
                context.SaveChanges();


                var product = new Object[]
                {
                    new product {Name = "iphone 15", Price = 300m, CategoryId = 1},
                    new product {Name = "iphone 15", Price = 300m, CategoryId = 2},
                    new product {Name = "iphone 15", Price = 300m, CategoryId = 3},
                };
                context.AddRange(product);
                context.SaveChanges();
                //Điều này sẽ xác nhận (commit) các thay đổi nếu không có lỗi xảy ra.
                trans.Commit();
                Console.WriteLine("Transaction committed successfully.");
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Console.WriteLine($"Transaction rollback. Error:{ex.Message}");
            };

        }

        static void updatePro(int id,string newName , decimal newprice, int newIdCate)
        {
           using var context = new AppliCationDbContext();
            var qr = (from p in context.Products
                     where p.ProductId == id
                     select p).FirstOrDefault();

            if (qr != null)
            {
               qr.Name = newName;
               qr.Price = newprice;    
               qr.CategoryId = newIdCate;
                Console.WriteLine("cap nhap thanh cong");
                // Thực hiện cập nhật thay đổi trong DbContext lên Server
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("ko cap nhap duoc sp");
            }
        }

        static void deletePro(int id)
        {
            using var context = new AppliCationDbContext();
            var qr = (from p in context.Products
                      where p.ProductId == id
                      select p).FirstOrDefault();

            if (qr != null)
            {
                context.Remove(qr);
                Console.WriteLine("Product deleted successfully");
                // Thực hiện cập nhật thay đổi trong DbContext lên Server
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Product deletion failed");
            }
        }
        private static void Main(string[] args)
        {

            //insertPro();
            //updatePro(3, "ipad pro 20024", 3000000m, 3);
            deletePro(6);
        }
    }
}
