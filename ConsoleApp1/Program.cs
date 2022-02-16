using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Warrior warrior = new Warrior("Mehmet");

            Weapon axe = new Weapon("Guardian Axe", 1, itemSlot.Weapon, weaponType.Axe, new Dictionary<string, double>()
            {
                ["Damage"] = 7,
                ["AttackSpeed"] = 1.1,
            });

            Armor plateArmor = new Armor("Cloth Armor", 1, itemSlot.Body, armorType.Plate, new Dictionary<string, int>()
            {
                ["strength"] = 1,
                ["intelligence"] = 0,
                ["dexterity"] = 0
            });

            try
            {
                warrior.getInventory().equipItem(axe, warrior);
                warrior.getInventory().equipItem(plateArmor, warrior);
            }
            catch (InvalidWeaponException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (InvalidArmorException exc) {
                Console.WriteLine(exc.Message);
            }

            var damage = axe.getDamagePerSecond() * (1 + ((warrior.getTotalAttributes()["strength"]) / 100));
            warrior.getInventory().displayInventory();

            warrior.displayTotalStats();

        }
    }
}
