using System.Collections.Generic;

namespace WorkManager31.Models
{
    public class ClientGroupsCheckListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ClientGroup> clientGroups { get; set; } = new List<ClientGroup>();
        public Dictionary<int, bool> Checks { get; set; } = new Dictionary<int, bool>();
    }
}
