using BuberDinner.Domain.Common.Host.ValueObjects;
using BuberDinner.Domain.Common.Menu.Entities;
using BuberDinner.Domain.Common.Menu.ValueObjects;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.Menu;

public sealed class Menu : AggregateRoot<MenuId>

{
    private readonly List<MenuSection> _sections = new(); 
    private readonly List<DinnerId> _dinners = new();
    private readonly List<MenuReviewId> _reviews = new();

    public Menu(MenuId id) : base(id)
    {
    }

    public string? Name { get; private set; }
    public string? Description { get; private set; } 
    public float AverageRating { get; set; }
        public HostId? HostId { get;}
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    public IReadOnlyList<DinnerId> Dinners => _dinners.AsReadOnly();
    public IReadOnlyList<MenuReviewId> Reviews => _reviews.AsReadOnly();

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; }
    

}