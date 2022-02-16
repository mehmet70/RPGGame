using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RPGGameTests
{
    public class CharacterTests
    {
        [Fact]
        public void GetLevel_AskedToGetCharacterLevel_ReturnsCharacterLevel()
        {
            //ARRANGE
            Mage mage = new Mage("Mehmet");
            int expected = 1;

            //ACT
            int actual = mage.getLevel();

            //ASSERT
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLevelAfterLevelup_AskedToGetLevelAfterLevelUp_ReturnsCorrectCharacterLevelAfterLevelUp()
        {
            //ARRANGE
            Mage mage = new Mage("Mehmet");
            mage.levelUp();
            int expected = 2;

            //ACT
            int actual = mage.getLevel();

            //ASSERT
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void getTotalAttributes_AskedToGetAttributesOfMage_ReturnsCorrectAttributesMage()
        {
            //ARRANGE
            Mage mage = new Mage("Mehmet");
            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                { "strength", 1 },
                { "dexterity", 1 },
                { "intelligence", 8 }
            };

            //ACT
            var actual = mage.getTotalAttributes();

            //ASSERT
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void getTotalAttributes_AskedToGetAttributesOfWarrior_ReturnsCorrectAttributesWarrior()
        {
            //ARRANGE
            Warrior warrior = new Warrior("Mehmet");
            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                { "strength", 5 },
                { "dexterity", 2},
                { "intelligence", 1 }
            };

            //ACT
            var actual = warrior.getTotalAttributes();

            //ASSERT
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void getTotalAttributes_AskedToGetAttributesOfRogue_ReturnsCorrectAttributesRogue()
        {
            //ARRANGE
            Rogue rogue = new Rogue("Mehmet");
            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                { "strength", 2 },
                { "dexterity", 6},
                { "intelligence", 1 }
            };

            //ACT
            var actual = rogue.getTotalAttributes();

            //ASSERT
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void getTotalAttributes_AskedToGetAttributesOfRanger_ReturnsCorrectAttributesRanger()
        {
            //ARRANGE
            Ranger ranger = new Ranger("Mehmet");
            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                { "strength", 1 },
                { "dexterity", 7},
                { "intelligence", 1 }
            };

            //ACT
            var actual = ranger.getTotalAttributes();

            //ASSERT
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void levelUp_AskedToChangeTotalAttributesToDesiredAttributesMage_ReturnsCorrectAttributes()
        {
            //ARRANGE
            Mage mage = new Mage("Mehmet");
            mage.levelUp();

            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                { "strength", (1 + 1)},
                { "dexterity", (1 + 1)},
                { "intelligence", (8 + 5)}
            };

            //ACT
            var actual = mage.getTotalAttributes();

            //ASSERT
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void levelUp_AskedToChangeTotalAttributesToDesiredAttributesWarrior_ReturnsCorrectAttributes()
        {
            //ARRANGE
            Warrior warrior = new Warrior("Mehmet");
            warrior.levelUp();

            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                { "strength", (5 + 3)},
                { "dexterity", (2 + 2)},
                { "intelligence", (1 + 1)}
            };

            //ACT
            var actual = warrior.getTotalAttributes();

            //ASSERT
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void levelUp_AskedToChangeTotalAttributesToDesiredAttributesRogue_ReturnsCorrectAttributes()
        {
            //ARRANGE
            Rogue rogue = new Rogue("Mehmet");
            rogue.levelUp();

            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                { "strength", (1 + 2)},
                { "dexterity", (4 + 6)},
                { "intelligence", (1 + 1)}
            };

            //ACT
            var actual = rogue.getTotalAttributes();

            //ASSERT
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void levelUp_AskedToChangeTotalAttributesToDesiredAttributesRanger_ReturnsCorrectAttributes()
        {
            //ARRANGE
            Ranger ranger = new Ranger("Mehmet");
            ranger.levelUp();

            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                { "strength", (1 + 1)},
                { "dexterity", (7 + 5)},
                { "intelligence", (1 + 1)}
            };

            //ACT
            var actual = ranger.getTotalAttributes();

            //ASSERT
            Assert.Equal(expected, actual);
        }
    }
}
