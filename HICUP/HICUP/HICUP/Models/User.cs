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
        public string Password { get; set; }
        [ForeignKey(typeof(Family))]
        public int FamilyId { get; set; }

        [ManyToOne]
        public Family Family { get; set; }


        public User() { }
        public User(string Username, string Email, string Password)
        {
            this.Username = Username;
            this.Email = Email;
            this.Password = Password;
            Family familyCheck = App.FamilyDatabase.CheckFamily(Email);
            if (familyCheck == null)
            {
                Family newFamily = new Family(Email, Email);
                App.FamilyDatabase.SaveFamily(newFamily);
                this.FamilyId = App.FamilyDatabase.CheckFamily(Email).Id;
            }
        }

        public User(string Username, string Email, string Password, string Family)
        {
            this.Username = Username;
            this.Email = Email;
            this.Password = Password;
            Family familyCheck = App.FamilyDatabase.CheckFamily(Family);
            if (familyCheck == null)
            {
                Family newFamily = new Family(Family, Email);
                App.FamilyDatabase.SaveFamily(newFamily);
                this.FamilyId = App.FamilyDatabase.CheckFamily(Family).Id;
            }
        }

        public User(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;

        }

        public bool PasswordMatch(string pass1, string pass2)
        {
            return pass1.Equals(pass2);
        }
    }
}
