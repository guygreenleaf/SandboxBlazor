using SandboxBlazor.Server.db;
using SandboxBlazor.Shared.Models;

namespace SandboxBlazor.Server.Repository
{
    public class WineBottleRepository : IWineBottleRepository
    {
        public readonly ISqlDataAccess _db;

        public WineBottleRepository(IConfiguration config)
        {
            _db = new SqlDataAccess(config.GetConnectionString("SqlServer"), "WineBottle");
        }


        public async Task<List<WineBottle>> GetAllWineBottles()
        {

            var result = await _db.QueryAsync<WineBottle, dynamic>("SELECT * FROM WineBottle;", new { }, true, SqlAccessType.Select, System.Data.CommandType.Text);


            return result.ToList();
        }


        public async Task<WineBottle> GetWineBottleBySku(string sku)
        {

            string sSql = "SELECT * FROM WineBottle WHERE SKU = @sku ;";

            var res = await _db.QueryAsync<WineBottle, dynamic>(sSql, new { sku }, true, SqlAccessType.Select, System.Data.CommandType.Text);

            return res.First() ?? new WineBottle();
        }


        public async Task<long> InsertWineBottle(WineBottle newWineBottle)
        {
            var sSql = "INSERT INTO WineBottle (SKU,BrandName,CostPerBottle) VALUES (@SKU, @BrandName, @CostPerBottle); SELECT SCOPE_IDENTITY();";

            var responseID = await _db.QueryAsync<long, dynamic>(sSql, new { newWineBottle.SKU, newWineBottle.BrandName, newWineBottle.CostPerBottle }, true, SqlAccessType.Insert, System.Data.CommandType.Text);

            return responseID.First();
        }
    }
}
