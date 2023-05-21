namespace Publisher;

public class ProductCreatedNotification : INotification
{
    public ProductCreatedNotification(int id, string? name, string? description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public int Id { get; private set; }
    public string? Name { get; private set; }
    public string? Description { get; private set; }
}
