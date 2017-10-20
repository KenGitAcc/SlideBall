using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Slide.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestContainerListCount()
        {
            Slide.totalLevel = 4;
            Slide.initalSlide();
            Assert.AreEqual(Slide.containerList.Count, 16);
        }

        [TestMethod]
        public void TestContainerListName()
        {
            Slide.totalLevel = 4;
            Slide.initalSlide();
            GateContainer firstContainer = Slide.containerList[0];         
            Assert.AreEqual(firstContainer.Name, "A");
        }

    }
}
