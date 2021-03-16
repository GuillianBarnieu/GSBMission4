using Microsoft.VisualStudio.TestTools.UnitTesting;
using GSBMission4;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        GestionDate d = new GestionDate();

        [TestMethod]

        public void MethodTest()
        {
            Assert.AreEqual("16/03/2021", d.dateJour(), "erreur 0");
            Assert.AreEqual("16/02/2021", d.moisPrecedent(), "erreur 1");
            Assert.AreEqual("16/04/2021", d.moisSuivant(),"erreur 2");
        }

    }
}
