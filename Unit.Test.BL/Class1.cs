using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BL;
using NUnit.Framework;
using DTO;

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
            var uut = new Alarm(150,80);
            Assert.IsTrue(uut.alarmStatus());
        }

        [Test]
        public void calculateBloodPreassure()
        {
            var uut = new CalculateBloodPreassure();            // Brug objekt med parametre
            List<double> testList = new List<double>();
            for (int i = 10; i < 50; i++)
            {
                testList.Add(i);
            }

            uut.CalculateBPValues(testList);

            Assert.That(uut.getDiastolicValue(),Is.EqualTo(10));
            Assert.That(uut.getSystolicValue(),Is.EqualTo(50));
        }
    }
}
