using System;

namespace GetAppCar1
{
    public class RulesComplex
    {
        public int Id { get; set; }
        public string Parameter1 { get; set; }
        public string ParameterValue1 { get; set; }
        public Operation Operation { get; set; }
        public string Parameter2 { get; set; }
        public string ParameterValue2 { get; set; }
        public string Attribute { get; set; }
        public string AttributeValue { get; set; }
        public ComparisonOperation Comparison { get; set; }
        public bool Used { get; set; }

        public RulesComplex(int id, string parameter1, string parameterValue1, string operation, string parameter2, string parameterValue2, string attribute, string attributeValue, string comparison)
        {
            Id = id;
            Parameter1 = parameter1;
            ParameterValue1 = parameterValue1;
            switch (operation)
            {
                case "And":
                    Operation = Operation.And;
                    break;
                case "Or":
                    Operation = Operation.Or;
                    break;
                default:
                    throw new Exception($"Operation called '{operation}' doesn't exist.");
            }
            Parameter2 = parameter2;
            ParameterValue2 = parameterValue2;
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
