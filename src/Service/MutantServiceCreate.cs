using Service.Interface;
using Service.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Database;
using AutoMapper;
using Model.DTOs;
using Model;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class MutantServiceCreate : IMutantServiceCreate
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MutantServiceCreate(
            ApplicationDbContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAdn(TblAdnDto adn)
        {
            if (SearchAdn(adn.Adn)==null)
            {  
                var entry = _mapper.Map<TblAdn>(adn);
                await _context.AddAsync(entry);
                await _context.SaveChangesAsync();              
            }
        }

        private TblAdnDto SearchAdn(string adn)
        {   
            var tipoAdn =  _context.TblAdn.Where(x => x.State && x.Adn == adn)
                                .FirstOrDefault();
            if (tipoAdn != null)
            {
                return _mapper.Map<TblAdnDto>(tipoAdn);
            }
            return null;             
        }
    }
}
