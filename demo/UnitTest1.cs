using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace demo
{
    [TestClass]
    public class UnitTest1
    {
        string text = @"0.994772 0.023164 0.099456 28 4.61 3
0.873265 0.031968 0.486196 358 2.07 15 ALPHERATZ
0.512379 0.020508 0.858515 432 2.28 21 CAPH; CAS BETA

0.882312 0.036017 -0.469285 493 5.42 24
0.816743 0.041844 -0.575482 739 5.24 35
0.963482 0.055705 0.261913 886 2.83 39 ALGENIB";

string text2 = @"0.998448 0.035746 -0.042707 352 6.18 14
0.873265 0.031968 0.486196 358 2.07 15 ALPHERATZ; LARS; MAXIMUM; KYTHRA; SYLO
0.512379 0.020508 0.8sdf58515 432 2.28 21 CAPH; CAS BETA;
0.949168 0.037455 0.312534 448 5.57 22
0.882312 0.036017 -0.469285 493 5.42 24
0.697240 0.028641 -0.716265 496 3.88 25";

string text3 = @"0.998448 0.035746 -0.042707 352 6.18 14
0.873265 0.031968 0.486196 358 2.07 15 ALPHERATZ; LARS; MAXIMUM; KYTHRA; SYLO
0.512379 0.020508 0.8sdf58515 432 2.28 21 CAPH; CAS BETA;
0.949168 0.037455 0.312534 448 5.57 22
0.882312 0.036017 -0.469285 493 5.42 24
0.697240 0.028641 -0.716265 496 3.88 25
0.234342 0.234234";

string path = @"../../../../StarMap/Maps/stars_short.txt";


        [TestMethod]
        public void TestChangedDataWithinReader()
        {
            StarMapReader smr = new StarMapReader();
            List<Star> list = smr.stringToList(text);
            List<Star> list2 = smr.stringToList(text2);
            Assert.IsTrue(list2.Count == 11, "11 stars total after update");
            Assert.IsTrue(list2[7].getNames().Count == 5, "names of star are 5");
        }

        [TestMethod]
        public void TestAnyNumberOfNames()
        {
            StarMapReader smr = new StarMapReader();
            List<Star> list2 = smr.stringToList(text2);
            Console.WriteLine(list2[0].getNames().Count);
            Assert.IsTrue(list2[0].getNames().Count == 0, "names of first star of list are 0");
            Assert.IsTrue(list2[1].getNames().Count == 5, "names of second star of list are 5");
        }

        [TestMethod]
        public void TestEmptyLinesInInputFiles()
        {
            StarMapReader smr = new StarMapReader();
            List<Star> list = smr.stringToList(text);
            Assert.IsTrue(list.Count == 6, "must be 6 stars total with empty line");
        }

        [TestMethod]
        public void TestPartialOrMisformattedLines()
        {
            StarMapReader smr = new StarMapReader();
            List<Star> list3 = smr.stringToList(text3);
            Assert.IsTrue(list3.Count == 5, "must be 5 after partial line and misformatted line");
        }

        [TestMethod]
        public void TestFilepath()
        {
            StarMapReader smr = new StarMapReader();
            List<Star> list = smr.fileToList(path);
            Assert.IsTrue(list.Count == 17, "17 total stars in list read from path");
        }


    }
}
