using System;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace LigaPaulista.Core.SDK.Utils
{
    public class Serializer
    {
        public string ToStringSerializer(object o)
        {
            if (o == null) return "<NULL />";
            string str;
            Encoding utf8 = new UTF8Encoding();
            XmlTypeAttribute xmlatt = (XmlTypeAttribute)Attribute.GetCustomAttribute(o.GetType(), typeof(XmlTypeAttribute));
            using (MemoryStream ms = new MemoryStream())
            {
                XmlTextWriter x = new XmlTextWriter(ms, utf8); x.Formatting = Formatting.Indented;
                XmlSerializer xs = xmlatt == null ? new XmlSerializer(o.GetType()) : new XmlSerializer(o.GetType(), xmlatt.Namespace);
                xs.Serialize(x, o);
                str = utf8.GetString(ms.GetBuffer(), 0, (int)ms.Length);
                x.Close();
                ms.Close();
            }
            return str;
        }
    }
}
