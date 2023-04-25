using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace P013WebSite.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Kategori Adı"), StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Kategori Açıklaması")]

        public string? Description { get; set; } // ? işareti boş olabilir olduğu için
        [Display(Name = "Eklenme Tarihi")]
        public DateTime? CreateDate { get; set; }= DateTime.Now; //sonradan 1 class a bu şekilde property eklersek yeni bir migration eklememiz gerekir! Yoksa proje çalışırken hata alırız.
        //PM> add-migration CategoryCreateDateEklendi
        //PM> update-database
        public virtual List<Product>? Products { get; set; } //1 kategorinin 1den çok ürünü olabilir(bire çok ilişki)
    }
}
