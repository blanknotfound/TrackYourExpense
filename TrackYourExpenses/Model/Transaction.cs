namespace TrackYourExpenses.Model
{
    public class Transaction
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }

    }
}
