using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace MessMgmt
{
    public class Storage
    {
        public static void WriteXml<T>(T data, string saveName)
        {
            XmlSerializer sr = new XmlSerializer(typeof(T));
            FileStream stream;
            stream = new FileStream(saveName, FileMode.Create);
            sr.Serialize(stream, data);
            stream.Close();
        }

        public static T LoadXml<T>(string fileName)
        {
            using (StreamReader stream = new StreamReader(fileName))
            {
                XmlSerializer sr = new XmlSerializer(typeof(T));
                return (T)sr.Deserialize(stream)!;
            }

        }
    }
}