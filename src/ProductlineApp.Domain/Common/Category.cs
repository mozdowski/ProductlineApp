using System.Collections.ObjectModel;

namespace ProductlineApp.Domain.Common;

public class Category : Entity
{
    public Category(
        Guid id,
        string name,
        Category category)
        : base(id)
    {
        this.Name = name;
        this.Parent = category;
        this.Children = new HashSet<Category>();
    }

    public string Name { get; private set; }

    public Category Parent { get; private set; }

    public IReadOnlyCollection<Category> Siblings
    {
        get
        {
            var parentChildren = this.Parent.Children.Where(cat => cat != this).ToList();
            return new ReadOnlyCollection<Category>(parentChildren);
        }
    }

    public ICollection<Category> Children { get; private set; }

    public void AddChild(Category category)
    {
        this.Children.Add(category);
    }

    public void AddChildren(List<Category> children)
    {
        this.Children = this.Children.Concat(children).ToHashSet();
    }
}
