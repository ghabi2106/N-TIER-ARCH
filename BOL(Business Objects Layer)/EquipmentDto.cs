using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BOL_Business_Objects_Layer_
{
    public class EquipmentDto
    {
        public int Id { get; set; }

        [Display(ResourceType = typeof(Resources.Resources), Name = "SerialNumber")]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
            ErrorMessageResourceName = "SerialNumberNumberUnique")]
        [Index(IsUnique = true)]
        public int SerialNumber { get; set; }

        [Display(ResourceType = typeof(Resources.Resources), Name = "Name")]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
            ErrorMessageResourceName = "NameRequired")]
        [StringLength(160)]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Resources.Resources), Name = "Image")]
        public byte[] Image { get; set; }

        [Display(ResourceType = typeof(Resources.Resources), Name = "NextDateControl")]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
            ErrorMessageResourceName = "DateTimeGreaterToday")]
        public DateTime NextControlDate { get; set; }
    }
}
