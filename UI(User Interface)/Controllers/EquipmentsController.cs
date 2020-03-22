using BLL_Business_Logic_Layer_;
using BOL_Business_Objects_Layer_;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace UI_User_Interface_.Controllers
{
    public class EquipmentsController : Controller
    {
        public IEquipmentService equipmentService;

        public EquipmentsController(IEquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;
        }

        // Index: Equipments
        #region Index
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.SerialNumber = sortOrder == "Date" ? "date_desc" : "serialNumber_desc";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var equipments = equipmentService.GetWithPagination(sortOrder, searchString);

            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(equipments.ToPagedList(pageNumber, pageSize));
        }
        #endregion Index

        // Details: Equipments
        #region Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int ID = id ?? 0;
            var equipmentDto = equipmentService.GetById(ID);
            if (equipmentDto == null)
            {
                return HttpNotFound();
            }

            return View(equipmentDto);
        }
        #endregion Details

        // Create: Equipments
        #region Create
        public ActionResult Create()
        {
            EquipmentDto equipmentDto = new EquipmentDto();
            return View(equipmentDto);
        }

        [HttpPost]
        public ActionResult Create(EquipmentDto equipmentDto, HttpPostedFileBase ImageEquip)
        {
            if (ImageEquip != null && ImageEquip.ContentLength > 0)
            {
                equipmentDto.Image = new byte[ImageEquip.ContentLength]; // ImageEquip to store image in binary formate  
                ImageEquip.InputStream.Read(equipmentDto.Image, 0, ImageEquip.ContentLength);
            }
            try
            {
                if (ModelState.IsValid)
                {
                    var inserted = equipmentService.Insert(equipmentDto);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(equipmentDto);
        }
        #endregion

        // Edit: Equipments
        #region Edit      
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int ID = id ?? 0;
            var equipmentDto = equipmentService.GetById(ID);
            if (equipmentDto == null)
            {
                return HttpNotFound();
            }
            return View(equipmentDto);
        }

        [HttpPost]
        public ActionResult Edit(EquipmentDto equipmentDto, HttpPostedFileBase ImageEquip)
        {
            if (ModelState.IsValid)
            {
                if (ImageEquip != null && ImageEquip.ContentLength > 0)
                {
                    equipmentDto.Image = new byte[ImageEquip.ContentLength]; // ImageEquip to store image in binary formate  
                    ImageEquip.InputStream.Read(equipmentDto.Image, 0, ImageEquip.ContentLength);
                }

                /* Other Method : Insert image into folder and insert image path into database and display image in 
                 * view from image folder based on path given(stored) in database. */
                //if (ImageEquip == null)
                //{
                //    string ImageName = System.IO.Path.GetFileName(ImageEquip.FileName); //file2 to store path and url  
                //    string physicalPath = Server.MapPath("~/img/" + ImageName);
                //    // save image in folder  
                //    ImageEquip.SaveAs(physicalPath);
                //    equip.PathPhoto = "img/" + ImageName;
                //}

                var updated = equipmentService.Update(equipmentDto);
                return RedirectToAction("Index");
            }

            return View(equipmentDto);
        }
        #endregion Edit

        // Delete: Equipments
        #region Delete
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            var ID = id ?? 0;
            var equipmentDto = equipmentService.GetById(ID);
            if (equipmentDto == null)
            {
                return HttpNotFound();
            }
            return View(equipmentDto);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var equipmentDto = equipmentService.GetById(id);
                var deleted = equipmentService.Delete(equipmentDto);
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
        #endregion Delete
    }
}