using SandboxBlazor.Shared.Models;

namespace SandboxBlazor.Client.Services
{
    public interface IWineBottleService
    {
        Task<List<WineBottle>?> GetAllWineBottles();
        Task<WineBottle?> GetWineBottleBySku(string sku);

        Task<long?> InsertWineBottle(WineBottle newWineBottle);
    }
}
