using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn_App.Model
{
    public interface ISupplier
    {
        Supplier spl { get; set; }
    }

    public interface IDelivery
    {
        Delivery dlv { get; set; }
    }

    public interface IMerch
    {
        Merch mrc { get; set; }
    }

    public class DeliveryAndMerch : IDelivery, IMerch
    {
        public Supplier spl { get; set; }
        public Delivery dlv { get; set; }
        public Merch mrc { get; set; }

        public DeliveryAndMerch()
        {
            spl = new Supplier();
            dlv = new Delivery();
            mrc = new Merch();
        }
    }
}
