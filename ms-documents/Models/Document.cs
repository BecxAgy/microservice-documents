using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Reflection.Metadata;

namespace ms_documents.Models
{
    public class Document
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id {  get; set; }
        [BsonElement("Name")]
        public string? name { get; set; } = null;
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? created_at { get; set; }   
        public string? file { get; set; } 
    }
}
