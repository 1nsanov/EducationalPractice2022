namespace Task_14_04
{
    public class HexadecimalCounter
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string MaxValue { get; set; }
        public string MinValue { get; set; }

        public HexadecimalCounter(int value, int maxValue, int minValue)
        {
            Id = Guid.NewGuid().ToString();
            Value=ConvertToHex(value);
            MaxValue=ConvertToHex(maxValue);
            MinValue=ConvertToHex(minValue);
        }

        public HexadecimalCounter()
        {
            Id = Guid.NewGuid().ToString();
            Value=ConvertToHex(1000);
            MinValue=ConvertToHex(500);
            MaxValue=ConvertToHex(1500);
        }

        public static HexadecimalCounter SetValue(int value, int maxValue, int minValue)
        {
            if (value > minValue && value < maxValue) return new HexadecimalCounter(value, maxValue, minValue);
            else throw new ArgumentException("Value must be between minValue and maxValue");
        }

        public string PrintValues()
        {
            return $"Value: {Value}({ConvertFromHex(Value)}) | Min: {MinValue}({ConvertFromHex(MinValue)}) | Max: {MaxValue}({ConvertFromHex(MaxValue)})";
        }

        public string Increment()
        {
            if (ConvertFromHex(Value) < ConvertFromHex(MaxValue))
            {
                Value = ConvertToHex(ConvertFromHex(Value) + 1);
                return "Increment is successful";
            }
            else return "Max value reached!";
        }
        public string Decrement()
        {
            if (ConvertFromHex(Value) > ConvertFromHex(MinValue))
            {
                Value = ConvertToHex(ConvertFromHex(Value) - 1);
                return "Decrement is successful";
            }
            else return "Min value reached!";
        }
        public static string ConvertToHex(int value)
        {
            return value.ToString("X");
        }
        public static int ConvertFromHex(string value)
        {
            return int.Parse(value, System.Globalization.NumberStyles.HexNumber);
        }
        
    }
}
