namespace Task_09_04
{
    public class RouteBus
    {
        public int BusId { get; }
        public int NumberRoute { get; }
        public string StartRoute { get; }
        public string EndRoute { get; }
        public TypeBus TypeBus { get; }
        public int CountBus { get; }
        public int BusBaseId { get; }

        public RouteBus(int busId, int numberRoute, string startRoute, string endRoute, TypeBus typeBus, int countBus, int busBaseId)
        {
            BusId = busId;
            NumberRoute=numberRoute;
            StartRoute=startRoute;
            EndRoute=endRoute;
            TypeBus=typeBus;
            CountBus=countBus;
            BusBaseId=busBaseId;
        }
        public string GetRouteBus() => $"{StartRoute,-18} - {EndRoute,-18}";
        public override string ToString()
        {
            return $"Bus №{BusId,-5} | Route №{NumberRoute,-7} | {StartRoute,-18} - {EndRoute,-18} | Type: {TypeBus,-10} | Count: {CountBus,-5} | Base: №{BusBaseId}";
        }
    }
}
