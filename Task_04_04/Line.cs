using Helper;

namespace Task_04_04
{
    public class Line
    {
        private List<Point>? Points { get; set; } = new();

        public void SetPoints()
        {
            while (true)
            {
                Console.WriteLine("Введите кол-во точек:");
                var count = Help.ParseInt();
                if (count > 1)
                {
                    for (int i = 1; i <= count; i++)
                    {
                        Console.WriteLine($"Введите X координату точки {i}");
                        var x = Help.ParseInt();
                        Console.WriteLine($"Введите Y координату точки {i}");
                        var y = Help.ParseInt();
                        Points?.Add(new Point(x, y));
                    }
                    break;
                }
                Console.WriteLine("Для построении линии необходимо не менее двух точек.");
            }
        }

        public void ShowPoints()
        {
            Console.WriteLine("Точки линии:");
            for (int i = 0; i < Points?.Count; i++)
            {
                Console.WriteLine($"Точка {i + 1}: ({Points[i].X};{Points[i].Y})");
            }
        }

        public void GetСoefficientStraight()
        {
            var coefficient = GetLenghtStraight() / GetLengthLine();
            Console.WriteLine($"Коэфф. прямой = {coefficient}");
        }

        private double GetLenghtStraight()
        {
            return GetLengthVector(Points[0], Points[Points.Count - 1]);
        }

        private double GetLengthLine()
        {
            var lengthLine = 0.0;
            for (int i = 0; i < Points.Count - 1; i++)
            {
                lengthLine += GetLengthVector(Points[i], Points[i + 1]);
            }
            return lengthLine;
        }
        private double GetLengthVector(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
        }
    }
}
