namespace ProductlineApp.Application.Common.Platforms.Ebay.DTO;

public class EbayLocationsDtoResponse
{
    public IEnumerable<EbayLocationDto> Locations { get; set; }

    public class EbayLocationDto
    {
        public string Key { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
