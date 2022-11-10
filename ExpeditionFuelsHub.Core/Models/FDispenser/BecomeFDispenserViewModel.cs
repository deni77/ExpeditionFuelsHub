using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ExpeditionFuelsHub.Core.Models.FDispenser
{
    public class BecomeFDispenserViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 7)]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = null!;
    }
}
