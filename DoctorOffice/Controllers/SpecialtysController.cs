using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DoctorOffice.Models;
using System.Collections.Generic;
using System.Linq;

namespace DoctorOffice.Controllers
{
  public class SpecialtysController : Controller
  {
    private readonly DoctorOfficeContext _db;

    public SpecialtysController(DoctorOfficeContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Specialty> model = _db.Specialtys.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Specialty specialty)
    {
      _db.Specialtys.Add(specialty);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisSpecialty = _db.Specialtys
          .Include(specialty => specialty.JoinEntities2)
          .ThenInclude(join => join.Doctor)
          .FirstOrDefault(specialty => specialty.SpecialtyId == id);
      return View(thisSpecialty);
    } 
    public ActionResult Edit(int id)
    {
      var thisSpecialty = _db.Specialtys.FirstOrDefault(specialty => specialty.SpecialtyId == id);
      return View(thisSpecialty);
    }

    [HttpPost]
    public ActionResult Edit(Specialty specialty)
    {
      _db.Entry(specialty).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisSpecialty = _db.Specialtys.FirstOrDefault(specialty => specialty.SpecialtyId == id);
      return View(thisSpecialty);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisSpecialty = _db.Specialtys.FirstOrDefault(specialty => specialty.SpecialtyId == id);
      _db.Specialtys.Remove(thisSpecialty);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }  
}  