﻿using System;
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
        [ForeignKey(typeof(User)), Unique]
        public string FamilyName { get; set; }
        public string FamilyAdmin { get; set; }
        public int RelatedTable { get; set; }

        public Family() { }
        public Family(string FamilyName, string FamilyAdmin)
        {
            this.FamilyName = FamilyName;
            this.FamilyAdmin = FamilyAdmin;
        }
    }
}