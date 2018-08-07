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
        [Unique]
        public string Email { get; set; }
        public string Password { get; set; }
        [Unique]
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

        public bool CheckNotEmpty()
        {
            if (!this.Email.Equals("") && !this.Password.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
