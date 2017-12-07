using System.Collections.Generic;
using BL;
using NUnit.Framework;

namespace Unit.Test.BL
{
    [TestFixture]
    public class Class1
    {
        [SetUp]
        public void consumerSetup()
        {
        }

        [Test]
        public void alarmTest()
        {
            var uut = new Alarm(150, 80);
            Assert.IsTrue(uut.alarmStatus());
        }

        [Test]
        public void calculateBloodPreassure()
        {
            var uut = new CalculateBloodPreassure(); // Brug objekt med parametre
            var testList = new List<double>();
            for (var i = 10; i < 50; i++)
                testList.Add(i);

            uut.CalculateBPValues(testList);

            Assert.That(uut.getDiastolicValue(), Is.EqualTo(10));
            Assert.That(uut.getSystolicValue(), Is.EqualTo(50));
        }
    }
}