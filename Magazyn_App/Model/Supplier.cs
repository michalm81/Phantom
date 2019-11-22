using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn_App.Model
{
    public class Supplier
    {
        public string supplier_name { get; set; }
        public string nip_number { get; set; }
        public string city_name { get; set; }
        public string street_name { get; set; }
        public Guid supplier_guid { get; set; }
    }
}
