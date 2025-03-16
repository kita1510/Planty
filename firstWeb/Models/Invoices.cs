using System;

namespace FrameworkProject.Models
{
    public class Invoices 
    {
        private int PackID;
        private int IsPaid;
        private DateTime CreatedOn;
        private DateTime PaidOn;
        private float TotalPrice;
        private int UserID;

        public int PACKID
        {
            get { return PackID; }
            set { PackID = value; }
        }
        public int USERID
        {
            get { return UserID; }
            set { UserID = value; }
        }
        public int ISPAID
        {
            get { return IsPaid; }
            set { IsPaid = value; }
        }
        public DateTime CREATEDON
        {
            get { return CreatedOn; }
            set { CreatedOn = value; }
        }
        public DateTime PAIDON
        {
            get { return PaidOn; }
            set { PaidOn = value; }
        }
        public float TOTALPRICE
        {
            get { return TotalPrice; }
            set { TotalPrice = value; }
        }

        public Invoices(int packID, int isPaid, DateTime createdOn, DateTime paidOn, float totalPrice, int userid)
        {
            PackID = packID;
            IsPaid = isPaid;
            CreatedOn = createdOn;
            PaidOn = paidOn;
            TotalPrice = totalPrice;
            UserID = userid;
        }

        public Invoices()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is Invoices invoices &&
                   PackID == invoices.PackID &&
                   IsPaid == invoices.IsPaid &&
                   CreatedOn == invoices.CreatedOn &&
                   PaidOn == invoices.PaidOn &&
                   TotalPrice == invoices.TotalPrice &&
                   UserID == invoices.UserID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PackID, IsPaid, CreatedOn, PaidOn, TotalPrice, UserID);
        }
    }
}
