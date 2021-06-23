using Model.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IMutantServiceQuery
    {
        bool IsMutant(string[] adn);
        Task<ContentDnaResponse> GetStats();
    }
}
