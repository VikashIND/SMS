using System.ComponentModel.DataAnnotations.Schema;
namespace SMS.Models
{
    public class ImageUploader
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
    }
}