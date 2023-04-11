using Microsoft.EntityFrameworkCore;
using P013WebSite.Entities;

namespace P013WebSite.Data
{
    public class DatabaseContext :DbContext //DatabaseContext sınıfına EntityFrameworkCore paketinden gelen DbContext sınıfından kalıtım alıyoruz böylece tüm veritabanı işlemlerini yapabileceğiz
    {
        /*
         *PROJEDE ENTITY FRAMEWORK KULLANACAĞIZ BU PAKETİ PROJEYE SAĞ TIKLAYIP NUGET MENUSUNDEN BROWSE SEKMESINDEN ÖNCE SQL SERVER PAKETİNİ YÜKLÜYORUZ SQL VERİTABANI KULLANABİLMEK İÇİN
         *SQL SERVER İÇİNDE ENTITY FRAMEWORK CORE PAKETİDE BULUNMAKTADIR
         *CODE FIRST İLE CLASSLARIMIZI KULLANARAK VERİTABANI OLUŞTURMA VEYA DEĞİŞTİRME İŞLEMLERİ İÇİNDE TOOLS PAKETİNİ YÜKLÜYORUZ.
         */
        public DbSet<Category> Categories { get; set; } // EntityFrameworkCore da entity classlarımızı kullanarak veritabanı ile iş yapan nesneler db set 
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //bu metot veri tabanı ayarlarını yapılandırabildiğimiz metot
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; database=P013WebSite; trusted_connection=true");//UseSqlServer ile bu projede veritabanı olarak sql server kullanacağımızı belirttik. "" içerisindeki alana connection string yani veritabanı bilgilerini yazıyoruz
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData( //bu metot veritabanı oluştuktan sonra veritabanına kayıt eklememizi sağlıyor.
                new User //admin paneline giriş yapabilmek için en az 1 tane kullanıcı olması lazımki bu bilgilerle giriş yapabilelim
                {
                    Id=1,
                    Email="admin@P013WebSite.com",
                    IsActive=true,
                    IsAdmin=true,
                    Name="Admin",
                    Password="123"
                }
                );
            //Fluent API
            modelBuilder.Entity<Category>().HasData( //kategoriler tablosuna da aşağıdaki kayıtları ekle
                new Category
                {
                    Id=1,
                    Name="Elektronik"
                },
                 new Category
                 {
                     Id = 2,
                     Name = "Bilgisayar"
                 }
                );
            base.OnModelCreating(modelBuilder);
        }
        //Not: Buradaki yapılandırmayı da yaptıktan sonra Program.cs ye gidip orada databasecontext sınıfını programa tanımlamamız gerekiyor!
    }
}
