using BuberDinner.Domain.Common.Menu.ValueObjects;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(MenuSectionId id, string? name, string? description) : base(id)
    {
        Name = name;
        Description = description;
    }
    public static MenuSection Create(string? name, string? description)
    {
        return new MenuSection(MenuSectionId.CreateUnique(), name, description);
    }
}
