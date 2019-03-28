using EA.TMS.Common.Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EA.TMS.Common.Entities
{
    [Description("To store Tasks related to particular Job")]
    [Table("JobTask")]
    public class JobTask : BaseEntity
    {
        [Key]
        public long ID { get; set; }

        public long JobID { get; set; }

        [ForeignKey("JobID")]
        public virtual Job Job { get; set; }

        [MaxLength(500)]
        public string TaskDescription { get; set; }
    }
}