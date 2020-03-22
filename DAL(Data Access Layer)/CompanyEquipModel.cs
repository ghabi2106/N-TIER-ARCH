namespace DAL_Data_Access_Layer_
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CompanyEquipModel : DbContext
    {
        public CompanyEquipModel()
            : base("name=CompanyEquipConnection")
        {
        }

        public virtual DbSet<Equipment> Equipments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
