using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Common
{
    public static class AdnCommon
    {
        public static List<string> GetListCombinations(String[] adn)
        {

            //Se agrega filas a la lista
            List<string> adnList = new List<string>();
            adnList.AddRange(adn);

            //Se agrega columnas
            for (int col = 0; col < adn.Length; col++)
            {
                string columna = "";
                for (int fila = 0; fila < adn.Length; fila++)
                {
                    columna += adn[fila][col];
                }
                adnList.Add(columna);
            }

            //Se agrega diagonales
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

            return adnList;
        }
            
    }
}
