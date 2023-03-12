using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UB
{
    internal class DS
    {
        public static T Des<T>()
        {
            string json = File.ReadAllText("C:\\Users\\Anna\\Documents\\МПТ\\4 семестр\\ОАИП Скорогудаева\\UB\\UB\\MyJson.json", Encoding.UTF8);
            T item = JsonConvert.DeserializeObject<T>(json);
            return item;
        }

        public void Ser<T>(T item)
        {
            string json = JsonConvert.SerializeObject(item);
            File.WriteAllText("C:\\Users\\Anna\\Documents\\МПТ\\4 семестр\\ОАИП Скорогудаева\\UB\\UB\\MyJson.json", json, Encoding.UTF8);
        }
    }
}
