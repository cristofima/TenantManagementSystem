using EA.TMS.Common.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EA.TMS.Common.Entities
{
    [Description("To store Tenant information")]
    [Table("Tenant")]
    public class Tenant : BaseEntity
    {
        [Key]
        public long ID { get; set; }

        public int PropertyID { get; set; }

        [ForeignKey("PropertyID")]
        public virtual Property Property { get; set; }

        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Fax { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
    }
}