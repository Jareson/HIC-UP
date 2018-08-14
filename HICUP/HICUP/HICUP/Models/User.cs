using SQLite;
using SQLiteNetExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using SQLiteNetExtensions.Attributes;

namespace HICUP.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        [Unique]
        public string Email { get; set; }
        [MaxLength(15)]
        public string Password { get; set; }
        [Unique]
        public string Family { get; set; }
        public string FamilyId { get; set; }

        public User() { }
        public User(string Username, string Email, string Password)
        {
            this.Username = Username;
            this.Email = Email;
            this.Password = Password;
            this.Family = Email;

        }
        public User(string Username, string Email, string Password, string Family)
        {
            this.Username = Username;
            this.Email = Email;
            this.Password = Password;
            this.Family = Family;
        }
        public User(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
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
