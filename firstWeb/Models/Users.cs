using System;

namespace FrameworkProject.Models
{
    public class Users 
    {
        private int UserID;
        private string Username;
        private string Password;
        private string Address;
        private string Email;
        private string Phone;
        private string Firstname;
        private string Lastname;
        private DateTime DateOfBirth;
        private DateTime Registrationdate;
        private DateTime UpdatedOn;
        private int Roleid;
        private int IsDeleted;
        private int IsBan;

        public Users(int userID, string username, string password, string address, string email, string phone, string firstname, string lastname, DateTime dateOfBirth, DateTime registrationdate, DateTime updatedOn, int roleid, int isDeleted, int isBan)
        {
            UserID = userID;
            Username = username;
            Password = password;
            Address = address;
            Email = email;
            Phone = phone;
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            Registrationdate = registrationdate;
            UpdatedOn = updatedOn;
            Roleid = roleid;
            IsDeleted = isDeleted;
            IsBan = isBan;
        }

        public int USERID
        {
            get { return UserID; }
            set { UserID = value; }
        }
        public string USERNAME
        {
            get { return Username; }
            set { Username = value; }
        }
        public string PASSWORD
        {
            get { return Password; }
            set { Password = value; }
        }
        public string ADDRESS
        {
            get { return Address; }
            set { Address = value; }
        }
        public string EMAIL
        {
            get { return Email; }
            set { Email = value; }
        }
        public string PHONE
        {
            get { return Phone; }
            set { Phone = value; }
        }
        public string FIRSTNAME
        {
            get { return Firstname; }
            set { Firstname = value; }
        }
        public string LASTNAME
        {
            get { return Lastname; }
            set { Lastname = value; }
        }
        public DateTime DATEOFBIRTH
        {
            get { return DateOfBirth; }
            set { DateOfBirth = value; }
        }
        public DateTime REGISTRATIONDATE
        {
            get { return Registrationdate; }
            set { Registrationdate = value; }
        }
        public DateTime UPDATEDON
        {
            get { return UpdatedOn; }
            set { UpdatedOn = value; }
        }
        public int ROLEID
        {
            get { return Roleid; }
            set { Roleid = value; }
        }
        public int ISDELETED
        {
            get { return IsDeleted; }
            set { IsDeleted = value; }
        }
        public int ISBAN
        {
            get { return IsBan; }
            set { IsBan = value; }
        }
        
        public Users()
        {
            UserID = 0;
            Username = "";
            Password = "";
            Address = "";
            Phone = "";
            Firstname = "";
            Lastname = "";
            DateOfBirth = new DateTime();
            Registrationdate = new DateTime();
            UpdatedOn = new DateTime();
            Roleid = 0;
            IsDeleted = 0;
            IsBan = 0;
        }

        public override bool Equals(object obj)
        {
            return obj is Users users &&
                   UserID == users.UserID &&
                   Username == users.Username &&
                   Password == users.Password &&
                   Address == users.Address &&
                   Email == users.Email &&
                   Phone == users.Phone &&
                   Firstname == users.Firstname &&
                   Lastname == users.Lastname &&
                   DateOfBirth == users.DateOfBirth &&
                   Registrationdate == users.Registrationdate &&
                   UpdatedOn == users.UpdatedOn &&
                   Roleid == users.Roleid &&
                   IsDeleted == users.IsDeleted &&
                   IsBan == users.IsBan;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(UserID);
            hash.Add(Username);
            hash.Add(Password);
            hash.Add(Address);
            hash.Add(Email);
            hash.Add(Phone);
            hash.Add(Firstname);
            hash.Add(Lastname);
            hash.Add(DateOfBirth);
            hash.Add(Registrationdate);
            hash.Add(UpdatedOn);
            hash.Add(Roleid);
            hash.Add(IsDeleted);
            hash.Add(IsBan);
            return hash.ToHashCode();
        }
    }
}
