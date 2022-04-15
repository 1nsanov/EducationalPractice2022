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
                Console.WriteLine("Input count of points: ");
                var count = dataSource.ParseInt();
                if (count > 1)
                {
                    for (int i = 1; i <= count; i++)
                    {
                        Console.WriteLine($"Input X of point {i}");
                        var x = dataSource.ParseInt();
                        Console.WriteLine($"Input Y of point {i}");
                        var y = dataSource.ParseInt();
                        Points?.Add(new Point(x, y));
                    }
                    break;
                }
                Console.WriteLine("Count of points must be more than 1");
            }
        }

        public void ShowPoints()
        {
            Console.WriteLine("Points of line: ");
            for (int i = 0; i < Points?.Count; i++)
            {
                Console.WriteLine($"Point {i + 1}: ({Points[i].X};{Points[i].Y})");
            }
        }

        public void GetСoefficientStraight()
        {
            var coefficient = GetLenghtStraight() / GetLengthLine();
            if (coefficient == 1) Console.WriteLine($"Линия прямая! коэф = {coefficient}");
            else Console.WriteLine($"Линия не прямая! коэф = {coefficient}");
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
