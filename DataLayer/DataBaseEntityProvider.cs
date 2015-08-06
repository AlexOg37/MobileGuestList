using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataBaseEntityProvider
    {
        private const string DataEntitiesConnectionName = "DataEntitiesConnection";
        private const string InitialCatalogName = "initial catalog=";
        private const string DbNameByDefault = "ps2021";
        
        //ToDo: move this messages to resources
        private const string ConnectionIsNotExistMessage = "Connection template is not exist";
        private const string NoInitialCatalogInCSMessage = "There is no initial catalog in connection string";

        private string RepositoryName = string.Empty;
        private DataEntitiesConnection _context = null;

        public DataEntitiesConnection Context
        {
            get
            {
                if (this._context == null)
                {
                    string connectionString = string.Empty;
                    if (ConfigurationManager.ConnectionStrings[DataEntitiesConnectionName] == null)
                        throw new NotImplementedException(ConnectionIsNotExistMessage);

                    string connString = ConfigurationManager.ConnectionStrings[DataEntitiesConnectionName].ConnectionString;
                    string[] sections = connString.Split(';');
                    //initial catalog=ps2021;
                    string catalogItem = sections.SingleOrDefault(el => el.Contains(InitialCatalogName));

                   if (string.IsNullOrWhiteSpace(catalogItem))
                       throw new NotImplementedException(NoInitialCatalogInCSMessage);

                   string dbName = catalogItem.Replace(InitialCatalogName, string.Empty);

                    connString.Replace(dbName, this.RepositoryName);

                    this._context = new DataEntitiesConnection(connString);
                }

                return this._context;
            }
        }
        public DataBaseEntityProvider()
            : this(DbNameByDefault)
        {
            this.RepositoryName = DbNameByDefault;
        }

        public DataBaseEntityProvider(string repoName)
        {
            // TODO: Complete member initialization
            this.RepositoryName = repoName;

        }
    }
}
