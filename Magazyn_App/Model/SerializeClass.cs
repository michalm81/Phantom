using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Magazyn_App.Model
{
    public static class SerializeClass
    {
        public static void SerializeObject<T>(T obj, string path)
        {

            XmlSerializer damxs = new XmlSerializer(typeof(T));
            using (StreamWriter damwr = new StreamWriter(path))
            {
                damxs.Serialize(damwr, obj);
            }

        }
        
        public static T DeserializeObject<T>( string path)
        {
            XmlSerializer xl = new XmlSerializer(typeof(T));
            using (StreamReader rxl = new StreamReader(path))
            {
                return (T)xl.Deserialize(rxl);
            }
        }
    }
}