using Helper;

namespace Task_05_04
{
    public class HexadecimalCounter
    {
        private string Value { get; set; }
        private string MaxValue { get; set; }
        private string MinValue { get; set; }

        public HexadecimalCounter(int value, int maxValue, int minValue)
        {
            Value=ConvertToHex(value);
            MaxValue=ConvertToHex(maxValue);
            MinValue=ConvertToHex(minValue);
        }

        public HexadecimalCounter()
        {
            Value=ConvertToHex(1000);
            MinValue=ConvertToHex(500);
            MaxValue=ConvertToHex(1500);
        }

        public static HexadecimalCounter SetValue()
        {
            while (true)
            {
                Console.WriteLine("Enter value:");
                var value = Help.ParseInt();
                Console.WriteLine("Enter min value:");
                var minValue = Help.ParseInt();
                Console.WriteLine("Enter max value:");
                var maxValue = Help.ParseInt();
                if (value > minValue && value < maxValue)
                {
                    return new HexadecimalCounter(value, maxValue, minValue);
                }
                Console.WriteLine("Value cannot be < min value and > max value");
            }
        }

        public void PrintValues()
        {
            Console.WriteLine($"Value: {Value}({ConvertFromHex(Value)}) | Min: {MinValue}({ConvertFromHex(MinValue)}) | Max: {MaxValue}({ConvertFromHex(MaxValue)})");
        }

        public void Increment()
        {
            if (ConvertFromHex(Value) < ConvertFromHex(MaxValue))
            {
                Value = ConvertToHex(ConvertFromHex(Value) + 1);
                PrintValue();
            }
            else
            {
                Console.WriteLine("Max value reached!");
            }
        }
        public void Decrement()
        {
            if (ConvertFromHex(Value) > ConvertFromHex(MinValue))
            {
                Value = ConvertToHex(ConvertFromHex(Value) - 1);
                PrintValue();
            }
            else
            {
                Console.WriteLine("Min value reached!");
            }
        }

        private void PrintValue()
        {
            Console.WriteLine($"Current value: {Value}({ConvertFromHex(Value)})");
        }
        private int ConvertFromHex(string value)
        {
            return int.Parse(value, System.Globalization.NumberStyles.HexNumber);
        }
        private string ConvertToHex(int value)
        {
            return value.ToString("X");
        }
    }
}
