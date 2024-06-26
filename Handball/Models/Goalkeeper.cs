namespace Handball.Models
{
    internal class Goalkeeper : Player
    {
        private double increaseRatingBy = 0.75;
        private double decreaseRatingBy = 1.25;

        public Goalkeeper(string name) : base(name, 2.5)
        { 
        }

        public override void IncreaseRating()
        {
            Rating += increaseRatingBy;
        }
        public override void DecreaseRating()
        {
            Rating -= decreaseRatingBy;
        }
    }
}
