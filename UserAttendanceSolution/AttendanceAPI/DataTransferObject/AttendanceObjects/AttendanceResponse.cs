using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AttendanceAPI.DataTransferObject.AttendanceObjects
{
    public class AttendanceResponse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Date { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }
    }
}
