using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ExpeditionFuelsHub.Core.Models.BillLading
{
    public class AddBillLadingViewModel
    {
        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Display(Name = "Gross Standart Volume")]
        [Range(0.00, 1000000.00, ErrorMessage = "Gross Standart Volume must be a positive number and less than {2}. ")]
        public decimal GrossStandartVolume { get; set; }

         [Required]
        [Range(0.00, 10000000.00, ErrorMessage = "Mass must be a positive number and less than {2}. ")]
        public decimal Mass { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }


        [Display(Name = "Distribution Chanel")]
        public int DistributionChanelId { get; set; }

        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [Display(Name = "Purpose")]
        public int PurposeId { get; set; }

        [Display(Name = "Vehicle")]
        public int VehicleId { get; set; }

        public IEnumerable<BillsDistributionChanelModel> BillsDistributions { get; set; } = new List<BillsDistributionChanelModel>();

        public IEnumerable<BillsProductModel> BillsProducts { get; set; } = new List<BillsProductModel>();

        public IEnumerable<BillsPurposeModel> BillsPurposes { get; set; } = new List<BillsPurposeModel>();

         public IEnumerable<BillsVehicleModel> BillsVehicles { get; set; } = new List<BillsVehicleModel>();
    }
}
