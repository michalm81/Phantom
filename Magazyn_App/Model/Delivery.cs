using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn_App.Model
{
    public class Delivery
    {
        public string delivery_number { get; set; }
        public DateTime date { get; set; }
        public bool realised { get; set; }
        public Guid delivery_guid { get; set; }
        public Guid supplier_guid { get; set; }
       
    }
}
