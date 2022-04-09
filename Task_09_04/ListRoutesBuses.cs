using Helper;
using Newtonsoft.Json;

namespace Task_09_04
{
    public class ListRoutesBuses
    {
        private List<RouteBus> ListRouteBus { get; set; }
        private static Random rnd = new Random();
        private static string[] arrayStartCities = new string[] { "Москва", "Санкт-Петербург", "Новосибирск", "Екатеринбург", "Нижний Новгород", "Казань", "Челябинск", "Омск", "Ростов-на-Дону", "Уфа", "Красноярск",};
        private static string[] arrayEndCities = new string[] { "Иркутск", "Владивосток", "Ярославль", "Хабаровск", "Махачкала", "Томск", "Оренбург", "Астрахань", "Волгоград", "Саратов", "Калининград", "Смоленск"};
        public ListRoutesBuses()
        {
            ListRouteBus = new List<RouteBus>();
            GenerateListRouteBus();
        }
        public void OutputRoutesBuses()
        {
            ListRouteBus.ForEach(item => Console.WriteLine(item));
        }

        public void GetCountUrabanBus()
        {
            Console.WriteLine($"Count urban buses: {ListRouteBus.Where(item => item.TypeBus == TypeBus.Urban).Sum(item => item.CountBus)}");
        }
        public void GetRouteById()
        {
            OutputRoutesBuses();
            Console.WriteLine("\nEnter id bus:");
            var busId = dataSource.ParseInt();
            var routeBus = ListRouteBus.Where(item => item.BusId == busId).FirstOrDefault();
            if (routeBus != null) Console.WriteLine($"Route bus: {routeBus.GetRouteBus()}");
            else Console.WriteLine("Bus not found");
        }
        public void GetBusesIdByCity()
        {
            OutputRoutesBuses();
            Console.WriteLine("\nEnter city:");
            var city = dataSource.ParseString();
            var listBusesId = ListRouteBus.Where(item => item.StartRoute == city || item.EndRoute == city).Select(item => item.BusId).ToList();
            if (listBusesId.Count > 0)
            {
                Console.WriteLine("Buses:");
                listBusesId.ForEach(item => Console.WriteLine(item));
            }
            else Console.WriteLine("Buses not found");
        }
       
        public void GetRoutesByBusBaseId()
        {
            OutputRoutesBuses();
            Console.WriteLine("\nEnter bus base id:");
            var id = dataSource.ParseInt();
            var listRoutes = ListRouteBus.Where(item => item.BusBaseId == id).Select(item => item.GetRouteBus()).ToList();
            if (listRoutes.Count > 0)
            {
                Console.WriteLine("Routes:");
                listRoutes.ForEach(item => Console.WriteLine(item));
            }
            else Console.WriteLine("Routes not found");
        }

        public void WriteToFile()
        {
            Console.WriteLine("Write to file...");
            if (ListRouteBus == null) { Console.WriteLine("List route bus is empty"); return; }
            var json = JsonConvert.SerializeObject(ListRouteBus);
            using var file = new BinaryWriter(File.Open("bus.dat", FileMode.Create));
            file.Write(json);
            Console.WriteLine("File bus.bat created!");
        }
        public void ReadFromFile()
        {
            Console.WriteLine("Read from file...");
            try
            {
                using var file = new BinaryReader(File.Open("bus.dat", FileMode.Open));
                var json = file.ReadString();
                ListRouteBus = JsonConvert.DeserializeObject<List<RouteBus>>(json);
                Console.WriteLine("File bus.bat read!");
            }
            catch (Exception e) { Console.WriteLine($"File bus.dat not found | Error: {e.Message}"); }
        }

        private void GenerateListRouteBus()
        {
            for (int i = 1; i <= 10; i++)
            {
                var busId = rnd.Next(100, 999);
                var numberRoute = i;
                var startRoute = arrayStartCities[rnd.Next(0, arrayStartCities.Length)];
                var endRoute = arrayEndCities[rnd.Next(0, arrayStartCities.Length)];
                var typeBus = GetRandomTypeBus();
                var countBus = rnd.Next(1, 15);
                var numberBusBase = rnd.Next(10, 99);
                ListRouteBus.Add(new RouteBus(busId, numberRoute, startRoute, endRoute, typeBus, countBus, numberBusBase));
            }
        }

        private static TypeBus GetRandomTypeBus()
        {
            return (TypeBus)rnd.Next(1, 4);
        }
    }
}
