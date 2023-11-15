using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessShop.ServiceLayer.Util
{
    public class PolAttr : Attribute
    {
        public string StringValue { get; private set; }
        public int NumericValue { get; private set; }
        internal PolAttr(string stringValue, int numericValue)
        {
            this.StringValue = stringValue;
            this.NumericValue = numericValue;
        }
    }

    public static class Polovi
    {
        private static PolAttr GetAttr(Pol p)
        {
            return (PolAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(PolAttr));
        }

        private static MemberInfo ForValue(Pol p)
        {
            return typeof(Pol).GetField(Enum.GetName(typeof(Pol), p));
        }

        public static List<PolAttr> GetPolAttrs()
        {
            var polAtrs = new List<PolAttr>();
            foreach (var pol in Enum.GetValues(typeof(Pol)))
            {
                polAtrs.Add(GetAttr((Pol)pol));
            }
            return polAtrs;
        }
    }
    public enum Pol
    {
        [PolAttr("Muški", 1)] MALE,
        [PolAttr("Ženski", 2)] FEMALE,
        [PolAttr("Unisex", 3)] UNISEX
    }
}
