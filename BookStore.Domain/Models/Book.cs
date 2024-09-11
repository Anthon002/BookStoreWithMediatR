using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Domain.Models
{
    public class Book
    {
        public string Id {get; set;}
        public string Title {get; set;}
        public string Author {get;set;}
        public DateTime DatePublished {get; set;}
        public string Synopsis {get; set;}
    }
}