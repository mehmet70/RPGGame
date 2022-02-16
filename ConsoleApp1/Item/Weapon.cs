using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Weapon : Item
    {

        private weaponType weaponType;
        private Dictionary<string, double> weaponAttributes;
        private double damagePerSecond;


        public Weapon(string name, int level, itemSlot itemSlot, weaponType weaponType, Dictionary<string, double> weaponAttributes) : base(name, level, itemSlot)
        {
            this.weaponType = weaponType;
            this.weaponAttributes = weaponAttributes;
            this.damagePerSecond = weaponAttributes["Damage"] * weaponAttributes["AttackSpeed"];
        }

        public weaponType getWeaponType()
        {
            return weaponType;
        }
        public Dictionary<string, double> getWeaponAttributes()
        {
            return weaponAttributes;
        }

        public double getDamagePerSecond()
        {
            return damagePerSecond;
        }
        public override weaponType getWeaponTypeFromParent()
        {
            return weaponType;
        }
    }
}
