using NUnit.Framework;
using System;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Planet planet;
            private Weapon weapon;
            [SetUp]
            public void SetUp()
            {
                planet = new Planet("Zemq", 10);
                weapon = new Weapon("Nucliar", 10, 8);
            }
            [Test]
            public void PlanetConstructorTest()
            {
                Planet pl = new Planet("Ves", 1);

                Assert.AreEqual(pl.Budget, 1);
                Assert.AreEqual(pl.Name, "Ves");
            }

            [Test]
            [TestCase(null , 9)]
            [TestCase("" , 9)]
            public void PlanetNameNullEmptyException(string name , double budget)
            {
                Assert.Throws<ArgumentException>((() => new Planet(name,budget)),"Invalid planet Name");
            }

            [Test]
            public void PlanetProperSetName()
            {
                Assert.AreEqual(planet.Name, "Zemq");
            }

            [Test]
            [TestCase("a",-1)]
            public void PlanetBudgetLessThanZero(string name, double budget)
            {
                Assert.Throws<ArgumentException>((() => new Planet(name, budget)), "Budget cannot drop below Zero!");
            }

            [Test]
            public void PlanetBudgetTest()
            {
                Assert.AreEqual(planet.Budget, 10);
            }

            [Test]
            public void PlanetColectionWeaponsCountTest()
            {
                for (int i = 0; i < 5; i++)
                {
                    var weaponToAdd = new Weapon(String.Join("A",i), 5 + i, 5 + i);
                    planet.AddWeapon(weaponToAdd);
                }

                Assert.AreEqual(planet.Weapons.Count, 5);
            }

            [Test]
            public void PlanetProfitTest()
            {
                planet.Profit(5);

                Assert.AreEqual(planet.Budget , 15);
            }

            [Test]
            public void PLanetSpendFundsAmountBiggerThanBudget()
            {

                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(25), "Not enough funds to finalize the deal.");
            }

            [Test]
            public void PlanetSpendAmountTest()
            {
                planet.SpendFunds(5);
                Assert.AreEqual(planet.Budget, 5);
            }

            [Test]
            public void PlanetAddWeapontExeptionSameName()
            {
                Weapon weapon = new Weapon("a", 5, 5);
                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon), $"There is already a {weapon.Name} weapon.");
            }

            [Test]
            public void PlanetRemoveWeaponTest()
            {
                Weapon weapon = new Weapon("a", 5, 5);
                planet.AddWeapon(weapon);
                planet.RemoveWeapon(weapon.Name);

                Assert.AreEqual(planet.Weapons.Count, 0);
            }

            [Test]
            public void PlanetUpgradeWeaponExeptionForMissingWeapon()
            {
                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("veso"), $"veso does not exist in the weapon repository of {planet.Name}");
            }

            [Test]
            public void PlanetUpgradeWeapon()
            {
                Weapon weapon = new Weapon("a", 5, 5);
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(weapon.Name);

                Assert.AreEqual(planet.Weapons.Single(x => x.Name == weapon.Name).DestructionLevel, 6);
            }

            [Test]
            public void PlanetVsPlanetIvalidOperationExeption()
            {
                Planet oponentPlanet = new Planet("dsa", 10);
                Weapon weapon = new Weapon("nuclia",10,9);
                oponentPlanet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(oponentPlanet), "dsa is too strong to declare war to!");
            }

            [Test]
            public void PlanetdestructionOpponentWorkProperly()
            {
                Planet oponentPlanet = new Planet("dsa", 10);
                Weapon weapon = new Weapon("nuclia", 10, 9);
                planet.AddWeapon(weapon);

                Assert.AreEqual(planet.DestructOpponent(oponentPlanet), "dsa is destructed!");
            }

            [Test]
            public void WeaponConstructorWorkProperly()
            {
                Assert.AreEqual(weapon.Name, "Nucliar");
                Assert.AreEqual(weapon.Price, 10);
                Assert.AreEqual(weapon.DestructionLevel, 8);
            }

            [Test]
            public void WeaponPriceLessThanZero()
            {

                Assert.Throws<ArgumentException>(() => new Weapon("bla", -1, 8), "Price cannot be negative.");
            }

            [Test]
            public void WeaponIncreaseDestructionLevel()
            {
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(weapon.DestructionLevel, 9);
            }

            [Test]
            public void WeaponIsNuclearLessThanTen()
            {
                Assert.AreEqual(weapon.IsNuclear, false);
            }

            [Test]
            public void WeaponIsNuclearMoreThanTen()
            {
                weapon.IncreaseDestructionLevel();
                weapon.IncreaseDestructionLevel();
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(weapon.IsNuclear, true);
            }
        }
    }
}
