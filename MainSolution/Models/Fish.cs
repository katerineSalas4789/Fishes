namespace MainSolution.Models
{
    public class Fish : BaseClass
    {
        public int size { get; }
        public FishDirection direction { get; }
        public bool isAlive { get; set; }

        public Fish(int size, FishDirection direction) : base()
        {
            this.size = size;
            this.direction = direction;
            isAlive = true;
        }
    }
}
