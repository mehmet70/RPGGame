using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Armor : Item
    {
        private armorType armorType;
        private Dictionary<string, int> armorAttributes;

        public Armor(string name, int level, itemSlot itemSlot, armorType armorType, Dictionary<string, int> armorAttributes): base(name, level, itemSlot)
        {
            this.armorType = armorType;
            this.armorAttributes = armorAttributes;
        }
        public armorType getarmorType()
        {
            return armorType;
        }
        public override Dictionary<string, int> getArmorAttributes()
        {
            return armorAttributes;
        }

        public override armorType getArmorTypeFromParent()
        {
            return armorType;
        }
    }
}
