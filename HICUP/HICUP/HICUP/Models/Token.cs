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
        public User username { get; set; }
        public bool accessToken { get; set; }
        public int familyId { get; set; }
        public DateTime expireDate { get; set; }

        public Token() { }
        public Token(User Username, int FamilyId)
        {
            this.username = Username;
            this.familyId = FamilyId;
            this.accessToken = true;
            this.expireDate = DateTime.Today.AddDays(3);
        }

    }
}
