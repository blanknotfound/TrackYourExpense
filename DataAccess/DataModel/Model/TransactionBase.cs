using System.Text.Json;

namespace DataModel.Model
{
    public abstract class TransactionServicesBase
    {
        protected static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "Transaction.json");
        protected static List<Transaction> GetAll()
        {
            if (!File.Exists(FilePath)) return new List<Transaction>();

            var json = File.ReadAllText(FilePath);

            return JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
        }
        protected static void SaveTransaction(List<Transaction> transaction)
        {
            var json = JsonSerializer.Serialize(transaction);
            File.WriteAllText(FilePath, json);
        }
    }
}