using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace QuoteManager.Models.Database.Account
{
    public class tbl_users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // To force id to be sent
        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string jobtitle { get; set; }
        public bool passwordChanged { get; set; }
        public int memberId { get; set; }
        public Guid? guid { get; set; }
        public DateTime guid_exppiring_date { get; set; }

    }
}