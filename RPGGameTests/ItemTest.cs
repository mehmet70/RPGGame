using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RPGGameTests
{
    public class ItemTest
    {
        Warrior warrior = new Warrior("mehmet");

        [Fact]

        public void EquipItem_EquipsDesiredWeaponItemIfPossible_ReturnsInvalidWeaponException()
        {
            Weapon axe = new Weapon("Guardian Wand", 2, itemSlot.Weapon, weaponType.Axe, new Dictionary<string, double>()
            {
                ["Damage"] = 50,
                ["AttackSpeed"] = 1,
            });
            Inventory warriorInventory = warrior.getInventory();

            Assert.Throws<InvalidWeaponException>(() => warriorInventory.equipItem(axe, warrior));
        }
        [Fact]
        public void EquipItem_EquipsDesiredArmorItemIfPossible_ReturnsInvalidArmorException()
        {
            Armor plateBodyArmor = new Armor("Plate Body Armor", 2, itemSlot.Body, armorType.Cloth, new Dictionary<string, int>()
            {
                ["strength"] = 100,
                ["intelligence"] = 100,
                ["dexterity"] = 100
            });

            Inventory warriorInventory = warrior.getInventory();

            Assert.Throws<InvalidArmorException>(() => warriorInventory.equipItem(plateBodyArmor, warrior));
        }

        [Fact]
        public void EquipItem_EquipsDesiredWrongWeaponTypeItem_ReturnsInvalidWeaponException()
        {
            Weapon bow = new Weapon("Guardian Wand", 1, itemSlot.Weapon, weaponType.Bow, new Dictionary<string, double>()
            {
                ["Damage"] = 50,
                ["AttackSpeed"] = 1,
            });
            Inventory warriorInventory = warrior.getInventory();

            Assert.Throws<InvalidWeaponException>(() => warriorInventory.equipItem(bow, warrior));
        }

        [Fact]
        public void EquipItem_EquipsDesiredWrongArmorType_ReturnsInvalidArmorException()
        {
            Armor clotArmor = new Armor("Cloth Armor", 1, itemSlot.Body, armorType.Cloth, new Dictionary<string, int>()
            {
                ["strength"] = 100,
                ["intelligence"] = 100,
                ["dexterity"] = 100
            });

            Inventory warriorInventory = warrior.getInventory();

            Assert.Throws<InvalidArmorException>(() => warriorInventory.equipItem(clotArmor, warrior));
        }
        
        [Fact]
        // Didn't know if I had to display a message, so in the code itself it displays a message saying if the weapon is added
        public void equipItem_EquipDesiredWeapon_ShowsSucessMessage()
        {
            Weapon axe = new Weapon("Guardian Wand", 1, itemSlot.Weapon, weaponType.Axe, new Dictionary<string, double>()
            {
                ["Damage"] = 50,
                ["AttackSpeed"] = 1,
            });

            Inventory warriorInventory = warrior.getInventory();

            try
            {
                warriorInventory.equipItem(axe, warrior);
            }
            catch (InvalidArmorException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (InvalidWeaponException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        [Fact]
        // Didn't know if I had to display a message, so in the code itself it displays a message saying if the weapon is added
        public void equipItem_EquipDesiredArmorn_ShowsSucessMessage()
        {
            Armor plateArmor = new Armor("Cloth Armor", 1, itemSlot.Body, armorType.Plate, new Dictionary<string, int>()
            {
                ["strength"] = 100,
                ["intelligence"] = 100,
                ["dexterity"] = 100
            });

            Inventory warriorInventory = warrior.getInventory();

            try
            {
                warriorInventory.equipItem(plateArmor, warrior);
            }
            catch (InvalidArmorException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (InvalidWeaponException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        [Fact]
        public void getTotalDamage_GetDamageAfterCalculationWithoutWeapon_ReturnDamageAfterCalculation()
        {
            double actual = warrior.getDamage();

            double expected = (double)1 * ((double)1 + ((double)5 / (double)100));

            Assert.Equal(expected, actual);

        }


        [Fact]
        public void getTotalDamage_GetDamageAfterCalculationWithWeaponAndArmor_ReturnDamageAfterCalculation()
        {
            double expected = ((double)7 * 1.1) * ((double)1 + ((double)5 / (double)100));

            Weapon axe = new Weapon("Guardian Wand", 1, itemSlot.Weapon, weaponType.Axe, new Dictionary<string, double>()
            {
                ["Damage"] = 7,
                ["AttackSpeed"] = 1.1,
            });

            try
            {
                warrior.getInventory().equipItem(axe, warrior);
            }
            catch (Exception)
            {

                throw;
            }

            //Variable should be declared after the item is equipped, that why I put it here

            double actual = warrior.getDamage();


            Assert.Equal(expected, actual);

        }

        [Fact]
        public void getTotalDamage_GetDamageAfterCalculationWithWeapon_ReturnDamageAfterCalculation()
        {
            double expected = ((double)7 * (double)1.1) * ((double)1 + (((double)5 + (double)1) / (double)100));


            Weapon axe = new Weapon("Guardian Wand", 1, itemSlot.Weapon, weaponType.Axe, new Dictionary<string, double>()
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
            catch (Exception)
            {

                throw;
            }
            
            double actual = warrior.getDamage();


            Assert.Equal(expected, actual);

        }
    }
}
