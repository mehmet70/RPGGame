using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Warrior : Character
    {
        public Warrior(string name) : base(name)
        {
            name = name;
            setClassAttributes(baseAttribute);
        }

        Dictionary<string, int> baseAttribute = new Dictionary<string, int>()
            {
                { "strength", 5},
                { "dexterity", 2},
                { "intelligence", 1}
            };
        Dictionary<string, int> levelUpAttribute = new Dictionary<string, int>()
            {
                { "strength", 3},
                { "dexterity", 2},
                { "intelligence", 1}
            };

        List<weaponType> availableWeapons = new List<weaponType>()
            {
                { weaponType.Axe },
                { weaponType.Hammer },
                { weaponType.Sword }
            };

        List<armorType> availableArmorType = new List<armorType>()
        {
            { armorType.Mail },
            { armorType.Plate }
        };

        /// <summary>
        /// execute's levelUpCharacter and by doing that also sends the levelUpAttribute of the Warrior class
        /// </summary>
        public void levelUp()
        {
            levelUpCharacter(levelUpAttribute);
        }
        public Dictionary<string, int> getBaseAttribute()
        {
            return this.baseAttribute;
        }
        public Dictionary<string, int> getlevelUpAttribute()
        {
            return this.baseAttribute;
        }

        public override List<weaponType> getAvailableWeaponTypes()
        {
            return availableWeapons;
        }
        public override List<armorType> getAvailableArmorTypes()
        {
            return availableArmorType;
        }

        /// <summary>
        /// Sets Base dps to 1 if there is no weapon. If there is a weapon, it gets the dps and multiplies is by 1 + (strength / 100)
        /// </summary>
        /// <returns>damage</returns>
        public override double getDamage()
        {
            double damage;
            Weapon currentWeapon = (Weapon)this.getInventory().getEquipedItems()[itemSlot.Weapon];
            if (currentWeapon == null)
            {
                damage =(double)1 * ((double)1 + ((double)this.getTotalAttributes()["strength"] / (double)100));
            }
            else
            {
                damage = (double)currentWeapon.getDamagePerSecond() * ((double)1 + ((double)getTotalAttributes()["strength"] / (double)100));
            }
            return (double)damage;
        }
    }
}
