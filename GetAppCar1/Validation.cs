using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GetAppCar1
{
    public class Validation
    {
        protected List<string> _parameters = new List<string>() { "Бюджет", "Электро", "Бензин", "Комфорт", "Большая семья", "Отечественная", "Стаж водителя", "С салона" };

        public Car ParseParametersToAttributes(string result, List<Car> cars, List<RulesSimple> simpleRules, List<RulesComplex> complexRules)
        {
            var parameters = result.Split(';');

            foreach (var parameter in simpleRules)
            {
                if (parameters.Any(x => x == parameter.Parameter) && parameter.ParameterValue == "1")
                {
                    switch (parameter.Comparison)
                    {
                        case ComparisonOperation.Equals:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (cars[i].Attributes[parameter.Attribute] != parameter.AttributeValue)
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                        case ComparisonOperation.NotEquals:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (cars[i].Attributes[parameter.Attribute] == parameter.AttributeValue)
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                        case ComparisonOperation.More:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (int.Parse(cars[i].Attributes[parameter.Attribute]) < int.Parse(parameter.AttributeValue))
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                        case ComparisonOperation.Less:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (int.Parse(cars[i].Attributes[parameter.Attribute]) > int.Parse(parameter.AttributeValue))
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                    }
                }
                else if (parameters.Any(x => x.Remove(0, 1) == parameter.Parameter) && parameter.ParameterValue == "0")
                {
                    switch (parameter.Comparison)
                    {
                        case ComparisonOperation.Equals:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (cars[i].Attributes[parameter.Attribute] != parameter.AttributeValue)
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                        case ComparisonOperation.NotEquals:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (cars[i].Attributes[parameter.Attribute] == parameter.AttributeValue)
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                        case ComparisonOperation.More:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (int.Parse(cars[i].Attributes[parameter.Attribute]) < int.Parse(parameter.AttributeValue))
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                        case ComparisonOperation.Less:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (int.Parse(cars[i].Attributes[parameter.Attribute]) > int.Parse(parameter.AttributeValue))
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                    }
                }
            }
            foreach (var parameter in complexRules)
            {
                if (parameters.Any(x => x == parameter.Parameter1) && parameter.ParameterValue1 == "1" && parameters.Any(x => x == parameter.Parameter2) && parameter.ParameterValue2 == "1")
                {
                    switch (parameter.Comparison)
                    {
                        case ComparisonOperation.Equals:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (cars[i].Attributes[parameter.Attribute] != parameter.AttributeValue)
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                        case ComparisonOperation.NotEquals:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (cars[i].Attributes[parameter.Attribute] == parameter.AttributeValue)
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                        case ComparisonOperation.More:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (int.Parse(cars[i].Attributes[parameter.Attribute]) < int.Parse(parameter.AttributeValue))
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                        case ComparisonOperation.Less:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (int.Parse(cars[i].Attributes[parameter.Attribute]) > int.Parse(parameter.AttributeValue))
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                    }
                }
                else if (parameters.Any(x => x.Remove(0, 1) == parameter.Parameter1) && parameter.ParameterValue1 == "0" && parameters.Any(x => x == parameter.Parameter2) && parameter.ParameterValue2 == "1")
                {
                    switch (parameter.Comparison)
                    {
                        case ComparisonOperation.Equals:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (cars[i].Attributes[parameter.Attribute] != parameter.AttributeValue)
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                        case ComparisonOperation.NotEquals:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (cars[i].Attributes[parameter.Attribute] == parameter.AttributeValue)
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                        case ComparisonOperation.More:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (int.Parse(cars[i].Attributes[parameter.Attribute]) < int.Parse(parameter.AttributeValue))
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                        case ComparisonOperation.Less:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (int.Parse(cars[i].Attributes[parameter.Attribute]) > int.Parse(parameter.AttributeValue))
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                    }
                }
                else if (parameters.Any(x => x.Remove(0, 1) == parameter.Parameter1) && parameter.ParameterValue1 == "0" && parameters.Any(x => x.Remove(0, 1) == parameter.Parameter2) && parameter.ParameterValue2 == "0")
                {
                    switch (parameter.Comparison)
                    {
                        case ComparisonOperation.Equals:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (cars[i].Attributes[parameter.Attribute] != parameter.AttributeValue)
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                        case ComparisonOperation.NotEquals:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (cars[i].Attributes[parameter.Attribute] == parameter.AttributeValue)
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                        case ComparisonOperation.More:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (int.Parse(cars[i].Attributes[parameter.Attribute]) < int.Parse(parameter.AttributeValue))
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                        case ComparisonOperation.Less:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (int.Parse(cars[i].Attributes[parameter.Attribute]) > int.Parse(parameter.AttributeValue))
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                    }
                }
                else if (parameters.Any(x => x == parameter.Parameter1) && parameter.ParameterValue1 == "1" && parameters.Any(x => x.Remove(0, 1) == parameter.Parameter2) && parameter.ParameterValue2 == "0")
                {
                    switch (parameter.Comparison)
                    {
                        case ComparisonOperation.Equals:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (cars[i].Attributes[parameter.Attribute] != parameter.AttributeValue)
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                        case ComparisonOperation.NotEquals:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (cars[i].Attributes[parameter.Attribute] == parameter.AttributeValue)
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                        case ComparisonOperation.More:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (int.Parse(cars[i].Attributes[parameter.Attribute]) < int.Parse(parameter.AttributeValue))
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                        case ComparisonOperation.Less:
                            for (var i = cars.Count - 1; i >= 0; i--)
                            {
                                if (int.Parse(cars[i].Attributes[parameter.Attribute]) > int.Parse(parameter.AttributeValue))
                                {
                                    cars.RemoveAt(i);
                                }
                            }
                            break;
                    }
                }
            }
            return cars[0];
        }
    }
}