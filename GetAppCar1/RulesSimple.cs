using System;

namespace GetAppCar1
{
    public class RulesSimple
    {
        public int Id { get; set; }
        public string Parameter { get; set; }
        public string ParameterValue { get; set; }
        public string Attribute { get; set; }
        public string AttributeValue { get; set; }
        public ComparisonOperation Comparison { get; set; }
        public bool Used { get; set; } = false;

        public RulesSimple(int id, string parameter, string parameterValue, string attribute, string attributeValue, string comparison)
        {
            Id = id;
            Parameter = parameter;
            ParameterValue = parameterValue;
            Attribute = attribute;
            AttributeValue = attributeValue;
            switch (comparison)
            {
                case "Equals":
                    Comparison = ComparisonOperation.Equals;
                    break;
                case "NotEquals":
                    Comparison = ComparisonOperation.NotEquals;
                    break;
                case "More":
                    Comparison = ComparisonOperation.More;
                    break;
                case "Less":
                    Comparison = ComparisonOperation.Less;
                    break;
                default:
                    throw new Exception($"Operation of comparison called '{comparison}' doesn't exist.");
            }
            Used = false;
        }
    }
}
