using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineBookStore.Models
{ 
    //Books detail model
    public class Book
    {
        [Key]
        public string BookID { get; set; }

        public string BookTitle { get; set; }

        public bool IsReserved { get; set; }
    }
}