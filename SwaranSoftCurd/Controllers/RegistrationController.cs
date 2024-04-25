using Microsoft.AspNetCore.Mvc;
using SwaranSoftCurd.Models;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace SwaranSoftCurd.Controllers
{   
    public class RegistrationController : Controller
    {
        private readonly DatabseContext _db;
        public object state { get; private set; }
        public object city { get; private set; }

        public RegistrationController(DatabseContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Create(int id=0)
        {
            ViewBag.BT = "Save";
            Studentnew obj =new Studentnew();
            //Edit action Perform

            if (id>0)
            {
                //LinQ to fetch data
                var data = (from a in _db.Students where a.Id==id select a).ToList();
                obj.Id = data[0].Id;
                obj.Name = data[0].Name;
                obj.Email = data[0].Email;
                obj.Mobile= data[0].Mobile;
            
                obj.UploadPhoto = data[0].UploadPhoto;
                TempData["UploadPhoto"] = obj.UploadPhoto;

                obj.AboutYourself = data[0].AboutYourself;
                obj.City = data[0].City;
                obj.State = data[0].State;
                //ViewBag --change button dinamicaly 
                ViewBag.BT = "Update";
            }
            //obj.lstHobbies = _db.Hobbies.ToList();
          
            ViewBag.ctr = _db.States.ToList();
            ViewBag.STT = _db.Cities.Where(m => m.SId == obj.City).ToList();
            return View(obj);


        }

        [HttpPost]
        public IActionResult Create(Studentnew _tech, IFormFile file)
        {
            //var fileSize = file.l;
            //if ((fileSize / 1048576.0) > 10)
            //{
            //    // image is too large
            //}

            if (ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }
            else
            {
                string pth = Path.Combine("wwwroot/PICS");
                string FN = Guid.NewGuid().ToString() + "-" + file.FileName;
                string filepath = Path.Combine(pth, FN);
                using (FileStream fs = System.IO.File.Create(filepath))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                //Insert and Update Action perform
                Student _TCH = new Student();
                _TCH.Id = _tech.Id;
                _TCH.Name = _tech.Name;
                _TCH.Email = _tech.Email;
                _TCH.Mobile = _tech.Mobile;
                _TCH.City = _tech.City;
                _TCH.State = _tech.State;
                _TCH.AboutYourself = _tech.AboutYourself;
                _TCH.UploadPhoto = FN;

                if (_tech.Id > 0)
                {
                    if (file != null)
                    {
                        var fileSize = file.Length;
                        var maxFileSizeInBytes = 250 * 1024; // 250 KB
                        if (fileSize > maxFileSizeInBytes)
                        {
                            ModelState.AddModelError("File", "The uploaded image is too large. Please upload an image smaller than 250 KB.");
                            return View(); // Assuming you have a corresponding view for creating student records
                        }

                        string aa = TempData["UploadPhoto"].ToString();
                        //string aa = TempData["UploadPhoto"].ToString();
                        string oldpath = Path.Combine("wwwroot/PICS", aa);
                        if (System.IO.File.Exists(oldpath))
                        {
                            System.IO.File.Delete(oldpath);
                        }
                        _tech.UploadPhoto = FN;

                    }
                    _db.Entry(_TCH).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    TempData["AlertMessage"] = " Data Updated Successfully...!! ";
                    _db.SaveChanges();
                    return RedirectToAction("Show");
                }
                else
                {
                    if (file != null)
                    {

                        _tech.UploadPhoto = FN;
                        _db.Students.Add(_TCH);
                        _db.SaveChanges();
                    }
                    //_db.Students.Add(_TCH);
                }
                TempData["AlertMessage"] = " Registration Successfully...!! ";
                //_db.SaveChanges();
                return RedirectToAction("Show");
            }
        }

        [HttpGet]
        public IActionResult Show()
        {

            //var data = _db.teachers.ToList();
            var data = (from a in _db.Students

                        join b in _db.States 
                        on a.State equals b.SId

                        join c in _db.Cities
                        on a.City equals c.CId

                        into Con
                        from c in Con.DefaultIfEmpty()

                        select new StudentJoin
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Email= a.Email,
                            Mobile= a.Mobile,
                            State = b.SName,
                            City = c.CName,
                            UploadPhoto = a.UploadPhoto,
                            AboutYourself= a.AboutYourself 
                        }

                        ).ToList();
            return View(data);
        }


        public JsonResult GetCity(int A)
        {
            var data = (from a in _db.Cities where a.SId == A select a).ToList();
            return Json(data);
        }

        public IActionResult Delete(int id=0)
        {
            var data=_db.Students.Find(id);
            var aa = data.UploadPhoto;
            string path = Path.Combine("wwwroot/PICS", aa);
            System.IO.File.Delete(path);
            _db.Students.Remove(data);
            _db.SaveChanges();
            TempData["AlertMessage"] = " Deleted Successfully...!! ";
            return RedirectToAction("Show");
        }

        public IActionResult Details(int id)
        {
            var detail = _db.Students.Where(x => x.Id == id).FirstOrDefault();
            return View(detail);
        }
    }
}
