using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using BookLibrary.Entities;

namespace BookLibrary.BLL.Repositories
{
    public class BaseMongoRepository<TEntity, IDT> : IBaseMongoRepository<TEntity, IDT> where TEntity : BaseEntity
    {

        MongoClient client;
        MongoServer server;
        public MongoDatabase database;
        private MongoCollection<TEntity> collection;


        public BaseMongoRepository()
        {
            ConfigConnectionDataBase();
            GetCollection();
        }

        public List<TEntity> All()
        {
            return collection.FindAllAs<TEntity>().ToList();
        }

        public TEntity Create(TEntity entity)
        {
            collection.Save(entity);
            return entity;
        }

        public TEntity FindById(IDT id)
        {
            var queryFilter = Query<TEntity>.EQ(x => x._id, id.ToString());
            return collection.FindOne(queryFilter);
        }

        public void Remove(IDT id)
        {
            var queryFilter = Query<TEntity>.EQ(x => x._id, id.ToString());
            collection.Remove(queryFilter);
        }

        public void Update(TEntity entity)
        {
            var queryFilter = Query<TEntity>.EQ(x => x._id, entity._id);
            var operation = Update<TEntity>.Replace(entity);

            collection.Update(queryFilter, operation);
        }


        private void GetCollection()
        {
            collection = database.GetCollection<TEntity>(typeof(TEntity).Name.ToLower());
        }

        private void ConfigConnectionDataBase()
        {
            client = new MongoClient("mongodb://localhost:27017");
            server = client.GetServer();
            database = server.GetDatabase("book_library");
        }
    }
}
