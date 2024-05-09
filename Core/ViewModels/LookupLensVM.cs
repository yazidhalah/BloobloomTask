

using Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.ViewModels
{
    public class LookupLensVM
    {
        public int LookupLensId { get; set; }
        public string LookupLensColor { get; set; }
        public string LookupLensDescription { get; set; }
        public int LookupLensStock { get; set; }
        public decimal LookupLensPrice { get; set; }


        public int LookupPrescriptionTypeId { get; set; }
        public int LookupLensTypeId { get; set; }

    }
}
