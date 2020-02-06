using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace On.MongoMigrations.DAL.Configs
{
    public abstract class MongoDbClassMap<T>
    {
        protected MongoDbClassMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
                BsonClassMap.RegisterClassMap<T>(Map);
        }

        public abstract void Map(BsonClassMap<T> cm);
    }
}
