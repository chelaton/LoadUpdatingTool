using Microsoft.Spatial;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadUpdatingTool.Data.Entity
{
    public class ServicePoint
    {
        [Column("gid")]
        public int Id { get; set; } 
        [Column("IDENTIFICATION")]
        public string? ServicePointName { get; set;}
        [Column("CONVERSION_INFO")]
        public string? ConversationInfo { get; set; }
        //[Column("LOCATION")]
        //public Geometry? Location { get; set; }
    }
}
