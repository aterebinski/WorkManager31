using System.Collections.Generic;

namespace WorkManager31.Models
{
    public class ClientGroupsCheckListViewModel
    {
        public Dictionary<ClientGroup, bool> Checks { get; set; } = new Dictionary<ClientGroup, bool>();
    }
}
