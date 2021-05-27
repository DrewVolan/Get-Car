using System;
using System.Collections.Generic;

namespace GetAppCar1
{
    public class Car
    {
        public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();

        /*public Dictionary<string, string> Brand { get; set; }

        [RusName("Модель")]
        public Dictionary<string, string> Model { get; set; }

        [RusName("Цена")]
        public Dictionary<string, int> Price { get; set; }

        [RusName("Год")]
        public Dictionary<string, int> Year { get; set; }

        [RusName("Тип двигателя")]
        public Dictionary<string, string> Engine { get; set; }

        [RusName("Тип коробки")]
        public Dictionary<string, string> Gearbox { get; set; }

        [RusName("Привод")]
        public Dictionary<string, string> Drive { get; set; }

        [RusName("Тип кузова")]
        public Dictionary<string, string> Body { get; set; }*/

        public Car(string brand, string model, int price, int year, string engine, string gearbox, string drive, string body)
        {
            Attributes.Add("Марка", brand);
            Attributes.Add("Модель", model);
            Attributes.Add("Цена", price.ToString());
            Attributes.Add("Год", year.ToString());
            Attributes.Add("Тип двигателя", engine);
            Attributes.Add("Тип коробки", gearbox);
            Attributes.Add("Привод", drive);
            Attributes.Add("Тип кузова", body);
        }
    }
}

public sealed class RusNameAttribute : Attribute
{
    public string RusName;
    public RusNameAttribute() { }
    public RusNameAttribute(string str)
    {
        RusName = str;
    }
}