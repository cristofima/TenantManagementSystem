using EA.TMS.Common.Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EA.TMS.Common.Entities
{
    [Description("To store Worker who will be assigned for Job")]
    [Table("JobWorker")]
    public class JobWorker : BaseEntity
    {
        [Key]
        public long ID { get; set; }

        public long JobID { get; set; }

        [ForeignKey("JobID")]
        public virtual Job Job { get; set; }

        public long EmployeeID { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }
    }
}