using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkManager31.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Del { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
        public ICollection<ClientGroupElement> clientGroupElements { get; set; }

    }
}
