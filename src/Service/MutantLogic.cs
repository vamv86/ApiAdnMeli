using Service.Common;
using Service.Exceptions;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class MutantLogic : IMutantLogic
    {

        public bool IsMutant(string[] adn)
        {
            //Se Valida las matrices y las bases nitrogenadas
            if (IsValidAdn(adn))
            {
                return ValidateMutant(adn);
            }
            else
            {
                return false;
            }
        }

        private bool ValidateMutant(string[] adn)
        {

            //Se agrega filas a la lista
            List<string> adnList = new List<string>();
            adnList.AddRange(adn);


            // Se validan filas.
            if (adnList.Any(x => AdnCommon.genMutant.Any(gen => x.Contains(gen))))
            {
                return true;
            }


            //Se agregan columnas
            adnList = new List<string>();
            for (int col = 0; col < adn.Length; col++)
            {
                string columna = "";
                for (int fila = 0; fila < adn.Length; fila++)
                {
                    columna += adn[fila][col];
                }
                adnList.Add(columna);
            }

            // Se validan columnas.
            if (adnList.Any(x => AdnCommon.genMutant.Any(gen => x.Contains(gen))))
            {
                return true;
            }

            //Se agregan diagonales
            adnList = new List<string>();
            for (int i = 0; i < adn.Length / 2; i++)
            {
                string diagonalSupIzq = "";
                string diagonalInfIzq = "";
                string diagonalSupDer = "";
                string diagonalSecDer = "";
                for (int j = 0; j < adn.Length - i; j++)
                {
                    diagonalSupIzq += adn[j][j + i];
                    diagonalSupDer += adn[(adn.Length - 1) - j][j + i];
                    if (i != 0)
                    {
                        diagonalInfIzq += adn[i + j][j];
                        diagonalSecDer += adn[i + j][(adn.Length - 1) - j];
                    }
                }

                if (diagonalSupIzq.Length > 0)
                {
                    adnList.Add(diagonalSupIzq);
                    adnList.Add(diagonalSupDer);
                }

                if (diagonalInfIzq.Length > 0)
                {
                    adnList.Add(diagonalInfIzq);
                    adnList.Add(diagonalSecDer);
                }
            }

            // Se validan diagonales.
            if (adnList.Any(x => AdnCommon.genMutant.Any(gen => x.Contains(gen))))
            {
                return true;
            }

            return false;
        }

        public bool IsValidAdn(String[] dna)
        {
            if (dna.Length == AdnCommon.matrizLength)
            {
                //Se agrega filas a la lista
                List<string> adnList = new List<string>();
                adnList.AddRange(dna);


                for (int row = 0; row < dna.Length; row++)
                {
                    string line = dna[row];
                    if (line.Length == AdnCommon.matrizLength)
                    {
                        for (int col = 0; col < line.Length; col++)
                        {
                            char _char = line[col];
                            if (!AdnCommon.charValid.Contains(_char))
                            {
                                throw new InvalidNitrogenBaseException("Bases nitrogenadas incorrectas");
                            }
                        }
                    }
                    else
                    {
                        throw new InvalidColumnsException("La cantidad de columnas en la matriz es incorrecta");
                    }
                }
            }
            else
            {
                throw new InvalidRowsException("La cantidad de filas en la matriz es incorrecta");
            }
            return true;
        }
    }
}
