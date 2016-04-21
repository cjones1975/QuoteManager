using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.ViewModel.Quote
{
    public class QuoteFolderViewModel
    {
        [Key]
        public int folderId { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
    }
}