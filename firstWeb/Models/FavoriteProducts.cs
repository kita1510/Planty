using System;

namespace FrameworkProject.Models
{
    public class FavoriteProducts
    {
        private int UserID;
        private int ProductID;
        private DateTime AddOn;

        public FavoriteProducts(int userID, int productID, DateTime addOn)
        {
            UserID = userID;
            ProductID = productID;
            AddOn = addOn;
        }

        public int USERID
        {
            get { return UserID; }
            set { UserID = value; }
        }
        public int PRODUCTID
        {
            get { return ProductID; }
            set { ProductID = value; }
        }
        public DateTime ADDON
        {
            get { return AddOn; }
            set { AddOn = value; }
        }
        public FavoriteProducts()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is FavoriteProducts products &&
                   UserID == products.UserID &&
                   ProductID == products.ProductID &&
                   AddOn == products.AddOn;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UserID, ProductID, AddOn);
        }
    }
}
