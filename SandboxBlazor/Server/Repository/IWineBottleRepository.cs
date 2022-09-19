using SandboxBlazor.Shared.Models;

namespace SandboxBlazor.Server.Repository
{
    public interface IWineBottleRepository
    {
        Task<List<WineBottle>> GetAllWineBottles();


        Task<WineBottle> GetWineBottleBySku(string sku);

        Task<long> InsertWineBottle(WineBottle newWineBottle);
    }
}
