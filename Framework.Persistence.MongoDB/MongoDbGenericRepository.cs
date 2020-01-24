using Framework.Core;
using Framework.Domain;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Persistence.MongoDB
{
    public class MongoDbRepository<TEntity> :
           IRepository<TEntity> where
           TEntity : Entity
    {
        private MongoDatabase database;
        private MongoCollection<TEntity> collection;
        public MongoDbRepository()
        {


            GetDatabase();
            GetCollection();
        }

        public void Create(TEntity entity)
        {

            collection.Insert(entity);

        }

        public void Update(TEntity entity)
        {
            if (entity.Id == null)
            {
                Create(entity);
                return;
            }

            collection.Save(entity);
        }

        public void Remove(Guid id)
        {
            collection.Remove(Query.EQ("_id", id));
        }

        public IList<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return collection
            .AsQueryable<TEntity>()
            .Where(predicate.Compile())
            .ToList();
        }

        public IList<TEntity> GetAll()
        {
            return collection.FindAllAs<TEntity>().ToList();
        }

        public TEntity Get(Guid id)
        {
            return collection.FindOneByIdAs<TEntity>(id);
        }

        #region Private Helper Methods  
        private void GetDatabase()
        {
            var client = new MongoClient(GetConnectionString());
            var session = client.StartSession();

            var server = client.GetServer();

            database = server.GetDatabase(GetDatabaseName());
        }

        private string GetConnectionString()
        {
            return ConfigurationManager
            .AppSettings
            .Get("MongoDbConnectionString")
            .Replace("{ DB_NAME}", GetDatabaseName());
        }

        private string GetDatabaseName()
        {
            return ConfigurationManager
            .AppSettings
            .Get("MongoDbDatabaseName");
        }

        private void GetCollection()
        {
            collection = database
            .GetCollection<TEntity>(typeof(TEntity).Name);
        }

        #endregion
    }
}
