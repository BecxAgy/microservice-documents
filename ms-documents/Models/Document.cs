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
        public string? Name { get; set; } = null;
        [BsonElement("created_at")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? Created_at { get; set; }   
        public byte[] File { get; set; } 
    }
}
