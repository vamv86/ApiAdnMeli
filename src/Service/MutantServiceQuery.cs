using Service.Interface;
using Service.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DTOs.Response;
using Persistence.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.DTOs;

namespace Service
{
    public class MutantServiceQuery: IMutantServiceQuery
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MutantServiceQuery(
            ApplicationDbContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public bool IsMutant(string [] adn)
        {

            //Se llena una lista con todas las combinaciones posibles para detectar los genes mutantes
            List<string> mutantGenList = AdnCommon.GetListCombinations(adn);

            //Se define las secuencias de bases nitrogenadas en los genes que determinan si es o no mutante
            string[] genes = { "AAAA", "TTTT", "GGGG", "CCCC" };

            // Retorna false o true si encuentra coincidencias.
            return mutantGenList.Any(x=> genes.Any(gen => x.Contains(gen))); 
        }

        public async Task<ContentDnaResponse> GetStats()
        {
            
           var tipoAdn = await _context.TblAdn.Where(x => x.State && x.IsMutant)
                                .FirstOrDefaultAsync();

            var query = await _context.TblAdn
                   .Where(x => x.State)
                   .GroupBy(p => p.IsMutant)
                   .Select(g => new 
                   {
                       ismutant = g.Key,
                       cantidad = g.Count()
                   }).ToListAsync();

            if (query!=null)
            {
                DnaResponse response = new DnaResponse();
                response.count_human_dna = query.Sum(x=> x.cantidad);
                response.count_mutant_dna = query.Where(x=> x.ismutant).Sum(x => x.cantidad);
                response.ratio = double.Parse ( String.Format("{0:00.0}",  response.count_mutant_dna / double.Parse(response.count_human_dna.ToString()) ));

                return new ContentDnaResponse { ADN =response };
            }
            return new ContentDnaResponse();
        }
    }
}
