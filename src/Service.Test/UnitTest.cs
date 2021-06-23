using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.Exceptions;
using Service.Interface;
using Service.Test.Config;
using System.Linq;

namespace Service.Test
{
    [TestClass]
    public class UnitTest
    {
        private static IMapper _mapper;
        public UnitTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapperConfig());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [TestMethod]
        public void TestIsTrueMutantHorizontal()
        {
            /* ------- Mutante Horizontal----------

                    A T C G A T
                    C G A T C G
                    A A A A T T
                    C G A T C G
                    A T C G A T
                    C G A T C G         
            */

            string[] adn = { "ATCGAT", "CGATCG", "AAAATT", "CGATCG", "ATCGAT", "CGATCG" };
            IMutantLogic logica = new MutantLogic();
            Assert.IsTrue(logica.IsMutant(adn));

        }

        [TestMethod]
        public void TestIsTrueMutantVertical()
        {


            /* ------- Mutante Vertical----------

                    A T C G T T
                    C G A T T G
                    A T C G T T
                    C G A T T G
                    A T C G A T
                    C G A T C G         
            */

            string[] adn = { "ATCGTT", "CGATTG", "ATCGTT", "CGATTG", "ATCGAT", "CGATCG" };
            IMutantLogic logica = new MutantLogic();
            Assert.IsTrue(logica.IsMutant(adn));

        }

        [TestMethod]
        public void TestIsTrueMutantDiagonal()
        {
            /* ------- Mutante Diagonal----------
                   
                    A T C G A T
                    C G A T C G
                    A T G G A T
                    C G A G C G
                    A T C G G T
                    C G A T C G         
            */

            string[] adn = { "ATCGAT", "CGATCG", "ATGGAT", "CGAGCG", "ATCGGT", "CGATCG" };
            IMutantLogic logica = new MutantLogic();
            Assert.IsTrue(logica.IsMutant(adn));

        }

        [TestMethod]
        public void TestIsNotMutant()
        {
            /* ------- No mutante----------
                   
                    A T C G A T
                    C G A T C G
                    A T C G A T
                    C G A T C G
                    A T C G A T
                    C G A T C G         
            */

            string[] adn = { "ATCGAT", "CGATCG", "ATCGAT", "CGATCG", "ATCGAT", "CGATCG" };
            IMutantLogic logica = new MutantLogic();
            Assert.IsFalse(logica.IsMutant(adn));
        }


        [TestMethod]
        public void TestIsIsInvalidRows()
        {
            /* ------- Filas Invalidas en la matriz----------
                   
                    A T C G A T
                    C G A T C G
                    A T C G A T
                    C G A T C G
                    A T C G A T     
            */

            string[] adn = { "ATCGAT", "CGATCG", "ATCGAT", "CGATCG", "ATCGAT" };
            IMutantLogic logica = new MutantLogic();
            Assert.ThrowsException<InvalidRowsException>(() => logica.IsValidAdn(adn));
        }


        [TestMethod]
        public void TestIsIsInvalidColumns()
        {
            /* ------- Columnas invalidas en la matriz----------
                   
                    A T C G A T
                    C G A T C G
                    A T C G A T
                    C G A T C G
                    A T C G A T
                    C G A T C        
            */

            string[] adn = { "ATCGAT", "CGATCG", "ATCGAT", "CGATCG", "ATCGAT", "CGATC" };
            IMutantLogic logica = new MutantLogic();
            Assert.ThrowsException<InvalidColumnsException>(() => logica.IsValidAdn(adn));
        }

        [TestMethod]
        public void TestIsIsInvalidNitrogenBase()
        {
            /* ------- Base nitrogenada invalida ----------
                   
                    A T C G A T
                    C G H T C G
                    A T C G A T
                    C G A T C G
                    A T C G A T
                    C G A T C G         
            */

            string[] adn = { "ATCGAT", "CGHTCG", "ATCGAT", "CGATCG", "ATCGAT", "CGATCG" };
            IMutantLogic logica = new MutantLogic();

            Assert.ThrowsException<InvalidNitrogenBaseException>(() => logica.IsValidAdn(adn));
        }

        [TestMethod]
        public void TestCreateAdnWhenNotExists()
        {
            var context = ApplicationDbContextInMemory.Get();

            IMutantServiceCreate service = new MutantServiceCreate(context, _mapper);


            Model.DTOs.TblAdnDto adndto = new Model.DTOs.TblAdnDto();
            adndto.Adn = "ATGCGA,CAGTGC,TTATAT,AGAAGG,CCTATA,TCACTG";
            adndto.AdnType = "Humano";
            adndto.IsMutant = true;

            service.CreateAdn(adndto);

            Assert.AreEqual(context.TblAdn.Count(x => x.Adn == adndto.Adn), 1);

        }


        [TestMethod]
        public void TestCreateAdnWhenExists()
        {
            var context = ApplicationDbContextInMemory.Get();

            IMutantServiceCreate service = new MutantServiceCreate(context, _mapper);

            Model.DTOs.TblAdnDto adndto = new Model.DTOs.TblAdnDto();
            adndto.Adn = "ATGCGA,CAGTGC,TTATAT,AGAAGG,CCTATA,TCACTG";
            adndto.AdnType = "Humano";
            adndto.IsMutant = true;

            service.CreateAdn(adndto);
            service.CreateAdn(adndto);

            Assert.AreEqual(context.TblAdn.Count(x => x.Adn == adndto.Adn), 1);

        }

    }
}
