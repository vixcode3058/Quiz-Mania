using System.IO;
using System.Xml.Serialization;

namespace Quiz_Mania
{
    internal class MyStorag
    {


        internal static void WriteXML<T>(T Questions, string v)
        {
            FileStream stream;
            XmlSerializer xmlSer = new XmlSerializer(typeof(T));
            stream = new FileStream(v, FileMode.Create);
            xmlSer.Serialize(stream, Questions);
            stream.Close();
        }

        internal static T ReadXml<T>(string file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    return (T)xmlSerializer.Deserialize(sr);

                }
            }
            catch
            {
                return default(T);
            }
           
        }
    }
}