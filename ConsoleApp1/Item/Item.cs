using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Item
    {
        private string name;
        private int level;
        private itemSlot itemSlot;

        public Item(string name, int level, itemSlot itemSlot)
        {
            this.name = name;
            this.level = level;
            this.itemSlot = itemSlot;
        }

        public string getName()
        {
            return name;
        }
        public int getLevel()
        {
            return level;
        }
        public itemSlot getItemSlot()
        {
            return itemSlot;
        }
        public virtual weaponType getWeaponTypeFromParent()
        {
            return weaponType.Wand;
        }

        public virtual Dictionary<string, int> getArmorAttributes()
        {
            return new Dictionary<string, int>();
        }
        public virtual armorType getArmorTypeFromParent()
        {
            return armorType.Cloth;
        }
    }

}
