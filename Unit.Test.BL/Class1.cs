using System.Collections.Concurrent;
using System.Collections.Generic;
using BL;
using DAL;
using DTO;
using Interfaces;
using NUnit.Framework;

namespace Unit.Test.BL
{
    [TestFixture]
    public class Class1
    {
        private iBusinessLogic businessLogic;

        [SetUp]
        public void consumerSetup()
        {
            ConcurrentQueue<Datacontainer> queue = new ConcurrentQueue<Datacontainer>();
            iDataAccessLogic dataAccessLogic = new CtrlDataAccessLogic();
            businessLogic = new CtrlBusinessLogic(dataAccessLogic, queue);
        }

        [Test]
        public void alarmTest()
        {
            var uut = new Alarm(150, 80);
            Assert.IsTrue(uut.alarmStatus());
        }
        [Test]

         public void checkAlarmSound()
        {
            
            var uut = new Alarm();
            uut.setCurrentDia(80);
            uut.setCurrentSys(121);

            uut.setHighValue(120);
            uut.setLowValue(80);
            uut.CheckAlarmValues();

            Assert.That(uut.isTonePlaying,Is.True);
        }

        [Test]
        public void calculateBloodPreassure()
        {
            var uut = new CalculateBloodPreassure(businessLogic); // Brug objekt med parametre
            var testList = new List<double>();
            for (int i = 0; i < 500; i++)
                testList.Add(i);


            uut.CalculateBPValues(testList);

            Assert.That(uut.getDiastolicValue(), Is.EqualTo(0));
            Assert.That(uut.getSystolicValue(), Is.EqualTo(499));
        }

    }
}