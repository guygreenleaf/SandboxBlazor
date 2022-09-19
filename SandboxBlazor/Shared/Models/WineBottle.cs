using System.ComponentModel.DataAnnotations;

namespace SandboxBlazor.Shared.Models
{
    public class WineBottle
    {
        [Required]
        public long WineBottleID { get; set; }

        public string? SKU { get; set; }
        public string? BrandName { get; set; }
        public double CostPerBottle { get; set; }    
    }
}
