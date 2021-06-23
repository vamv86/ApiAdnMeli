using AutoMapper;
using Model;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Test.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<TblAdn, TblAdnDto>();

            CreateMap<TblAdnDto, TblAdn>()
               .ForMember(
                   dest => dest.State,
                   opts => opts.MapFrom(src => true)
               ).ForMember(
                   dest => dest.CreateDate,
                   opts => opts.MapFrom(src => System.DateTime.Now)
               );
        }
    }
}
