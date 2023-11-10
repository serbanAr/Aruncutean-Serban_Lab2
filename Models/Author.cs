using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Aruncutean_Serban_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName{ get; set; }
        public string Lastname { get; set; }
        [Display(Name = "Author")]
        public string FullName
        {
            get
            {
                return FirstName + " " + Lastname;
            }
        }
        public ICollection<Book>? Books { get; set; }
    }
}
