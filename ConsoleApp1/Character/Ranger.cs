using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Ranger : Character
    {
        public Ranger(string name) : base(name)
        {
            name = name;
            setClassAttributes(baseAttribute);
        }
        Dictionary<string, int> baseAttribute = new Dictionary<string, int>()
            {
                { "strength", 1},
                { "dexterity", 7},
                { "intelligence", 1}
            };
        Dictionary<string, int> levelUpAttribute = new Dictionary<string, int>()
            {
                { "strength", 1},
                { "dexterity", 5},
                { "intelligence", 1}
            };
        List<weaponType> availableWeapons = new List<weaponType>()
        {
            { weaponType.Bow }
        };

        List<armorType> availableArmorType = new List<armorType>()
        {
            { armorType.Leather },
            { armorType.Mail }
        };

        /// <summary>
        /// execute's levelUpCharacter and by doing that also sends the levelUpAttribute of the Ranger class
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
        public override double getDamage()
        {
            /// <summary>
            /// Sets Base dps to 1 if there is no weapon. If there is a weapon, it gets the dps and multiplies is by 1 + (dexterity / 100)
            /// </summary>
            /// <returns>damage</returns>
            double damage;
            Weapon currentWeapon = (Weapon)this.getInventory().getEquipedItems()[itemSlot.Weapon];
            if (currentWeapon == null)
            {
                damage = (double)1 * ((double)1 + ((double)this.getTotalAttributes()["dexterity"] / (double)100));
            }
            else
            {
                damage = (double)currentWeapon.getDamagePerSecond() * ((double)1 + ((double)getTotalAttributes()["dexterity"] / (double)100));
            }
            return damage;
        }
    }
}
