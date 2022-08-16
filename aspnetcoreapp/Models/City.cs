using System.ComponentModel.DataAnnotations;

namespace aspnetcoreapp.Models
{
    public class City
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Publish date")]
        public DateTime PublishDate { get; set; }

        public string Json { get; set; } = string.Empty;
    }
}
