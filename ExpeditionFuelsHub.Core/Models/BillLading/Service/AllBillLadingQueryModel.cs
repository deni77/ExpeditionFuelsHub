using ExpeditionFuelsHub.Views.BillLading.EnumSorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Core.Models.BillLading.Service
{
    public class AllBillLadingQueryModel
    {
        public const int BillLadingPerPage = 3;

        public string? Purpose { get; set; }

        public string? SearchTerm { get; set; }

        public BillLadingSorting Sorting { get; set; } 

        public int CurrentPage { get; set; } = 1;

        public int TotalBillLadingCount { get; set; }

        public IEnumerable<string> Purposes { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<BillLadingServiceModel> BillLadings { get; set; } = Enumerable.Empty<BillLadingServiceModel>();
    }
}
