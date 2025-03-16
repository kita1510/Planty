using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FrameworkProject.Models;
using System.Globalization;

namespace firstWeb.Models
{
    public class StoreContext
    {
        public string ConnectionString { get; set; }

        public StoreContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection() 
        {
            return new MySqlConnection(ConnectionString);
        }
        // Liet ke tat ca product
        public List<Products> GetProducts()
        {
            List<Products> list = new List<Products>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from Products where IsDeleted = 0";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CultureInfo culture = new CultureInfo("en-US");
                        DateTime day = Convert.ToDateTime("7/10/2002 12:10:15 PM", culture);
                        Products p = new Products();
                        p.PROID = Int32.Parse(reader["ProductID"].ToString());
                        p.NAME = reader["Name"].ToString();
                        p.DESCRIPTION = reader["Description"].ToString();
                        p.STAR = Int32.Parse(reader["StarNumber"].ToString());
                        p.QUANTITY = Int32.Parse(reader["Quantity"].ToString());
                        p.CATEID = Int32.Parse(reader["CateId"].ToString());
                        p.CREATEDON = Convert.ToDateTime(reader["CreatedOn"].ToString(), culture);
                        p.STATUS = Int32.Parse(reader["Status"].ToString());
                        p.PRICE = float.Parse(reader["Price"].ToString()); 
                        p.IMG = reader["Img"].ToString();
                        list.Add(p);
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        // Get newest
        public List<Products> GetNewest()
        {
            List<Products> list = new List<Products>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from products WHERE IsDeleted = false ORDER by CreatedOn desc";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CultureInfo culture = new CultureInfo("en-US");
                        DateTime day = Convert.ToDateTime("7/10/2002 12:10:15 PM", culture);
                        Products p = new Products();
                        p.PROID = Int32.Parse(reader["ProductID"].ToString());
                        p.NAME = reader["Name"].ToString();
                        p.DESCRIPTION = reader["Description"].ToString();
                        p.STAR = Int32.Parse(reader["StarNumber"].ToString());
                        p.QUANTITY = Int32.Parse(reader["Quantity"].ToString());
                        p.CATEID = Int32.Parse(reader["CateId"].ToString());
                        p.CREATEDON = Convert.ToDateTime(reader["CreatedOn"].ToString(), culture);
                        p.STATUS = Int32.Parse(reader["Status"].ToString());
                        p.PRICE = float.Parse(reader["Price"].ToString());
                        p.IMG = reader["Img"].ToString();
                        list.Add(p);
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        // Get Price Desc
        public List<Products> GetPriceDesc()
        {
            List<Products> list = new List<Products>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from products WHERE IsDeleted = false ORDER by Price desc;";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CultureInfo culture = new CultureInfo("en-US");
                        DateTime day = Convert.ToDateTime("7/10/2002 12:10:15 PM", culture);
                        Products p = new Products();
                        p.PROID = Int32.Parse(reader["ProductID"].ToString());
                        p.NAME = reader["Name"].ToString();
                        p.DESCRIPTION = reader["Description"].ToString();
                        p.STAR = Int32.Parse(reader["StarNumber"].ToString());
                        p.QUANTITY = Int32.Parse(reader["Quantity"].ToString());
                        p.CATEID = Int32.Parse(reader["CateId"].ToString());
                        p.CREATEDON = Convert.ToDateTime(reader["CreatedOn"].ToString(), culture);
                        p.STATUS = Int32.Parse(reader["Status"].ToString());
                        p.PRICE = float.Parse(reader["Price"].ToString());
                        p.IMG = reader["Img"].ToString();
                        list.Add(p);
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        //Get Price Asc
        public List<Products> GetPriceAsc()
        {
            List<Products> list = new List<Products>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from products WHERE IsDeleted = false ORDER by Price asc;";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CultureInfo culture = new CultureInfo("en-US");
                        DateTime day = Convert.ToDateTime("7/10/2002 12:10:15 PM", culture);
                        Products p = new Products();
                        p.PROID = Int32.Parse(reader["ProductID"].ToString());
                        p.NAME = reader["Name"].ToString();
                        p.DESCRIPTION = reader["Description"].ToString();
                        p.STAR = Int32.Parse(reader["StarNumber"].ToString());
                        p.QUANTITY = Int32.Parse(reader["Quantity"].ToString());
                        p.CATEID = Int32.Parse(reader["CateId"].ToString());
                        p.CREATEDON = Convert.ToDateTime(reader["CreatedOn"].ToString(), culture);
                        p.STATUS = Int32.Parse(reader["Status"].ToString());
                        p.PRICE = float.Parse(reader["Price"].ToString());
                        p.IMG = reader["Img"].ToString();
                        list.Add(p);
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        // Liet ke product yeu thich
        public List<Products> GetFavoriteProducts(int userID)
        {
            List<Products> list = new List<Products>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from favoriteproduct f, products p where p.ProductID =" +
                    " f.ProductID and f.UserID = @userid and p.IsDeleted = 0";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("userid", userID);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CultureInfo culture = new CultureInfo("en-US");
                        DateTime day = Convert.ToDateTime("7/10/2002 12:10:15 PM", culture);
                        Products p = new Products();
                        p.PROID = Int32.Parse(reader["ProductID"].ToString());
                        p.NAME = reader["Name"].ToString();
                        p.DESCRIPTION = reader["Description"].ToString();
                        p.STAR = Int32.Parse(reader["StarNumber"].ToString());
                        p.QUANTITY = Int32.Parse(reader["Quantity"].ToString());
                        p.CATEID = Int32.Parse(reader["CateId"].ToString());
                        p.CREATEDON = Convert.ToDateTime(reader["CreatedOn"].ToString(), culture);
                        p.STATUS = Int32.Parse(reader["Status"].ToString());
                        p.PRICE = float.Parse(reader["Price"].ToString());
                        p.IMG = reader["Img"].ToString();
                        list.Add(p);
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        // Get my plants newest
        public List<Products> GetFavoriteProductsNewest(int userID)
        {
            List<Products> list = new List<Products>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from favoriteproduct f, products p where p.ProductID =" +
                    " f.ProductID and f.UserID = @userid and p.IsDeleted = 0 ORDER by CreatedOn desc";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("userid", userID);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CultureInfo culture = new CultureInfo("en-US");
                        DateTime day = Convert.ToDateTime("7/10/2002 12:10:15 PM", culture);
                        Products p = new Products();
                        p.PROID = Int32.Parse(reader["ProductID"].ToString());
                        p.NAME = reader["Name"].ToString();
                        p.DESCRIPTION = reader["Description"].ToString();
                        p.STAR = Int32.Parse(reader["StarNumber"].ToString());
                        p.QUANTITY = Int32.Parse(reader["Quantity"].ToString());
                        p.CATEID = Int32.Parse(reader["CateId"].ToString());
                        p.CREATEDON = Convert.ToDateTime(reader["CreatedOn"].ToString(), culture);
                        p.STATUS = Int32.Parse(reader["Status"].ToString());
                        p.PRICE = float.Parse(reader["Price"].ToString());
                        p.IMG = reader["Img"].ToString();
                        list.Add(p);
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        // Get my plant price desc
        public List<Products> GetFavoriteProductsPriceDesc(int userID)
        {
            List<Products> list = new List<Products>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from favoriteproduct f, products p where p.ProductID =" +
                    " f.ProductID and f.UserID = @userid and p.IsDeleted = 0 ORDER by Price desc";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("userid", userID);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CultureInfo culture = new CultureInfo("en-US");
                        DateTime day = Convert.ToDateTime("7/10/2002 12:10:15 PM", culture);
                        Products p = new Products();
                        p.PROID = Int32.Parse(reader["ProductID"].ToString());
                        p.NAME = reader["Name"].ToString();
                        p.DESCRIPTION = reader["Description"].ToString();
                        p.STAR = Int32.Parse(reader["StarNumber"].ToString());
                        p.QUANTITY = Int32.Parse(reader["Quantity"].ToString());
                        p.CATEID = Int32.Parse(reader["CateId"].ToString());
                        p.CREATEDON = Convert.ToDateTime(reader["CreatedOn"].ToString(), culture);
                        p.STATUS = Int32.Parse(reader["Status"].ToString());
                        p.PRICE = float.Parse(reader["Price"].ToString());
                        p.IMG = reader["Img"].ToString();
                        list.Add(p);
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        // Get my plant price asc
        public List<Products> GetFavoriteProductsPriceAsc(int userID)
        {
            List<Products> list = new List<Products>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from favoriteproduct f, products p where p.ProductID =" +
                    " f.ProductID and f.UserID = @userid and p.IsDeleted = 0 ORDER by Price asc";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("userid", userID);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CultureInfo culture = new CultureInfo("en-US");
                        DateTime day = Convert.ToDateTime("7/10/2002 12:10:15 PM", culture);
                        Products p = new Products();
                        p.PROID = Int32.Parse(reader["ProductID"].ToString());
                        p.NAME = reader["Name"].ToString();
                        p.DESCRIPTION = reader["Description"].ToString();
                        p.STAR = Int32.Parse(reader["StarNumber"].ToString());
                        p.QUANTITY = Int32.Parse(reader["Quantity"].ToString());
                        p.CATEID = Int32.Parse(reader["CateId"].ToString());
                        p.CREATEDON = Convert.ToDateTime(reader["CreatedOn"].ToString(), culture);
                        p.STATUS = Int32.Parse(reader["Status"].ToString());
                        p.PRICE = float.Parse(reader["Price"].ToString());
                        p.IMG = reader["Img"].ToString();
                        list.Add(p);
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        // Tim product 
        public List<Products> FindProducts(string name)
        {
            List<Products> list = new List<Products>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from Products where IsDeleted = 0 and Name Like %@name%";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("name", name);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Products()
                        {
                            PROID = Int32.Parse(reader["ProID"].ToString()),
                            NAME = reader["Name"].ToString(),
                            DESCRIPTION = reader["Description"].ToString(),
                            STAR = Int32.Parse(reader["Star"].ToString()),
                            QUANTITY = Int32.Parse(reader["Quantity"].ToString()),
                            CATEID = Int32.Parse(reader["CateId"].ToString()),
                            CREATEDON = DateTime.Parse(reader["CreatedOn"].ToString()),
                            UPDATEDON = DateTime.Parse(reader["UpdatedOn"].ToString()),
                            STATUS = Int32.Parse(reader["Status"].ToString()),
                            ISDELETED = Int32.Parse(reader["IsDeleted"].ToString()),
                            PRICE = float.Parse(reader["Price"].ToString()),
                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        // Product theo cate
        public List<Products> SelectProducts(int cate)
        {
            List<Products> list = new List<Products>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from Products where IsDeleted = 0 and CateId = @cate ";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("cate", cate);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CultureInfo culture = new CultureInfo("en-US");
                        DateTime day = Convert.ToDateTime("7/10/2002 12:10:15 PM", culture);
                        Products p = new Products();
                        p.PROID = Int32.Parse(reader["ProductID"].ToString());
                        p.NAME = reader["Name"].ToString();
                        p.DESCRIPTION = reader["Description"].ToString();
                        p.STAR = Int32.Parse(reader["StarNumber"].ToString());
                        p.QUANTITY = Int32.Parse(reader["Quantity"].ToString());
                        p.CATEID = Int32.Parse(reader["CateId"].ToString());
                        p.CREATEDON = Convert.ToDateTime(reader["CreatedOn"].ToString(), culture);
                        p.STATUS = Int32.Parse(reader["Status"].ToString());
                        p.PRICE = float.Parse(reader["Price"].ToString());
                        p.IMG = reader["Img"].ToString();
                        list.Add(p);
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        // Product theo cate newest
        public List<Products> SelectProductsNewest(int cate)
        {
            List<Products> list = new List<Products>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from Products where IsDeleted = 0 and CateId = @cate ORDER by CreatedOn desc";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("cate", cate);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CultureInfo culture = new CultureInfo("en-US");
                        DateTime day = Convert.ToDateTime("7/10/2002 12:10:15 PM", culture);
                        Products p = new Products();
                        p.PROID = Int32.Parse(reader["ProductID"].ToString());
                        p.NAME = reader["Name"].ToString();
                        p.DESCRIPTION = reader["Description"].ToString();
                        p.STAR = Int32.Parse(reader["StarNumber"].ToString());
                        p.QUANTITY = Int32.Parse(reader["Quantity"].ToString());
                        p.CATEID = Int32.Parse(reader["CateId"].ToString());
                        p.CREATEDON = Convert.ToDateTime(reader["CreatedOn"].ToString(), culture);
                        p.STATUS = Int32.Parse(reader["Status"].ToString());
                        p.PRICE = float.Parse(reader["Price"].ToString());
                        p.IMG = reader["Img"].ToString();
                        list.Add(p);
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        // Product theo cate gia desc
        public List<Products> SelectProductsPriceDesc(int cate)
        {
            List<Products> list = new List<Products>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from Products where IsDeleted = 0 and CateId = @cate ORDER by Price desc";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("cate", cate);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CultureInfo culture = new CultureInfo("en-US");
                        DateTime day = Convert.ToDateTime("7/10/2002 12:10:15 PM", culture);
                        Products p = new Products();
                        p.PROID = Int32.Parse(reader["ProductID"].ToString());
                        p.NAME = reader["Name"].ToString();
                        p.DESCRIPTION = reader["Description"].ToString();
                        p.STAR = Int32.Parse(reader["StarNumber"].ToString());
                        p.QUANTITY = Int32.Parse(reader["Quantity"].ToString());
                        p.CATEID = Int32.Parse(reader["CateId"].ToString());
                        p.CREATEDON = Convert.ToDateTime(reader["CreatedOn"].ToString(), culture);
                        p.STATUS = Int32.Parse(reader["Status"].ToString());
                        p.PRICE = float.Parse(reader["Price"].ToString());
                        p.IMG = reader["Img"].ToString();
                        list.Add(p);
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        // Product theo cate gia asc
        public List<Products> SelectProductsPriceAsc(int cate)
        {
            List<Products> list = new List<Products>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from Products where IsDeleted = 0 and CateId = @cate ORDER by Price asc";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("cate", cate);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CultureInfo culture = new CultureInfo("en-US");
                        DateTime day = Convert.ToDateTime("7/10/2002 12:10:15 PM", culture);
                        Products p = new Products();
                        p.PROID = Int32.Parse(reader["ProductID"].ToString());
                        p.NAME = reader["Name"].ToString();
                        p.DESCRIPTION = reader["Description"].ToString();
                        p.STAR = Int32.Parse(reader["StarNumber"].ToString());
                        p.QUANTITY = Int32.Parse(reader["Quantity"].ToString());
                        p.CATEID = Int32.Parse(reader["CateId"].ToString());
                        p.CREATEDON = Convert.ToDateTime(reader["CreatedOn"].ToString(), culture);
                        p.STATUS = Int32.Parse(reader["Status"].ToString());
                        p.PRICE = float.Parse(reader["Price"].ToString());
                        p.IMG = reader["Img"].ToString();
                        list.Add(p);
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        // Invoice Detail
        public List<Products> SelectInvoiceDetail(Invoices i)
        {
            List<Products> list = new List<Products>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from products p, invoicedetail i WHERE p.ProductID = i.ProId and i.PackID = @packid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("packid", i.PACKID);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CultureInfo culture = new CultureInfo("en-US");
                        DateTime day = Convert.ToDateTime("7/10/2002 12:10:15 PM", culture);
                        _ = new Products();
                        Products p = new Products();
                        p.PROID = Int32.Parse(reader["ProID"].ToString());
                        p.NAME = reader["Name"].ToString();
                        p.DESCRIPTION = reader["Description"].ToString();
                        p.STAR = Int32.Parse(reader["StarNumber"].ToString());
                        p.QUANTITY = Int32.Parse(reader["Qty"].ToString());
                        p.CATEID = Int32.Parse(reader["CateId"].ToString());
                        p.CREATEDON = Convert.ToDateTime(reader["CreatedOn"].ToString(), culture);
                        p.STATUS = Int32.Parse(reader["Status"].ToString());
                        p.PRICE = float.Parse(reader["Price"].ToString());
                        p.IMG = reader["Img"].ToString();
                        list.Add(p);
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        // Check hang ton tai trong gio hang 
        public int checkhang (Invoices i, int proid)
        {
            List<Products> list = new List<Products>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from products p, invoicedetail i WHERE p.ProductID = i.ProId and i.PackID = @packid and i.ProId = @proid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("packid", i.PACKID);
                cmd.Parameters.AddWithValue("proid", proid);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CultureInfo culture = new CultureInfo("en-US");
                        DateTime day = Convert.ToDateTime("7/10/2002 12:10:15 PM", culture);
                        _ = new Products();
                        Products p = new Products();
                        p.PROID = Int32.Parse(reader["ProID"].ToString());
                        p.NAME = reader["Name"].ToString();
                        p.DESCRIPTION = reader["Description"].ToString();
                        p.STAR = Int32.Parse(reader["StarNumber"].ToString());
                        p.QUANTITY = Int32.Parse(reader["Qty"].ToString());
                        p.CATEID = Int32.Parse(reader["CateId"].ToString());
                        p.CREATEDON = Convert.ToDateTime(reader["CreatedOn"].ToString(), culture);
                        p.STATUS = Int32.Parse(reader["Status"].ToString());
                        p.PRICE = float.Parse(reader["Price"].ToString());
                        p.IMG = reader["Img"].ToString();
                        list.Add(p);
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list.Count;
        }
        // All Review
        public List<Review> SelectReview()
        {
            List<Review> list = new List<Review>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from review";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Review()
                        {
                            REVIEWER = Int32.Parse(reader["Reviewer"].ToString()),
                            CONTENT = reader["Content"].ToString()
                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        // ALL Product
        public List<Products> AllProducts()
        {
            List<Products> list = new List<Products>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from Products";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CultureInfo culture = new CultureInfo("en-US");
                        DateTime day = Convert.ToDateTime("7/10/2002 12:10:15 PM", culture);
                        _ = new Products();
                        Products p = new Products();
                        p.PROID = Int32.Parse(reader["ProductID"].ToString());
                        p.NAME = reader["Name"].ToString();
                        p.DESCRIPTION = reader["Description"].ToString();
                        p.STAR = Int32.Parse(reader["StarNumber"].ToString());
                        p.QUANTITY = Int32.Parse(reader["Quantity"].ToString());
                        p.CATEID = Int32.Parse(reader["CateId"].ToString());
                        p.CREATEDON = Convert.ToDateTime(reader["CreatedOn"].ToString(), culture);
                        p.STATUS = Int32.Parse(reader["Status"].ToString());
                        p.PRICE = float.Parse(reader["Price"].ToString());
                        p.IMG = reader["Img"].ToString();
                        if (reader["IsDeleted"].ToString() == "True")
                        {
                            p.ISDELETED = 1;
                        }
                        else
                        {
                            p.ISDELETED = 0;
                        }
                        list.Add(p);
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        // ALL User
        public List<Users> AllUser()
        {
            List<Users> list = new List<Users>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from Users";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CultureInfo culture = new CultureInfo("en-US");
                        DateTime day = Convert.ToDateTime("7/10/2002 12:10:15 PM", culture);
                        Users u = new Users();
                        u.USERID = Int32.Parse(reader["UserID"].ToString());
                        u.USERNAME = reader["Username"].ToString();
                        u.PASSWORD = reader["Password"].ToString();
                        u.ADDRESS = reader["Address"].ToString();
                        u.EMAIL = reader["Email"].ToString();
                        u.PHONE = reader["Phone"].ToString();
                        u.FIRSTNAME = reader["Firstname"].ToString();
                        u.LASTNAME = reader["Lastname"].ToString();
                        u.REGISTRATIONDATE = Convert.ToDateTime(reader["Registrationdate"].ToString(), culture);
                        if (reader["IsDeleted"].ToString() == "True")
                        {
                            u.ISDELETED = 1;
                        }
                        else
                        {
                            u.ISDELETED = 0;
                        }
                        if (reader["IsAdmin"].ToString() == "True")
                        {
                            u.ROLEID = 1;
                        }
                        else
                        {
                            u.ROLEID = 0;
                        }
                        list.Add(u);
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        // Check Email exist
        public int CheckEmail(string email)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from Users where Email = @email";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("email", email);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count++;
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return count;
        }
        // Get invoice
        public Invoices GetInv(int u)
        {
            Invoices i = new Invoices();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                var str1 = "SELECT * from invoice where UserID = @u order by PackID DESC limit 1";
                MySqlCommand cmd1 = new MySqlCommand(str1, conn);
                cmd1.Parameters.AddWithValue("u", u);
                using (var reader = cmd1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CultureInfo culture = new CultureInfo("en-US");
                        i = new Invoices();
                        i.PACKID = Int32.Parse(reader["PackID"].ToString());
                        if (reader["IsPaid"].ToString() == "True")
                        {
                            i.ISPAID = 1;
                        }
                        else
                        {
                            i.ISPAID = 0;
                        }
                        i.TOTALPRICE = float.Parse(reader["TotalPrice"].ToString());
                        i.USERID = Int32.Parse(reader["UserID"].ToString());
                        i.CREATEDON = Convert.ToDateTime(reader["CreatedOn"].ToString(), culture);
                        i.PAIDON = new DateTime();
                    }
                    reader.Close();
                }
            }
            return i;
        }
        [HttpPost]
        /////// PRODUCT
        // Them product
        public int InsertProduct(Products p)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into products (Name, Description, price, quantity, " +
                    "cateid, img) values(@productname, @description, @price, @quantity, @cateid, @img)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("productname", p.NAME);
                cmd.Parameters.AddWithValue("description", p.DESCRIPTION);
                cmd.Parameters.AddWithValue("price", p.PRICE);
                cmd.Parameters.AddWithValue("quantity", p.QUANTITY);
                cmd.Parameters.AddWithValue("cateid", p.CATEID);
                cmd.Parameters.AddWithValue("img", p.IMG);

                return (cmd.ExecuteNonQuery());

            }
        }
        // Sua product
        public int UpdateProduct(Products p)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "UPDATE products SET Name = @name, Description = @description"
                    +", Price = @price, Quantity = @quantity, Cateid = @cateid, Status =" +
                    " @status, Isdeleted = @isdeleted WHERE ProductID = @productid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("name", p.NAME);
                cmd.Parameters.AddWithValue("description", p.DESCRIPTION);
                cmd.Parameters.AddWithValue("price", p.PRICE);
                cmd.Parameters.AddWithValue("quantity", p.QUANTITY);
                cmd.Parameters.AddWithValue("cateid", p.CATEID);
                cmd.Parameters.AddWithValue("status", p.STATUS);
                cmd.Parameters.AddWithValue("isdeleted", p.ISDELETED);
                cmd.Parameters.AddWithValue("productid", p.PROID);
                return (cmd.ExecuteNonQuery());
            }
        }
        // dlt product
        public int DeleteProduct(int p)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "UPDATE products SET Isdeleted = true WHERE ProductID = @productid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("productid", p);
                return (cmd.ExecuteNonQuery());
            }
        }
        // + 10 qty
        public int Add10Product(int p)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "UPDATE products SET Quantity = Quantity + 10 WHERE ProductID = @productid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("productid", p);
                return (cmd.ExecuteNonQuery());
            }
        }
        public int ReSaleProduct(int p)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "UPDATE products SET Isdeleted = false WHERE ProductID = @productid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("productid", p);
                return (cmd.ExecuteNonQuery());
            }
        }
        // Them product yeu thich
        public int InsertFavoriteProduct(Users u, Products p)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                List<Products> list = this.GetFavoriteProducts(u.USERID);
                int c = 0;
                foreach(var item in list)
                {
                    if (item.PROID == p.PROID)
                    {
                        c = 1;
                    }
                }
                if (c == 1)
                {
                    return 0;
                }
                else
                {
                    var str = "INSERT INTO 	favoriteproduct	(UserID, ProductID) values (@userid, @productid)";
                    MySqlCommand cmd = new MySqlCommand(str, conn);
                    cmd.Parameters.AddWithValue("userid", u.USERID);
                    cmd.Parameters.AddWithValue("productid", p.PROID);

                    return (cmd.ExecuteNonQuery());
                }
            }
        }
        // Xoa product yeu thich
        public int DeleteFavoriteProduct(Users u, Products p)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "Delete from favoriteproduct where UserID = @userid, ProductID = @productid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("userid", u.USERID);
                cmd.Parameters.AddWithValue("productid", p.PROID);

                return (cmd.ExecuteNonQuery());
            }
        }

        /////// User
        // Dang ky
        public Users InsertUser(Users u)
        {
            Users u1 = new Users();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into users (Password, Email) values (@password, @email)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("password", u.PASSWORD);
                cmd.Parameters.AddWithValue("email", u.EMAIL);
                cmd.ExecuteNonQuery();

                string str1 = "select * from Users where Email = @email";
                MySqlCommand cmd1 = new MySqlCommand(str1, conn);
                cmd1.Parameters.AddWithValue("email", u.EMAIL);
                using (var reader = cmd1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CultureInfo culture = new CultureInfo("en-US");
                        u1 = new Users();
                        u1.USERID = Int32.Parse(reader["UserID"].ToString());
                        u1.PASSWORD = reader["Password"].ToString();
                        u1.EMAIL = reader["Email"].ToString();
                        u1.REGISTRATIONDATE = Convert.ToDateTime(reader["Registrationdate"].ToString(), culture);
                    }
                    reader.Close();
                }
            }
            return u1;
        }
        // Dang nhap
        public Users LogIn(Users u)
        {
            Users u1 = new Users();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                string str = "select * from Users where Email = @email and Password = @pass";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("email", u.EMAIL);
                cmd.Parameters.AddWithValue("pass", u.PASSWORD);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CultureInfo culture = new CultureInfo("en-US");
                        DateTime day = Convert.ToDateTime("7/10/2002 12:10:15 PM", culture);

                        u1 = new Users();
                        u1.USERID = Int32.Parse(reader["UserID"].ToString());
                        u1.USERNAME = reader["Username"].ToString();
                        u1.PASSWORD = reader["Password"].ToString();
                        u1.EMAIL = reader["Email"].ToString();
                        u1.ADDRESS = reader["Address"].ToString();
                        u1.PHONE = reader["Phone"].ToString();
                        u1.FIRSTNAME = reader["Firstname"].ToString();
                        u1.LASTNAME = reader["Lastname"].ToString();
                        if (reader["IsAdmin"].ToString() == "True")
                        {
                            u1.ROLEID = 1;
                        }
                        else
                        {
                            u1.ADDRESS = reader["IsAdmin"].ToString();
                        }
                        if (reader["IsDeleted"].ToString() == "True")
                        {
                            u1.ISDELETED = 1;
                        }
                        else
                        {
                            u1.ISDELETED = 0;
                        }
                        u1.REGISTRATIONDATE = Convert.ToDateTime(reader["Registrationdate"].ToString(), culture);
                        if (reader["UpdatedOn"].ToString() == "") { }
                        else { u1.UPDATEDON = Convert.ToDateTime(reader["UpdatedOn"].ToString(), culture); }
                        if (reader["DateOfBirth"].ToString() == "") { }
                        else { u1.DATEOFBIRTH = Convert.ToDateTime(reader["DateOfBirth"].ToString(), culture); }
                    }
                    reader.Close();
                }
            }
            return u1;
        }
        // Update user  
        public int ChangePassword(Users u)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "UPDATE users SET Password = @pass" +
                    " WHERE Email = @email";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("pass", u.PASSWORD);
                cmd.Parameters.AddWithValue("email", u.EMAIL);
                return (cmd.ExecuteNonQuery());
            }
        }

        public int ChangeProfile(Users u)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "UPDATE users SET Password = @pass, Firstname = @first, Lastname = @last, Email = @email," +
                    " Phone = @phone , Address = @address " +
                    " WHERE Email = @email";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("pass", u.PASSWORD);
                cmd.Parameters.AddWithValue("email", u.EMAIL);
                cmd.Parameters.AddWithValue("first", u.FIRSTNAME);
                cmd.Parameters.AddWithValue("last", u.LASTNAME);
                cmd.Parameters.AddWithValue("phone", u.PHONE);
                cmd.Parameters.AddWithValue("address", u.ADDRESS);
                return (cmd.ExecuteNonQuery());
            }
        }
        // dtl User
        public int DeleteUser(int u)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "UPDATE users SET Isdeleted = true WHERE Userid = @uid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("uid", u);
                return (cmd.ExecuteNonQuery());
            }
        }
        // Active User
        public int ActiveUser(int u)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "UPDATE users SET Isdeleted = false WHERE Userid = @uid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("uid", u);
                return (cmd.ExecuteNonQuery());
            }
        }
        // Active User
        public int ToAdmin(int u)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "UPDATE users SET IsAdmin = true WHERE Userid = @uid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("uid", u);
                return (cmd.ExecuteNonQuery());
            }
        }
        public int ToMem(int u)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "UPDATE users SET IsAdmin = false WHERE Userid = @uid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("uid", u);
                return (cmd.ExecuteNonQuery());
            }
        }
        ////// CATEGORY
        // Them category
        public int InsertCategory(Category c)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into category ('CateName') values(@catename)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("catename", c.CATENAME);

                return (cmd.ExecuteNonQuery());

            }
        }
        // Sua category
        public int UpdateCategory(Category c)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "UPDATE category SET CateName = @catename WHERE CateId = @cateid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("catename", c.CATENAME);
                cmd.Parameters.AddWithValue("cateid", c.CATEID);
                return (cmd.ExecuteNonQuery());
            }
        }

        ///// INVOICE
        // Tao invoice
        public Invoices Createinvoice(Users u)
        {
            Invoices i = new Invoices();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into invoice (UserID) values (@userid)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("userid", u.USERID);
                cmd.ExecuteNonQuery();

                var str1 = "SELECT * from invoice order by PackID DESC limit 1";
                MySqlCommand cmd1 = new MySqlCommand(str1, conn);
                using (var reader = cmd1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CultureInfo culture = new CultureInfo("en-US");
                        i = new Invoices();
                        i.PACKID = Int32.Parse(reader["PackID"].ToString());
                        if (reader["IsPaid"].ToString() == "True")
                        {
                            i.ISPAID = 1;
                        }
                        else
                        {
                            i.ISPAID = 0;
                        }
                        i.TOTALPRICE = float.Parse(reader["TotalPrice"].ToString());
                        i.USERID = Int32.Parse(reader["UserID"].ToString());
                        i.CREATEDON = Convert.ToDateTime(reader["CreatedOn"].ToString(), culture);
                        i.PAIDON = new DateTime();
                    }
                    reader.Close();
                }
            }
            return i;
        }
        // Them san pham vao invoice
        public int InsertProductintoInvoice(Products p, Invoices i, int quantity)
        {
            using (MySqlConnection conn = GetConnection())
            {
                int a = this.checkhang(i, p.PROID);
                if (a > 0)
                {
                    using (MySqlConnection conn1 = GetConnection())
                    {
                        conn.Open();
                        var str = "UPDATE invoicedetail SET Qty = Qty + @quantity WHERE ProId = @proid and PackID = @packid";
                        MySqlCommand cmd = new MySqlCommand(str, conn);
                        cmd.Parameters.AddWithValue("proid", p.PROID);
                        cmd.Parameters.AddWithValue("quantity", quantity);
                        cmd.Parameters.AddWithValue("packid", i.PACKID);
                        cmd.ExecuteNonQuery();

                        return 1;
                    }
                }
                else
                {
                    conn.Open();
                    var str = "insert into invoicedetail (ProId, PackID, Qty) values (@proid, @packid, @quantity)";
                    MySqlCommand cmd = new MySqlCommand(str, conn);
                    cmd.Parameters.AddWithValue("proid", p.PROID);
                    cmd.Parameters.AddWithValue("packid", i.PACKID);
                    cmd.Parameters.AddWithValue("quantity", quantity);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        //Sua san pham trong invoice
        public int UpdateProductInInvoice (InvoiceDetail i)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "UPDATE invoicedetail SET Qty = @quantity WHERE ProId = @proid and PackID = @packid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("proid", i.PROID);
                cmd.Parameters.AddWithValue("quantity", i.QUANTITY);
                cmd.Parameters.AddWithValue("packid", i.PACKID);
                return cmd.ExecuteNonQuery();
            }
        }
        // Thanh toan
        public int Pay(Invoices i)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "UPDATE invoice SET ispaid = true WHERE PackID = @packid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("packid", i.PACKID);
                return cmd.ExecuteNonQuery();
            }
        }
        // Xoa san pham trong invoice
        public int DeleteProductInInvoice (InvoiceDetail i)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "Delete from invoicedetail where ProId = @proid and PackID = @packid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("proid", i.PROID);
                cmd.Parameters.AddWithValue("packid", i.PACKID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int AddReview (Review r)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "Insert into review (	Reviewer , Content) values (@reviewer, @content)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("reviewer", r.REVIEWER);
                cmd.Parameters.AddWithValue("content", r.CONTENT);
                return cmd.ExecuteNonQuery();
            }
        }
        public StoreContext()
        {
        }
    }
}
