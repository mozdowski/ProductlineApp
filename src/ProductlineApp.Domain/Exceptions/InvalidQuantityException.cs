using ProductlineApp.Domain.Common;

namespace ProductlineApp.Domain.Exceptions;

public class InvalidQuantityException : Exception
{
    private const string ErrorMessage = " has been given invalid quantity number";

    public InvalidQuantityException(Entity entity)
        : base("Entity id: " + entity.Id + ErrorMessage)
    {
    }
}
