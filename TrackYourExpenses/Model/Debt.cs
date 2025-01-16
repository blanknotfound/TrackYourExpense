using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackYourExpenses.Model
{
    public class Debt
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Creditor { get; set; }

        public int Amount  { get; set; }
        public bool Status { get; set; } = false;
        public DateTime takenDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public string? TransactionId { get; set; }
    }
}
