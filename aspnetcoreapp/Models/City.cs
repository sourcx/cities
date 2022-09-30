using System.ComponentModel.DataAnnotations;

namespace AspNetCoreApp.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Publish date")]
        public DateTime PublishDate { get; set; }

        public string Json { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Country { get; set; } = string.Empty;
    }
}
