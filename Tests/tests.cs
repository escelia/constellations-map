using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;


[TestClass]
public class Test {

    StarGroup sg = new StarGroup();

    [TestMethod]
    public void TestNumber()
    {
        Assert.IsTrue(sg.NumberOfStars() == 0, "must be 0");
    }
}
