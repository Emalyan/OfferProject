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
    public class OfferRepository : IOfferRepository
    {        
        private readonly string connectionString;   

        public OfferRepository(IConfiguration configuration)
        {            
            connectionString = configuration.GetConnectionString("DevConnect");
        }

        internal IDbConnection Connection
        {
            get { return new NpgsqlConnection(connectionString); }
        }

        public IEnumerable<Offer> ReadAll()
        {            
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Offer>("SELECT * FROM offer");
            }
        }

        public void Create(Offer offer)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO offer (dateofcreate, customerid, exploreid) VALUES(@DateOFCreate, @CustomerId, @ExploreId)", offer);
            }
        }

        public void Delete(Offer offer)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM offer WHERE id=@Id", new { Id = offer.Id });
            }
        }        

        public Offer ReadId(long id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Offer>("SELECT * FROM offer WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Update(Offer offer)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE offer SET exploreid = @ExploreId WHERE id = @Id", offer);
            }
        }
    }
}
