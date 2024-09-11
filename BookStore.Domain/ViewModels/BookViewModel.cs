using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Domain.ViewModels
{
    public class BookViewModel
    {
        public string Title {get; set;}
        public string Author {get;set;}
        public DateTime DatePublished {get; set;}
        public string Synopsis {get; set;}
    }
}