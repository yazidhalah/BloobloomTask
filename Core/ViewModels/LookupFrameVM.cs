using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class LookupFrameVM
    {
        public int LookupFrameId { get; set; }
        public string LookupFrameName { get; set; }
        public string LookupFrameDescription { get; set; }
        public int LookupFrameStock { get; set; }
        public decimal LookupFramePrice { get; set; }
    }
}
