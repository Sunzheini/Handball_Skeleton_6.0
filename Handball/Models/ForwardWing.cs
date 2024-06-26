namespace Handball.Models
{
    public class ForwardWing : Player
    {
        private double increaseRatingBy = 1.25;
        private double decreaseRatingBy = 0.75;

        public ForwardWing(string name) : base(name, 5.5)
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
