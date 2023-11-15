using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessShop.ServiceLayer.Util
{
    public class VelicinaAttr : Attribute
    {
        public int Id { get; private set; }
        public string Naziv { get; private set; }
        internal VelicinaAttr(int id, string naziv)
        {
            this.Id = id;
            this.Naziv = naziv;
        }
    }

    public static class Velicine
    {
        public static VelicinaAttr GetAttr(Velicina v)
        {
            return (VelicinaAttr)Attribute.GetCustomAttribute(ForValue(v), typeof(VelicinaAttr));
        }

        private static MemberInfo ForValue(Velicina v)
        {
            return typeof(Velicina).GetField(Enum.GetName(typeof(Velicina), v));
        }

        public static List<VelicinaAttr> GetVelicinaAttrs()
        {
            var velicinaAttrs = new List<VelicinaAttr>();
            foreach (var velicina in Enum.GetValues(typeof(Velicina)))
            {
                velicinaAttrs.Add(GetAttr((Velicina)velicina));
            }
            return velicinaAttrs;
        }
    }
    public enum  Velicina
    {
        [VelicinaAttr(11, "36")] SIZE_36,
        [VelicinaAttr(12, "37")] SIZE_37,
        [VelicinaAttr(13, "38")] SIZE_38,
        [VelicinaAttr(14, "39")] SIZE_39,
        [VelicinaAttr(15, "40")] SIZE_40,
        [VelicinaAttr(16, "41")] SIZE_41,
        [VelicinaAttr(17, "42")] SIZE_42,
        [VelicinaAttr(18, "43")] SIZE_43,
        [VelicinaAttr(19, "44")] SIZE_44,
        [VelicinaAttr(20, "45")] SIZE_45
    }
}
