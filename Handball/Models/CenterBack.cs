namespace Handball.Models
{
    internal class CenterBack : Player
    {
        public CenterBack(string name, double rating) : base(name, 4)
        {
        }

        public override void DecreaseRating()
        {
            this.Rating -= 1;
        }

        public override void IncreaseRating()
        {
            this.Rating += 1;
        }
    }
}
