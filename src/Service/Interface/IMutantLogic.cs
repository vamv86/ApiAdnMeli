using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interface
{
    public interface IMutantLogic
    { 
        bool IsMutant(string[] adn);
        bool IsValidAdn(String[] dna);
    }
}
