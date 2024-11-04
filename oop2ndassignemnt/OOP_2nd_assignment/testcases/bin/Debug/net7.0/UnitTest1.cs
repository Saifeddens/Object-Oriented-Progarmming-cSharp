namespace testcases;

using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_2nd_assignment;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1forWOM()
    {
        var ecosystem = new Ecosystem(); 
        string name = "TestPlant";
        string type = "wom";
        int nutrients = 10;

        // Act
        var plant = ecosystem.CreatePlant(name, type, nutrients);

        // Assert
        Assert.IsNotNull(plant);
        Assert.IsInstanceOfType(plant, typeof(Wombleroot));
        Assert.AreEqual(name, plant.Name);
        Assert.AreEqual(nutrients, plant.Nutrient_Level);


    }
    
    [TestMethod]
    public void TestMethod2forWIT()
    {
        var ecosystem = new Ecosystem();
        string name = "TestPlant";
        string type = "wit";
        int nutrients = 10;

        // Act
        var plant = ecosystem.CreatePlant(name, type, nutrients);

        // Assert
        Assert.IsNotNull(plant);
        Assert.IsInstanceOfType(plant, typeof(Wittentoot));
        Assert.AreEqual(name, plant.Name);
        Assert.AreEqual(nutrients, plant.Nutrient_Level);
    }
}
