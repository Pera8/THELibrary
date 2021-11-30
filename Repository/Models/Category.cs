using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Category:IBaseModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<Book> BooksList { get; set; }
    }
}
