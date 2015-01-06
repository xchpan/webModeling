using System;

namespace xpan.plantDesign.ViewModels
{
    public class PlantSummary
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public DateTime CreateDatetime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}