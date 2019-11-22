using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn_App.Model
{
    public class Merch
    {
        public string name { get; set; }
        public double price { get; set; }
        public int amount { get; set; }
        public string unit { get; set; }
        public Guid merch_guid { get; set; }
        public Guid supplier_guid { get; set; }

       
        public ObservableCollection<string> units = new ObservableCollection<string>();

        public Merch()
        {
            units.Add("kg");
            units.Add("l");
            units.Add("szt");
        }
    }
}
