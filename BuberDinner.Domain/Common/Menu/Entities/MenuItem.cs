using BuberDinner.Domain.Common.Menu.ValueObjects;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.Menu.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
       public string? Name { get; private set; }
    public string? Description { get; private set; }
    
    

    public MenuItem(MenuItemId id,string? name,string? description) : base(id)
    {
        Name = name;
        Description = description;
    }

    public static MenuItem Create(string? name, string? description)
    {
        return new MenuItem(MenuItemId.CreateUnique(), name, description);
    }

 
}