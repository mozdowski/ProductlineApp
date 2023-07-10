namespace ProductlineApp.Shared.Models.Allegro;

public class ReturnPoliciesResponse
{
    public List<ReturnPolicy> ReturnPolicies { get; set; }

    public class ReturnPolicy
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
