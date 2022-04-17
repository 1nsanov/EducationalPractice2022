namespace Task_06_04
{
    public class Vertex
    {
        public int Number { get; set; }
        public Vertex(int number)
        {
            Number = number;
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
