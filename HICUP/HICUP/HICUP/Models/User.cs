using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HICUP.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("ID")]
        public int Id { get; set; }
        [Column("Email"), Unique]
        public string Email { get; set; }
        [Column("Password")]        
        public string Password { get; set; }
        [Column("Family"), Unique]
        public string Family { get; set; }

        public User() { }
        public User(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
            this.Family = Email;

        }
        public User(string Email, string Password, string Family)
        {
            this.Email = Email;
            this.Password = Password;
            this.Family = Family;
        }

        public bool CheckInformation()
        {
            if(!this.Email.Equals("") && !this.Password.Equals(""))
            {
                if(this.Email.Equals(App.UserDatabase.GetUser()) && this.Password.Equals(App.UserDatabase.GetUser()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
