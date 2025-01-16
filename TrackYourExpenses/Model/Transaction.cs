using System.ComponentModel.DataAnnotations;

namespace DataModel.Model
{
    public class Transaction
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0.")]
        public int Amount { get; set; }
        public string Type { get; set; }
        public DateTime? Date { get; set; }
        public Guid tagId { get; set; }
    }
}
