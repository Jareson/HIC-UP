using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HICUP.Models
{
    public class Token
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public User Username { get; set; }
        public bool AccessToken { get; set; }
        public int FamilyId { get; set; }
        public DateTime ExpireDate { get; set; }

        public Token() { }
        public Token(User Username, int FamilyId)
        {
            this.Username = Username;
            this.FamilyId = FamilyId;
            this.AccessToken = true;
            this.ExpireDate = DateTime.Today.AddDays(3);
        }

    }
}
