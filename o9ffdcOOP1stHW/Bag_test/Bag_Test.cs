using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EighthAssignment;

[TestClass]
public class Bag_Test{
    [TestMethod]
    public void TestAddElem(){
        Bag bag= new Bag();
        bag.AddElem(4,6);
        bag.AddElem(4,4);
        Assert.AreEqual(10,bag.FreqOfElem(4));
    }
    [TestMethod]
    public void TestRemElem(){
        Bag bag= new Bag();
        bag.AddElem(2,1);
        Assert.IsTrue(bag.RemElem(2,1));
    }
    [TestMethod]
    public void TestfreqOfElem()
    {
        Bag bag= new Bag();
        bag.AddElem(1,2);
        Assert.AreEqual(2, bag.FreqOfElem(1));
    }
    [TestMethod]
    
    public void TestMostFrequentElement()
    {
        Bag bag= new Bag();
        bag.AddElem(1,2);
        bag.AddElem(2,1);
        bag.AddElem(1,1);
        Assert.AreEqual(1, bag.MaxFreqElem());
        bag.AddElem(2,3);
        Assert.AreEqual(2, bag.MaxFreqElem());
    }
}


