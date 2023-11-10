using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Aruncutean_Serban_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName{ get; set; }
        public string Lastname { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
