namespace ProductlineApp.Shared.Models.Allegro;

public class AllegroProductParametersResponse
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Type { get; set; }

    public bool Required { get; set; }

    public string Unit { get; set; }

    public ParameterRestrictions Restrictions { get; set; }

    public IEnumerable<DictionaryItem>? Dictionary { get; set; }

    public class ParameterRestrictions
    {
        public int? Min { get; set; }

        public int? Max { get; set; }

        public bool? Range { get; set; }

        public int? Precision { get; set; }

        public int? MinLength { get; set; }

        public int? MaxLength { get; set; }

        public int? AllowedNumberOfValues { get; set; }

        public bool? MultipleChoices { get; set; }
    }

    public class DictionaryItem
    {
        public string Id { get; set; }

        public string Value { get; set; }
    }
}
