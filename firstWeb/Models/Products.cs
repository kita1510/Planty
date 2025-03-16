using System;

namespace FrameworkProject.Models
{
    public class Products 
    {
        private int ProID;
        private string Name;
        private string Description;
        private string Img;
        private int Star;
        private int Quantity;
        private int CateId;
        private DateTime CreatedOn;
        private DateTime UpdatedOn;
        private int Status;
        private int IsDeleted;
        private float Price;

        public int PROID
        {
            get { return ProID; }
            set { ProID = value; }
        }
        public string NAME
        {
            get { return Name; }
            set { Name = value; }
        }
        public string IMG
        {
            get { return Img; }
            set { Img = value; }
        }
        public string DESCRIPTION
        {
            get { return Description; }
            set { Description = value; }
        }
        public int STAR
        {
            get { return Star; }
            set { Star = value; }
        }
        public int QUANTITY
        {
            get { return Quantity; }
            set { Quantity = value; }
        }
        public int CATEID
        {
            get { return CateId; }
            set { CateId = value; }
        }
        public DateTime CREATEDON
        {
            get { return CreatedOn; }
            set { CreatedOn = value; }
        }
        public DateTime UPDATEDON
        {
            get { return UpdatedOn; }
            set { UpdatedOn = value; }
        }
        public int STATUS
        {
            get { return Status; }
            set { Status = value; }
        }
        public int ISDELETED
        {
            get { return IsDeleted; }
            set { IsDeleted = value; }
        }
        public float PRICE
        {
            get { return Price; }
            set { Price = value; }
        }
        public Products(int proID, string name, string description, int star, int quantity, int cateId, DateTime createdOn, DateTime updatedOn, int status, int isDeleted, float price)
        {
            ProID = proID;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Star = star;
            Quantity = quantity;
            CateId = cateId;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;
            Status = status;
            IsDeleted = isDeleted;
            Price = price;
        }
        public Products()
        {

        }
        public override bool Equals(object obj)
        {
            return obj is Products products &&
                   ProID == products.ProID &&
                   Name == products.Name &&
                   Description == products.Description &&
                   Star == products.Star &&
                   Quantity == products.Quantity &&
                   CateId == products.CateId &&
                   CreatedOn == products.CreatedOn &&
                   UpdatedOn == products.UpdatedOn &&
                   Status == products.Status &&
                   IsDeleted == products.IsDeleted &&
                   Price == products.Price;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(ProID);
            hash.Add(Name);
            hash.Add(Description);
            hash.Add(Star);
            hash.Add(Quantity);
            hash.Add(CateId);
            hash.Add(CreatedOn);
            hash.Add(UpdatedOn);
            hash.Add(Status);
            hash.Add(IsDeleted);
            hash.Add(Price);
            return hash.ToHashCode();
        }

    }
}
