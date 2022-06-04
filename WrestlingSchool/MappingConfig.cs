using AutoMapper;
using DataAccess.Entity;
using Models;
using System;

namespace WrestlingSchool
{
    public static class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<WrestlingModel, DataAccess.Entity.WrestlingSchool>()
                .ForMember(f => f.CreatedAt, mf => mf.MapFrom(d =>Convert.ToDateTime(d. CreateDate)));

                config.CreateMap<DataAccess.Entity.WrestlingSchool, WrestlingModel>()
                .ForMember(f => f.CreateDate, mf => mf.MapFrom(d => d.CreatedAt.ToString("yyyy/MMM/dd")));
                
            });
            return mappingConfig;
        }
    }
}
