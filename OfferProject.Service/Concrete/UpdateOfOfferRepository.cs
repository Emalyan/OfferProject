using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using OfferProject.Data.Data;
using OfferProject.Service.Abstract;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OfferProject.Service.Concrete
{
    public class UpdateOfOfferRepository : IUpdateOfOfferRepository
    {
        private readonly string connectionString;

        public UpdateOfOfferRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DevConnect");
        }

        internal IDbConnection Connection
        {
            get { return new NpgsqlConnection(connectionString); }
        }

        public IEnumerable<UpdateOfOffer> ReadAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<UpdateOfOffer>("SELECT * FROM updatesofoffer");
            }            
        }

        public void Create(UpdateOfOffer updateOfOffer)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO updatesofoffer (dateofupdate, offerid, updateby) VALUES(@DateOfUpdate, @OfferId, @UpdateBy)", updateOfOffer);
            }
        }

        public void Delete(UpdateOfOffer updateOfOffer)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM updatesofoffer WHERE id=@ID", new { Id = updateOfOffer.Id });
            }
        }
        
        public UpdateOfOffer ReadId(long id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<UpdateOfOffer>("SELECT * FROM updatesofoffer WHERE id=@Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Update(UpdateOfOffer updateOfOffer)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE updatesofoffer SET ", updateOfOffer);
            }            
        }
    }
}
