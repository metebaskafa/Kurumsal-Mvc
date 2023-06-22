using Gorev7P013.Models;
using System.ComponentModel.DataAnnotations;
namespace Gorev7P013.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Adı"), StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Kategori Açıklaması")]
        public string? Description { get; set; }
        [Display(Name = "Eklenme Tarihi")]
        public DateTime? CreateDate { get; set; } = DateTime.Now; // sonradan 1 class a bu şekilde property eklersek yeni bir migration eklememiz gerekir! yoksa proje çalışırken hata alırız.
        public virtual List<Product>? Products { get; set; }
    }
}
