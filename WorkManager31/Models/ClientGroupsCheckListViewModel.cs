using System.Collections.Generic;

namespace WorkManager31.Models
{
    public class ClientGroupsCheckListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<ClientGroup, bool> Checks { get; set; } = new Dictionary<ClientGroup, bool>();
    }
}
