using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ModuleOrmGenerator.Class
{
    public class JsonMethod<T>
    {

        public static List<T> ReadData(string dataString)
        {
            return JsonConvert.DeserializeObject<List<T>>(dataString);
        }

        public static string AddData(List<T> objs, Formatting format = Formatting.Indented)
        {
            return JsonConvert.SerializeObject(objs, format);
        }

        public static List<T> ReadAllDataJson(string path)
        {
            try
            {

                List<T> Saves = new List<T>();

                using (StreamReader sr = new StreamReader(path))
                {
                    Saves = JsonMethod<T>.ReadData(sr.ReadToEnd());
                }

                return Saves;
            }
            catch
            {
                return new List<T>();
            }
        }

        public static void WriteDataJson(string path, string dataString)
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(path))
                {
                    sw.Flush();
                    sw.WriteLine(dataString);
                }
            }
            catch
            {

            }
        }
    }
}
