using System.ComponentModel.DataAnnotations;

namespace WorkManager31.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
