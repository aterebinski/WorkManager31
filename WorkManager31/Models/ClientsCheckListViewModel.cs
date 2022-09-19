using System.Collections.Generic;

namespace WorkManager31.Models
{
    public class ClientsCheckListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Client> Clients { get; set; }= new List<Client>();
        public Dictionary<int, bool> Checks { get; set; }= new Dictionary<int, bool>();
    }
}
