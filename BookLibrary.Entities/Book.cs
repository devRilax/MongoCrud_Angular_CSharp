using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookLibrary.Entities
{
    public class Book : BaseEntity
    {
        [BsonElement("Title")]
        public string Title { get; set; }


        [BsonElement("Description")]
        public string Description { get; set; }


        [BsonElement("Year")]
        public int Year { get; set; }


        [BsonElement("Authors")]
        public IEnumerable<Author> Authors { get; set; }
    }
}
