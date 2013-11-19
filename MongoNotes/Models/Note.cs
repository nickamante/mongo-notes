using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoNotes.Models
{
    public class Note
    {
        public Note() {
            Date = DateTime.UtcNow;
        }

        [BsonId(IdGenerator=typeof(CombGuidGenerator))]
        public Guid Id { get; set; }

        [BsonElement("Note")]
        public string Text { get; set; }

        private DateTime _date;

        [BsonElement("Date")]
        public DateTime Date { 
            get{ return _date.ToLocalTime(); }
            set { _date = value.ToUniversalTime(); }
        }
    }
}