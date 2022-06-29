using System;

namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car("VW", "vw1", 3.00, 25);
            
        }

        [Test]
        public void CreateCarWithCtor()
        {
            Assert.IsNotNull(car);

        }

        [TestCase("")]
        [TestCase(null)]
        public void Exception_MakeShouldNotBeNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "aaa", 2, 50), "Make cannot be null or empty!");
        }

        [Test]
        public void MakeShouldNotBeNullOrEmpty()
        {
            Assert.AreEqual("VW", car.Make);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Exception_ModelShouldNotBeNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("aaa", model, 2, 50), "Model cannot be null or empty!");
        }

        [Test]
        public void ModelShouldNotBeNullOrEmpty()
        {
            Assert.AreEqual("vw1", car.Model);
        }

        [TestCase(0)]
        [TestCase(-1.00)]
        public void Exception_FuelConsumptionCannotBeZeroOrNegative(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("aaa", "modelAAA", fuelConsumption, 50),
                "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        public void FuelConsumptionShouldBePositiveNumber()
        {
            Assert.AreEqual(3.00, car.FuelConsumption);
        }

        [TestCase(0)]
        [TestCase(-1.00)]
        public void Exception_FuelAmountCannotBeZeroOrNegative(double fuelAmount)
        {
            ; Assert.Throws<ArgumentException>(() => car.Refuel(fuelAmount), "Fuel amount cannot be negative!");
        }
        [Test]
        [TestCase(5)]
        [TestCase(8)]
        public void FuelAmountShouldBePositiveNumberOrZero(double fuelAmount)
        {
            car.Refuel(fuelAmount);
            Assert.AreEqual(fuelAmount, car.FuelAmount);
        }

        [TestCase(-1.00)]
        public void Exception_FuelCapacityCannotBeNegative(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("aaa", "modelAAA", 3.00, fuelCapacity),
                "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        public void FuelCapacityShouldBePositiveNumber()
        {
            Assert.AreEqual(25, car.FuelCapacity);
        }
        [Test]
        public void Exception_FuelToRefuelShouldNotBeNegative()
        {

            Assert.Throws<ArgumentException>(() => car.Refuel(-5), "Fuel amount cannot be zero or negative!");
        }
        [Test]
        public void IncreaseFuelAmountWithFuelToRefuel()
        {
            car.Refuel(15);
            Assert.AreEqual(15, car.FuelAmount);
        }
        [Test]
        public void FuelAmountCannotExceedFuelCapacity()
        {
            car.Refuel(30);
            Assert.AreEqual(25, car.FuelAmount);
        }

        [Test]
        [TestCase(30)]
        [TestCase(100)]
        public void FuelAmountIsEnoughToDriveDistance(double distance)
        {
            car.Refuel(25);
            car.Drive(distance);
            Assert.AreEqual(25- (distance / 100) * car.FuelConsumption, car.FuelAmount);
        }

        [Test]
        [TestCase(80)]
        [TestCase(100)]
        public void ThrownException_NotEnoughFuelToDrive(double distance)
        {
            car.Refuel(1);
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance), "You don't have enough fuel to drive!");
        }
    }
}
