using System.Collections.Generic;


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
    public DateTime DueDate { get; set; }
    private bool _completed = false;
    public bool Completed 
    {
      get{ return _completed; }
      set{ _completed = value; }

    }
    public virtual ICollection<CategoryItem> JoinEntities { get; }
  }
}
