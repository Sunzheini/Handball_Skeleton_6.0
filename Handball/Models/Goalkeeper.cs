namespace Handball.Models
{
    internal class Goalkeeper : Player
    {
        public Goalkeeper(string name, double rating) : base(name, 2.5)
        {
        }

        public override void DecreaseRating()
        {
            this.Rating -= 1.25;
        }

        public override void IncreaseRating()
        {
            this.Rating += 0.75;
        }
    }
}
