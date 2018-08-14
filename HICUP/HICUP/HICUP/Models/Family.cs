using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using SQLitePCL;

namespace HICUP.Models
{
    [Table("Family")]
    public class Family
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FamilyName { get; set; }
        [Unique]
        public string FamilyAdmin { get; set; }
        [Unique]
        public int RelatedTable { get; set; }

        [OneToMany]
        public List<User> FamilyMembers { get; set; }

        public Family() { }
        public Family(string FamilyName, string FamilyAdmin)
        {
            this.FamilyName = FamilyName;
            this.FamilyAdmin = FamilyAdmin;
        }
    }
}
