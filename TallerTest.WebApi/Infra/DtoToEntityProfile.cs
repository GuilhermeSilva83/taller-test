using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using TallerTest.Domain.Aggregations.CarAgg;
using TallerTest.Domain.Aggregations.MakeAgg;
using TallerTest.WebApi.Dto;

namespace TallerTest.WebApi.Infra
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<CarDto, Car>();



            CreateMap<MakeDto, Make>();
             

        }
    }
}
