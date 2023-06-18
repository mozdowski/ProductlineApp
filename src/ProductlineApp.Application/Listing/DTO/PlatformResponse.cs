using ProductlineApp.Shared.Enums;

namespace ProductlineApp.Application.Listing.DTO;

public class PlatformResponse
{
    public Guid Id { get; set; }

    public PlatformNames Name { get; set; }
}
