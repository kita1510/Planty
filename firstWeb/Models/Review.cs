using System;

namespace FrameworkProject.Models
{
    public class Review 
    {
        private int ProId;
        private int Reviewer;
        private string Content;
        private int Star;

        public Review(int proId, int reviewer, string content, int star)
        {
            ProId = proId;
            Reviewer = reviewer;
            Content = content;
            Star = star;
        }

        public int PROID
        {
            get { return ProId; }
            set { ProId = value; }
        }
        public int REVIEWER
        {
            get { return Reviewer; }
            set { Reviewer = value; }
        }
        public string CONTENT
        {
            get { return Content; }
            set { Content = value; }
        }
        public int STAR
        {
            get { return Star; }
            set { Star = value; }
        }


        public Review()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is Review review &&
                   ProId == review.ProId &&
                   Reviewer == review.Reviewer &&
                   Content == review.Content &&
                   Star == review.Star;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProId, Reviewer, Content, Star, PROID);
        }
    }
}
