namespace Module1Lab01CSharpSelfAssessment
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Price: {Price}";
        }
    }
}