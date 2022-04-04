namespace Task_04_04
{
    public class Point
    {
        private int X { get; set; }
        private int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}; {Y})";
        }
    }
}
