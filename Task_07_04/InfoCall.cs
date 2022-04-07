namespace Task_07_04
{
    public struct InfoCall
    {
        private DateTime DateCall { get; set; }
        private string CityName { get; set; }
        private Tariff Tariff { get; set; }
        private int DurationCall { get; set; }
        private string PhoneCity { get; set; }
        private string PhoneSubscriber { get; set; }

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
            return $"{DateCall.ToString("dd.MM.yyyy")} | {CityName, -24} | Tariff: {Tariff, -14} | {DurationCall, 6} min | Price: {GetPrice(), 5} RUB | City: {PhoneCity} | Client: {PhoneSubscriber}";
        }

    }
}
