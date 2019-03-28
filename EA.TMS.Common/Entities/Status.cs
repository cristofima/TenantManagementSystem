using EA.TMS.Common.Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EA.TMS.Common.Entities
{
    [Description("To store Status")]
    [Table("Status")]
    public class Status : BaseEntity
    {
        [Key]
        public int ID { get; set; }

        public string Description { get; set; }
    }
}