using System;

namespace FrameworkProject.Models
{
    public class Category
    {
        private int CateId;
        private string CateName;

        public Category(int cateId, string cateName)
        {
            CateId = cateId;
            CateName = cateName ?? throw new ArgumentNullException(nameof(cateName));
        }

        public int CATEID
        {
            get { return CateId; }
            set { CateId = value; }
        }
        public string CATENAME
        {
            get { return CateName; }
            set { CateName = value; }
        }
        public Category()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is Category category &&
                   CateId == category.CateId &&
                   CateName == category.CateName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CateId, CateName);
        }
    }
}
