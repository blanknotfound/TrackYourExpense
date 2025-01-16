using System.Text.Json;

namespace TrackYourExpenses.Model.Abstraction
{
    public class DebtBase
    {
        protected static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "Debts.json");
        protected static List<Debt> GetAllDebts()
        {
            if (!File.Exists(FilePath)) return new List<Debt>();

            var json = File.ReadAllText(FilePath);

            return JsonSerializer.Deserialize<List<Debt>>(json) ?? new List<Debt>();
        }
        protected static void SaveDebt(List<Debt> transaction)
        {
            var json = JsonSerializer.Serialize(transaction);
            File.WriteAllText(FilePath, json);
        }
    }
}
