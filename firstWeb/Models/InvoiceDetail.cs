using System;

namespace FrameworkProject.Models
{
    public class InvoiceDetail
    {
        private int ProId;
        private int PackID;
        private int Quantity;

        public InvoiceDetail(int proId, int packID, int quantity)
        {
            ProId = proId;
            PackID = packID;
            Quantity = quantity;
        }

        public int PACKID
        {
            get { return PackID; }
            set { PackID = value; }
        }
        public int PROID
        {
            get { return ProId; }
            set { ProId = value; }
        }
        public int QUANTITY
        {
            get { return Quantity; }
            set { Quantity = value; }
        }
        public InvoiceDetail()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is InvoiceDetail detail &&
                   ProId == detail.ProId &&
                   PackID == detail.PackID &&
                   Quantity == detail.Quantity;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProId, PackID, Quantity);
        }
    }
}
