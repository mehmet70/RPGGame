using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Character
    {
        private string name;
        private int level;
        private Dictionary<string, int> totalAttributes = new Dictionary<string, int>();
        private Inventory inventory = new Inventory();
        public Character(string name)
        {
            this.name = name;
            level = 1;
        }

        public string getName()
        {
            return this.name;
        }

        public int getLevel()
        {
            return this.level;
        }
        public void setTotalIntelligenceValue (int newIntelligenceValue)
        {
            this.totalAttributes["intelligence"] = newIntelligenceValue;
        }
        public void setTotalStrengthValue(int newStrengthValue)
        {
            this.totalAttributes["strength"] = newStrengthValue;
        }
        public void setTotalDexterityValue(int newDexterityValue)
        {
            this.totalAttributes["dexterity"] = newDexterityValue;
        }

        /// <summary>
        /// Setts classAttributes 
        /// </summary>
        /// <param name="classAttributes"></param>
        public void setClassAttributes(Dictionary<string, int> classAttributes)
        {
            totalAttributes = classAttributes;
        }
        /// <summary>
        /// Gets the current attributes of the character and adds the correct points with the given levelUpAttributes
        /// </summary>
        /// <param name="levelUpAttribute"></param>
        public void levelUpCharacter(Dictionary<string, int> levelUpAttribute)
        {
            this.totalAttributes["strength"] = totalAttributes["strength"] + levelUpAttribute["strength"];
            this.totalAttributes["dexterity"] = totalAttributes["dexterity"] + levelUpAttribute["dexterity"];
            this.totalAttributes["intelligence"] = totalAttributes["intelligence"] + levelUpAttribute["intelligence"];
            this.level++;
        }
        /// <summary>
        /// returns the totalAttributes of the character
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> getTotalAttributes()
        {
            return this.totalAttributes;
        }
        /// <summary>
        /// returns available Weapons, this is different for every child class of Character.
        /// </summary>
        /// <returns></returns>
        abstract public List<weaponType> getAvailableWeaponTypes();
        public virtual double getDamage()
        {
            return 0;
        }
        abstract public List<armorType> getAvailableArmorTypes();
        
        /// <summary>
        /// Returns the inventory of the character object
        /// </summary>
        /// <returns></returns>
        public Inventory getInventory()
        {
            return this.inventory;
        }
        /// <summary>
        /// ConsoleWrite's character stats
        /// </summary>
        public void displayTotalStats()
        {
            string name = this.getName();
            int level = this.getLevel();
            int intelligence = this.getTotalAttributes()["intelligence"];
            int strength = this.getTotalAttributes()["strength"];
            int dexterity = this.getTotalAttributes()["dexterity"];
            double damage = this.getDamage();

            Console.WriteLine(" Name: " + name + " level: " + level + " Itelligencce: " + intelligence + " Dexterity: " + dexterity + " strength: " + strength + " Damage: " + damage );
        }

    }
}
