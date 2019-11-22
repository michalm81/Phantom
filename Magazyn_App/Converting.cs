using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Magazyn_App.ViewModel;

namespace Magazyn_App
{
    public class Converting : IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string v2 = value.ToString();
            DeliveryAndMerchVM damvm = new DeliveryAndMerchVM();

            // DeliveryAndMerchVM damvm=new DeliveryAndMerchVM();
            damvm.City = v2;
            return v2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
