namespace ProductlineApp.Shared.Models.Allegro;

public class ImpliedWarrantiesResponse
{
    public List<ImpliedWarranty> ImpliedWarranties { get; set; }

    public class ImpliedWarranty
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
