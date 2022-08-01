using System.Collections.Generic;
using System.Linq;
using System;
using System.Web;

namespace ToDoList.Models
{
  public class Item
  {
    public Item()
    {
      this.JoinEntities = new HashSet<CategoryItem>();
    }
    public int ItemId { get; set; }
    public string Description { get; set; }
    private bool _Completed = false;
    public bool Completed { 
      get{return _Completed;} 
      set{_Completed = value;}
      }
    public DateTime DueDate { get; set; }
    // private bool _completed = false;
    // public bool Completed 
    // {
    //   get{ return _completed; }
    //   set{ _completed = value; }

    // }
    public virtual ICollection<CategoryItem> JoinEntities { get; }
  }
}
