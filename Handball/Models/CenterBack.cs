namespace Handball.Models
{
    internal class CenterBack : Player
    {
        private double increaseRatingBy = 1;
        private double decreaseRatingBy = 1;

        public CenterBack(string name) : base(name, 4)
        {
        }

        public override void DecreaseRating()
        {
            Rating -= decreaseRatingBy;
        }

        public override void IncreaseRating()
        {
            Rating += increaseRatingBy;
        }
    }
}
