using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Slide.Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestRunballResult()
        {
            Slide.totalLevel = 4;
            Slide.initalSlide();
            Slide.runSlideBall(15);
            var hasBallContainers = Slide.containerList.Where(x => x.HasBall == true).ToList();
            Assert.AreEqual(hasBallContainers.Count, 15);
            GateContainer noBallContainer = Slide.containerList.Where(x => x.HasBall == false).First();
            Assert.AreEqual(noBallContainer.Name, "P");
        }


        [TestMethod]
        public void TestContainerListCount()
        {
            Slide.containerList.Clear();
            Slide.totalLevel = 4;
            Slide.initalSlide();
            Assert.AreEqual(Slide.containerList.Count, 16);
        }


       

    }
}
