using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ssms.DAC
{
    class DataAccessXml
    {
       //public static string AllObjects = @"AllObject.xml";
        public static string SettingsPortal = @"SettingsPortal.xml";
        public static string SettingsTagReader = @"SettingsPortal.xml";
        public static string ReaderTypes = @"ReaderTypes.xml";

        public static bool ListToXml<T>(T obj, string fileName)
        {
            try
            {
                using (var fileStream = new StreamWriter(fileName))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(fileStream, obj);
                    fileStream.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<T> XmlToList<T>(string fileName)
        {
            try
            {
                using (FileStream fileStream = File.OpenRead(fileName))
                {
                    var serializer = new XmlSerializer(typeof(List<T>));
                    var dezerializedList = (List<T>)serializer.Deserialize(fileStream);
                    fileStream.Close();

                    return dezerializedList;
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool ObjectToXml<T>(T obj, string fileName)
        {
            try
            {
                using (TextWriter fileStream = new StreamWriter(fileName))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(fileStream, obj);
                    fileStream.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static T XmlToObject<T>(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    using (var fileStream = File.OpenRead(fileName))
                    {
                        var serializer = new XmlSerializer(typeof(T));
                        var objectG = (T)serializer.Deserialize(fileStream);
                        fileStream.Close();
                        return objectG;
                    }
                }
                return default(T);
            }
            catch
            {
                return default(T);
            }
        }

        public static bool FileExist(string fileName)
        {
            return File.Exists(fileName);
        }

        public static bool DeleteFile(string fileName)
        {
            try
            {
                File.Delete(fileName);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
