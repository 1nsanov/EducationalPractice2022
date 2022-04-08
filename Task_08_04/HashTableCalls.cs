using Helper;
using Newtonsoft.Json;
using System.Collections;
using System.Text;
using System.Text.Json;

namespace Task_08_04
{
    public class HashTableCalls
    {
        private Hashtable? TableInfoCalls { get; set; }
        public List<InfoCall> ListInfo { get; set; }
        private static Random rnd = new Random();
        private static readonly string[] CitiesNames = new string[] { "356 - Moscow", "234 - Kishinev", "163 - Tiraspol", "764 - Kyiv" };
        private static readonly string[] PhoneCities = new string[] { "73543", "32423", "12355", "95643" };
        public HashTableCalls()
        {
            TableInfoCalls = new Hashtable();
            ListInfo = new List<InfoCall>();
            GenerateListInfo();
            GenerateHashtable();
        }

        public void AddRecord()
        {
            Console.WriteLine("Input code of city:");
            var code = dataSource.ParseInt();
            Console.WriteLine("Input city name:");
            var cityName = dataSource.ParseString();
            var city = $"{code} - {cityName}";
            Console.WriteLine("Input Date of call:");
            var date = dataSource.ParseDateTime();
            Console.WriteLine("Input tariff (1 - Standard; 2 - Express; 3 - SuperExpress):");
            var tariff = GetTariff();
            Console.WriteLine("Input duration of call(min):");
            var duration = dataSource.ParseInt();
            Console.WriteLine("Input phone number of city:");
            var phoneCity = dataSource.ParseString();
            Console.WriteLine("Input phone number of subscriber:");
            var phoneSubscriber = dataSource.ParseString();
            ListInfo.Add(new InfoCall(date, city, tariff, duration, phoneCity, phoneSubscriber));
            Console.WriteLine("-----Record added!-----");
            GenerateHashtable();
        }

        public void OutputHashTable()
        {
            Console.WriteLine("\nHashtable:");
            foreach (var item in TableInfoCalls.Keys)
            {
                Console.WriteLine($"{item,-24} -> {TableInfoCalls[item]}");
            }
        }
        public void OutputList()
        {
            Console.WriteLine("\nList:");
            foreach (var info in ListInfo)
            {
                Console.WriteLine(info.ToString());
            }
        }


        public void WriteToFile()
        {
            Console.WriteLine("Write to file...");
            if (ListInfo == null) { Console.WriteLine("List is empty!"); return;  }
            File.WriteAllText("ListInfo.json", JsonConvert.SerializeObject(ListInfo));
            Console.WriteLine("File ListInfo.json created!");
        }

       
        

        public bool ReadFromFile()
        {
            Console.WriteLine("Read from file...");
            try
            {
                ListInfo.Clear();
                TableInfoCalls.Clear();
                ListInfo = JsonConvert.DeserializeObject<List<InfoCall>>(File.ReadAllText("ListInfo.json"));
                Console.WriteLine("File ListInfo.json read!");
                GenerateHashtable();
                return true;
            }
            catch (Exception e) { Console.WriteLine($"File ListInfo.json not found! | Error: {e.Message}"); return false; }
        }

        private void GenerateHashtable()
        {
            TableInfoCalls = new Hashtable();
            var listKeys = GetKeys();
            for (int i = 0; i < listKeys.Count; i++)
            {
                var time = ListInfo.Where(item => listKeys[i] == item.GetKey()).Sum(x => x.GetValue()[0]);
                var price = ListInfo.Where(item => listKeys[i] == item.GetKey()).Sum(x => x.GetValue()[1]);
                TableInfoCalls.Add(listKeys[i], $"Total time: {time, 6} min | Total price: {price} RUB");
            }
        }

        private static Tariff GetTariff()
        {
            return dataSource.ParseInt() switch
            {
                1 => Tariff.Standard,
                2 => Tariff.Express,
                3 => Tariff.SuperExpress,
                _ => Tariff.Standard,
            };
        }

        private List<string> GetKeys()
        {
            var listKeys = new List<string>();
            foreach (var item in ListInfo)
            {
                var add = true;
                foreach (var key in listKeys)
                {
                    if (key == item.GetKey())
                    {
                        add = false;
                        break;
                    }
                }
                if (add)
                {
                    listKeys.Add(item.GetKey());
                }
            }

            return listKeys;
        }

        private void GenerateListInfo()
        {
            for (int i = 1; i <= 25; i++)
            {
                var city = GenerateCity();
                var dateCall = GenerateDateCall();
                var cityName = city[0];
                var tariff = GenerateTariff();
                var durationCall = GenerateDurationCall();
                var phoneCity = city[1];
                var phoneSubscriber = GeneratePhoneSubscriber(8);
                ListInfo.Add(new InfoCall(dateCall, cityName, tariff, durationCall, phoneCity, phoneSubscriber));
            }
        }

        private static DateTime GenerateDateCall()
        {
            return new DateTime(2022, rnd.Next(1, 12), rnd.Next(1, 28));
        }
        private static string[] GenerateCity()
        {
            var number = rnd.Next(0, CitiesNames.Length);
            return new string[] { CitiesNames[number], PhoneCities[number] };
        }
        private static Tariff GenerateTariff()
        {
            return rnd.Next(1, 4) switch
            {
                1 => Tariff.Standard,
                2 => Tariff.Express,
                3 => Tariff.SuperExpress,
                _ => Tariff.Standard,
            };
        }
        private static int GenerateDurationCall()
        {
            return rnd.Next(5, 30);
        }
        private static string GeneratePhoneSubscriber(int length)
        {
            if (length > 0)
            {
                var sb = new StringBuilder();
                var rnd = new Random(Guid.NewGuid().GetHashCode());
                for (int i = 0; i < length; i++)
                {
                    sb.Append(rnd.Next(0, 9).ToString());
                }
                return sb.ToString();
            }
            return string.Empty;
        }
    }
}
