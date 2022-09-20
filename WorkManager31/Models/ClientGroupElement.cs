namespace WorkManager31.Models
{
    public class ClientGroupElement
    {
        public int Id { get; set; }
        public int ClientGroupId { get; set; } 
        public int ClientId { get; set; }
        public virtual ClientGroup ClientGroup { get; set; }
        public virtual Client Client { get; set; }

        

    }
}
