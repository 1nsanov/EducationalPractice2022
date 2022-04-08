
namespace Task_08_04
{
    public struct InfoCall
    {
        public DateTime DateCall { get; }
        public string CityName { get; }
        public Tariff Tariff { get; }
        public int DurationCall { get; }
        public string PhoneCity { get; }
        public string PhoneSubscriber { get; }

        public InfoCall(DateTime dateCall, string cityName, Tariff tariff, int durationCall, string phoneCity, string phoneSubscriber)
        {
            DateCall=dateCall;
            CityName=cityName;
            Tariff=tariff;
            DurationCall=durationCall;
            PhoneCity=phoneCity;
            PhoneSubscriber=phoneSubscriber;
        }

        public string GetKey()
        {
            return CityName;
        }
        public int[] GetValue()
        {
            return new int[] { DurationCall, GetPrice() };
        }

        private int GetPrice()
        {
            return Tariff switch
            {
                Tariff.Standard => DurationCall * 2,
                Tariff.Express => DurationCall * 3,
                Tariff.SuperExpress => DurationCall * 4,
                _ => 0,
            };
        }
        public override string ToString()
        {
            return $"{DateCall.ToString("dd.MM.yyyy")} | {CityName,-24} | Tariff: {Tariff,-14} | {DurationCall,6} min | Price: {GetPrice(),5} RUB | City: {PhoneCity} | Client: {PhoneSubscriber}";
        }

    }
}
