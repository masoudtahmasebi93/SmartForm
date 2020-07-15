using System.Threading.Tasks;

namespace SmartForm.Common.Mongo
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync();
    }
}