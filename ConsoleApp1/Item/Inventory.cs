using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Inventory
    {
        /// <summary>
        /// setts the inventory to null, so that the variable's do exist, but are empty untill they are filled.
        /// </summary>
        private Dictionary<itemSlot , Item> equippedItems = new Dictionary<itemSlot, Item>() 
        {
            { itemSlot.Head, null },
            { itemSlot.Body, null },
            { itemSlot.Legs, null },
            { itemSlot.Weapon, null }
        };
        /// <summary>
        /// This function goes  through a couple of if statements. The first one checks if the level is above the character level.
        /// at the start, it will check if the itemtype is a weapon or armor.
        /// After checking the itemType it will check if the character level is below the item level
        /// it will throw a exception depending on what type of item it is.
        /// Then it will check again what type of item it is and loop through available character weapon types,
        /// to check if the item is compatible with the character. If the item is compatible with any of available character weapon types, it will change usable to true.
        /// and equip the item. If it is not compatible it will not change the usable variabe and will throw a InvalidWeaponException.
        /// If the item is an armor, it will do the exact same and throw a InvalidArmorException.
        /// After getting an armor item, this function will also add the attributes of the armor to the character and get get rid of the old attributes that got applied from previous armor.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="character"></param>
        /// <exception cref="InvalidWeaponException"></exception>
        /// <exception cref="InvalidArmorException"></exception>

        public void equipItem(Item item, Character character)
        {
            bool usable = false;
            itemSlot itemType = item.getItemSlot();
            int itemLevel = item.getLevel();
            int characterLevel = character.getLevel();
            var currentEquipments = this.equippedItems;
            var currentCharacterAttributes = character.getTotalAttributes();

                if (itemLevel > characterLevel)
                {
                    if (itemType == itemSlot.Weapon)
                    {
                        throw new InvalidWeaponException("Weapon level too high");
                    }
                    else
                    {
                        throw new InvalidArmorException("Armor level too high");
                    }
                }

                if (itemType == itemSlot.Weapon)
                {
                    foreach (var availableWeapon in character.getAvailableWeaponTypes())
                    {
                        if (item.getWeaponTypeFromParent() == availableWeapon)
                        {
                            usable = true;
                        }
                    }
                    if (usable == false)
                    {
                        throw new InvalidWeaponException("Wrong Weapon Type");
                    }
                    if (usable == true)
                    {

                    //if the code has come to here, it means that there haven't occured any violations, so it should display this message!
                    Console.WriteLine("New weapon equipped");

                    this.equippedItems[item.getItemSlot()] = item;
                    }
                }

                else
                {
                    foreach (var availableArmor in character.getAvailableArmorTypes())
                    {
                        if (item.getArmorTypeFromParent() == availableArmor)
                        {
                            usable = true;
                        }
                    }
                    if (usable == false)
                    {
                        throw new InvalidArmorException("Wrong Armor Type");
                    }

                    var newItemAttributes = item.getArmorAttributes();

                    if (currentEquipments[itemSlot.Body] == null)
                    {

                        character.setTotalIntelligenceValue(newItemAttributes["intelligence"] + currentCharacterAttributes["intelligence"]);

                        character.setTotalDexterityValue(newItemAttributes["dexterity"] + currentCharacterAttributes["dexterity"]);

                        character.setTotalStrengthValue(newItemAttributes["strength"] + currentCharacterAttributes["strength"]);

                    }
                    else
                    {
                        var oldItem = character.getInventory().equippedItems[item.getItemSlot()];

                        character.setTotalIntelligenceValue(currentCharacterAttributes["intelligence"] - oldItem.getArmorAttributes()["intelligence"]);
                        character.setTotalIntelligenceValue(newItemAttributes["intelligence"] + currentCharacterAttributes["intelligence"]);

                        character.setTotalStrengthValue(currentCharacterAttributes["strength"] - oldItem.getArmorAttributes()["strength"]);
                        character.setTotalStrengthValue(newItemAttributes["strength"] + currentCharacterAttributes["strength"]);

                        character.setTotalDexterityValue(currentCharacterAttributes["dexterity"] - oldItem.getArmorAttributes()["dexterity"]);
                        character.setTotalDexterityValue(newItemAttributes["dexterity"] + currentCharacterAttributes["dexterity"]);

                    }

                //if the code has come to here, it means that there haven't occured any violations, so it should display this message!
                
                Console.WriteLine("New Armor equipped");

                this.equippedItems[item.getItemSlot()] = item;
                }

        }

        public Dictionary<itemSlot, Item> getEquipedItems()
        {
            return this.equippedItems;
        }
        /// <summary>
        /// This method displays all the items of the character. as long as the item isn't empty, it will display it.
        /// </summary>
        public void displayInventory()
        {
            Item weapon = equippedItems[itemSlot.Weapon];
            Item head = equippedItems[itemSlot.Head];
            Item body = equippedItems[itemSlot.Body];
            Item legs = equippedItems[itemSlot.Legs];

            if(head != null)
            {
                Console.WriteLine(" Head Gear: " + head.getName());
            }
            if (body != null)
            {
                Console.WriteLine(" Body Gear: " + body.getName());
            }
            if (legs != null)
            {
                Console.WriteLine(" Legg Gear: " + legs.getName());
            }
            if (weapon != null)
            {
                Console.WriteLine(" Weapon: " + weapon.getName());
            }
        }
    }
}
