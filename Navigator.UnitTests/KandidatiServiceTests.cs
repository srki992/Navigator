using Microsoft.VisualStudio.TestTools.UnitTesting;
using Navigator.Models;
using System;

namespace Navigator.UnitTests
{
    [TestClass]
    public class KandidatiServiceTests
    {
        //GetAll()
        //bool Add(Kandidat objNoviKandidat)
        //bool Update(Kandidat objKandidatToUpdate)
        //bool Delete(string jmbg)
        //List<Kandidat> Search(string vrednostKojaSePretrazuje)
        [TestMethod]
        public void GetAll_FullListOfCandidats_ReturnsTrue()
        {
            //CanBeCancelledBy_Scenario_ExpectedBehavior

            //Arrange
            //var kandidati = new KandidatiService();
            //Act
            //var nesto=kandidati.GetAll();
            //Assert
        }

        [TestMethod]
        public void Add_NewCandidatAdd_ReturnsTrue()
        {
            //Arrange
            var kandidati = new KandidatiService();
            //Act
            var result = kandidati.Add(new Kandidat { ime="Milos", prezime="Obilic",jmbg="1906992710058", god_rodjenja="19.06.1992", email="milos@yahoo.com", telefon="011/2233577", napomena="nema.", zaposlen_nakon_konkursa="da", datum_izmene="05.05.2021" });
            //Assert
            Assert.IsTrue(result);
        }

    }
}
