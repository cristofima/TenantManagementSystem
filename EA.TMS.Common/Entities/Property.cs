using EA.TMS.Common.Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EA.TMS.Common.Entities
{
    [Description("To store Property information")]
    [Table("Property")]
    public class Property : BaseEntity
    {
        [Key]
        public int ID { get; set; }

        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
    }
}