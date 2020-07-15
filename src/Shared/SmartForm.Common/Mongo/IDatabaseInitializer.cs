using System.Threading.Tasks;

namespace SmartForm.Common.Mongo
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync();
    }
}