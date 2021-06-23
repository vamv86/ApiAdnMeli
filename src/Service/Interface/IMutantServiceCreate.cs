using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IMutantServiceCreate
    {
        Task CreateAdn(TblAdnDto adn);
    }
}
