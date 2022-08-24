using System.Collections.Generic;

namespace WorkManager31.Models
{
    public class ClientsCheckListViewModel
    {
        public List<Client> Clients { get; set; }= new List<Client>();
        public Dictionary<Client, bool> Checks { get; set; }= new Dictionary<Client, bool>();
    }
}
