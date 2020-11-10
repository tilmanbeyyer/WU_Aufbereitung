using NUnit.Framework;
using WU_Aufbereitung.models;

namespace NUnitTestVerarbeiter
{
    public class Tests
    {
        Verarbeiter verarbeiter;
        [SetUp]
        public void Setup()
        {
            verarbeiter = new Verarbeiter();

           
        }

        [Test]
        public void VerarbeiterPreufeReportisTrue()
        {
            bool result = verarbeiter.pruefeReport(@"C:\Users\tilmanbeyer\source\repos\WU_Aufbereitung\NUnitTestVerarbeiter\resources\OutputWebuntis.xls");
            Assert.IsTrue(!result);
        }

        [Test]
        public void VerarbeiterPreufeReportisFalse()
        {
            bool result = verarbeiter.pruefeReport(@"C:\Users\tilmanbeyer\source\repos\WU_Aufbereitung\NUnitTestVerarbeiter\resources\OutputWebuntis_Output 2.csv");
            Assert.IsTrue(result);
        }
    }
}