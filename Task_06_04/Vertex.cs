namespace Task_06_04
{
    public class Vertex
    {
        public int Number { get; set; }
        public string NameCity { get; set; }

        public Vertex(int number, string nameCity)
        {
            Number=number;
            NameCity=nameCity;
        }

        public override string ToString()
        {
            return $"{Number} - {NameCity}";
        }
    }
}
