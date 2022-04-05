using System.ComponentModel.DataAnnotations;

namespace FirstWebApplication.Models
{
    public class CatCorm
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
