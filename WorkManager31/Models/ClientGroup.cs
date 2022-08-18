using System.Collections;
using System.Collections.Generic;

namespace WorkManager31.Models
{
    public class ClientGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Del { get; set; }

        public ICollection<ClientGroupElement> ClientGroupElements { get; set; }
    }
}
