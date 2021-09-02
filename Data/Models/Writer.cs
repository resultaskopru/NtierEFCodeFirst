using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Writer
    {
        public int WriterId { get; set; }
        public string WriterName{ get; set; }
        public string WriterLastName { get; set; }
        //public virtual ICollection<Book> Book { get; set; }
    }
}
