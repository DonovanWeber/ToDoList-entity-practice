using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly ToDoListContext _db;

    public CategoriesController(ToDoListContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Category> model = _db.Categories.ToList();
      return View(_db.Items.ToList());
    }

    
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Category category)
    {
        _db.Categories.Add(category);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id) 
    {
      var thisCategory = _db.Categories
                .Include(category => category.JoinEntities)
                .ThenInclude(join => join.Item)
                .FirstOrDefault(category => category.CategoryId == id);
      // var listOfDueDates = _db.Items
      //     .Include(item => item.JoinEntities)
      //     .ThenInclude(join => join.Item)
      //     .ThenInclude(join => join.DueDate);
          
      // ViewBag.DueDate = listOfDueDates.OrderBy(item => item.DueDate);

            return View(thisCategory);
    }

    
    public ActionResult Edit(int id)
    {
      Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    [HttpPost]
    public ActionResult Edit(Category category)
    {
      _db.Entry(category).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}