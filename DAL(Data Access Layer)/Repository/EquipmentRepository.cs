using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL_Business_Objects_Layer_;

namespace DAL_Data_Access_Layer_
{
    public class EquipmentRepository : BaseRepository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(CompanyEquipModel context) : base(context) { }

        public IQueryable<EquipmentDto> GetWithPagination(string sortOrder, string searchString)
        {
            var query = this.context.Equipments.Select(i => new EquipmentDto
            {
                SerialNumber = i.SerialNumber,
                Name = i.Name,
                Image = i.Image,
                NextControlDate = i.NextControlDate,
                Id = i.Id
            });
            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    query = query.OrderByDescending(s => s.Name);
                    break;
                case "serialNumber_desc":
                    query = query.OrderBy(s => s.SerialNumber);
                    break;
                case "date_desc":
                    query = query.OrderByDescending(s => s.NextControlDate);
                    break;
                default:  // Name ascending 
                    query = query.OrderBy(s => s.Name);
                    break;
            }
            return query;
        }
    }

    public interface IEquipmentRepository : IRepository<Equipment>
    {
        IQueryable<EquipmentDto> GetWithPagination(string sortOrder, string searchString);
    }
}
