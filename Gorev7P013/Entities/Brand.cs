using System.ComponentModel.DataAnnotations;

namespace Gorev7P013.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        [Display(Name = "Marka Adı"), StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Marka Logosu"), StringLength(50)]
        public string Logo { get; set; }
        [Display(Name = "Marka Açıklaması"), StringLength(50)]
        public string? Description { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        public bool IsHome { get; set; }
    }
}
