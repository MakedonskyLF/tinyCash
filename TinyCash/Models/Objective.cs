namespace TinyCash.Models
{
    public class Objective
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int ExpectedCost { get; set; }
    }
}