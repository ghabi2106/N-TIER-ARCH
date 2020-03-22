namespace DAL_Data_Access_Layer_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Equipment
    {
        public int Id { get; set; }

        public int SerialNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte[] Image { get; set; }

        public DateTime NextControlDate { get; set; }
    }
}
