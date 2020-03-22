using BLL_Business_Logic_Layer_.Library;
using BOL_Business_Objects_Layer_;
using DAL_Data_Access_Layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Business_Logic_Layer_
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;

        }

        public IQueryable<EquipmentDto> GetWithPagination(string sortOrder, string searchString)
        {
            return _equipmentRepository.GetWithPagination(sortOrder, searchString);
        }

        public EquipmentDto GetById(int id)
        {
            var equipment = _equipmentRepository.GetById(id);
            var equipmentDto = new EquipmentDto()
            {
                Id = equipment.Id,
                SerialNumber = equipment.SerialNumber,
                Name = equipment.Name,
                NextControlDate = equipment.NextControlDate,
                Image = equipment.Image
            };
            return equipmentDto;
        }

        public int Insert(EquipmentDto equipmentDto)
        {
            var equipment = new Equipment()
            {
                Id = equipmentDto.Id,
                SerialNumber = equipmentDto.SerialNumber,
                Name = equipmentDto.Name,
                NextControlDate = equipmentDto.NextControlDate,
                Image = equipmentDto.Image
            };
            _equipmentRepository.Insert(equipment);
            _equipmentRepository.SaveChanges();
            return equipment.Id;
        }

        public int Update(EquipmentDto equipmentDto)
        {
            var equipment = new Equipment()
            {
                Id = equipmentDto.Id,
                SerialNumber = equipmentDto.SerialNumber,
                Name = equipmentDto.Name,
                NextControlDate = equipmentDto.NextControlDate,
                Image = equipmentDto.Image
            };
            int rows = _equipmentRepository.SaveChanges();
            return rows;
        }

        public int Delete(EquipmentDto equipmentDto)
        {
            var equipment = new Equipment()
            {
                Id = equipmentDto.Id,
                SerialNumber = equipmentDto.SerialNumber,
                Name = equipmentDto.Name,
                NextControlDate = equipmentDto.NextControlDate,
                Image = equipmentDto.Image
            };
            _equipmentRepository.Remove(equipment);
            int rows = _equipmentRepository.SaveChanges();
            return rows;
        }
    }

    public interface IEquipmentService
    {
        IQueryable<EquipmentDto> GetWithPagination(string sortOrder, string searchString);
        EquipmentDto GetById(int id);
        int Insert(EquipmentDto equipmentDto);
        int Update(EquipmentDto equipmentDto);
        int Delete(EquipmentDto equipmentDto);
    }
}
