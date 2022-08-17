using System.ComponentModel.DataAnnotations;

namespace WorkManager31.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
