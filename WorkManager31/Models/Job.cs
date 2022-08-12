using System;
using System.ComponentModel.DataAnnotations;

namespace WorkManager31.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClientId { get; set; }
        public int AssignmentId { get; set; }
        public bool Done { get; set; }
        public int DoneByUserId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DoneDate { get; set; }

    }
}
