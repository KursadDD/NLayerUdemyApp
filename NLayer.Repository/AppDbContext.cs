using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
         
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> productFeatures { get; set; }

        //bu alanda ef core la ilgili primary key yada foreing key, karakter uzunlugu gibi ayarla yapılabilir
        //ama burası temiz kalsın diye bu ayarları configuration adında bir klasör altında açılan classlarda yapıyoruz
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //çalışmış olduğum assambly de yani katmanda confihuration dosyalarını bul ve ayarları uygula
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //product ve category için seed içeriisinde ilk tanımlama değerleri verdik
            //örnek olsun diye productfeature için de burda tanımlama yaptık ama normalde burada böyle şeyler yapılmaz
            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id=1,
                Color="Kırmızı",
                Height=100,
                Width=200,
                ProductId=1
            },
            new ProductFeature()
            {
                Id = 2,
                Color = "Mavi",
                Height = 300,
                Width = 500,
                ProductId = 2
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
