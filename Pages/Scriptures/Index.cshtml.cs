using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Books { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Book { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> bookQuery = from b in _context.Scripture
                                           orderby b.ScriptureBook
                                           select b.ScriptureBook;

            var words = from w in _context.Scripture select w;

            if (!string.IsNullOrEmpty(SearchString))
            {
                words = words.Where(s => s.Notes.Contains(SearchString));
            }

            if(!string.IsNullOrEmpty(Book)) 
            {
                words = words.Where(x => x.ScriptureBook == Book);
            }

            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            Scripture = await words.ToListAsync();
        }
    }
}
