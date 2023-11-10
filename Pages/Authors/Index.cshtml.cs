using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Aruncutean_Serban_Lab2.Data;
using Aruncutean_Serban_Lab2.Models;
using Aruncutean_Serban_Lab2.Models.ViewModels;

namespace Aruncutean_Serban_Lab2.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly Aruncutean_Serban_Lab2.Data.Aruncutean_Serban_Lab2Context _context;

        public IndexModel(Aruncutean_Serban_Lab2.Data.Aruncutean_Serban_Lab2Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public AuthorIndexData AuthorData { get; set; }
        public int AuthorID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            AuthorData = new AuthorIndexData();
            AuthorData.Authors = await _context.Authors
            .Include(i => i.Books)
            .ThenInclude(c => c.Author)
            .OrderBy(i => i.FullName)
            .ToListAsync();
            if (id != null)
            {
                AuthorID = id.Value;
                Author author = AuthorData.Authors
                .Where(i => i.ID == id.Value).Single();
                AuthorData.Books = author.Books;
            }
        }
    }
}