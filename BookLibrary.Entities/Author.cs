using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookLibrary.Entities
{
    public class Author : BaseEntity
    {

        [BsonElement("Name")]
        public string Name { get; set; }


        [BsonElement("Nationality")]
        public string Nationality { get; set; }

    }
}
