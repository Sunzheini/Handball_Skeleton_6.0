﻿namespace Handball.Models
{
    public class ForwardWing : Player
    {
        public ForwardWing(string name) : base(name, 5.5)
        {
        }

        public override void DecreaseRating()
        {
            this.Rating -= 0.75;
        }

        public override void IncreaseRating()
        {
            this.Rating += 1.25;
        }
    }
}
