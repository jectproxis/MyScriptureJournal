using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        public int Id { get; set; }

        [Display(Name = "Book")]
        [Required]
        public string? ScriptureBook { get; set; }

        [Display(Name = "Chapter")]
        [Required]
        public string? ChapterNumber { get; set; }

        [Display(Name = "Verse")]
        [Required]
        public string? VerseNumber { get; set; }

        [Display(Name = "Entry Date")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Scripture")]
        [Required]
        public string? ScriptureText { get; set; }

        [Required]
        public string? Notes { get; set; }
    }
}
