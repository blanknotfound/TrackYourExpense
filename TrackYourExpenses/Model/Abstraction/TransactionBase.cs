using System.Text.Json;
using DataModel.Model;

namespace TrackYourExpenses.Model.Abstraction
{
    public abstract class TransactionServicesBase
    {
        protected static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "Transaction.json");
        protected static readonly string TagFilePath = Path.Combine(FileSystem.AppDataDirectory, "Tags.json");
        protected static List<Transaction> GetAllDetails()
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
        protected static List<CustomTags> Gettags()
        {
            if (!File.Exists(TagFilePath)) return new List<CustomTags>();

            var json = File.ReadAllText(TagFilePath);

            return JsonSerializer.Deserialize<List<CustomTags>>(json) ?? new List<CustomTags>();
        }
        protected static void SaveTags(List<CustomTags> ctags)
        {
            var json = JsonSerializer.Serialize(ctags);
            File.WriteAllText(TagFilePath, json);
        }
    }
}