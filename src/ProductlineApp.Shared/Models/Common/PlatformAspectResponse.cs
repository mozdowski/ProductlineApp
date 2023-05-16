namespace ProductlineApp.Shared.Models.Common;

public class PlatformAspectResponse
{
    public string Name { get; set; }

    public string DataType { get; set; }

    public bool IsRequired { get; set; }

    public IEnumerable<string>? Values { get; set; }
}
