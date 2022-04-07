using System.Collections;
using System.Text;

namespace Task_07_04
{
    public class HashTableCalls
    {
        private Hashtable? TableInfoCalls { get; set; }
        private List<InfoCall> ListInfo { get; set; }
        private static Random rnd = new Random();
        private static readonly string[] CitiesNames = new string[] { "356 - Москва", "234 - Кишинев", "163 - Тирасполь", "764 - Киев" };
        private static readonly string[] PhoneCities = new string[] { "73543", "32423", "12355", "95643" };
        public HashTableCalls()
        {
            TableInfoCalls = new Hashtable();
            ListInfo = new List<InfoCall>();
            GenerateListInfo();
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
        
        public void GenerateHashtable()
        {
            var listKeys = GetKeys();
            for (int i = 0; i < listKeys.Count; i++)
            {
                var time = ListInfo.Where(item => listKeys[i] == item.GetKey()).Sum(x => x.GetValue()[0]);
                var price = ListInfo.Where(item => listKeys[i] == item.GetKey()).Sum(x => x.GetValue()[1]);
                TableInfoCalls.Add(listKeys[i], $"Total time: {time, 6} min | Total price: {price} RUB");
            }
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
                1 => Tariff.Standart,
                2 => Tariff.Express,
                3 => Tariff.SuperExpress,
                _ => Tariff.Standart,
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
