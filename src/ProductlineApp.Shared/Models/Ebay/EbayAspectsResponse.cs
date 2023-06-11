namespace ProductlineApp.Shared.Models.Ebay;

public class EbayAspectsResponse
{
    public List<Aspect> Aspects { get; set; }

    public class AspectConstraint
    {
        public List<string> AspectApplicableTo { get; set; }

        public string AspectDataType { get; set; }

        public bool AspectEnabledForVariations { get; set; }

        public string AspectFormat { get; set; }

        public int AspectMaxLength { get; set; }

        public string AspectMode { get; set; }

        public bool AspectRequired { get; set; }

        public string AspectUsage { get; set; }

        public string ExpectedRequiredByDate { get; set; }

        public string ItemToAspectCardinality { get; set; }
    }

    public class ValueConstraint
    {
        public string ApplicableForLocalizedAspectName { get; set; }

        public List<string> ApplicableForLocalizedAspectValues { get; set; }
    }

    public class AspectValue
    {
        public string LocalizedValue { get; set; }

        public List<ValueConstraint> ValueConstraints { get; set; }
    }

    public class RelevanceIndicator
    {
        public int SearchCount { get; set; }
    }

    public class Aspect
    {
        public AspectConstraint AspectConstraint { get; set; }

        public List<AspectValue>? AspectValues { get; set; }

        public string LocalizedAspectName { get; set; }

        public RelevanceIndicator RelevanceIndicator { get; set; }
    }
}
