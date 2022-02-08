using APIInfraCrossCutting.Mapping;
using AutoMapper;
using System;
using Xunit;

namespace APIServiceTest
{
    public abstract class BaseTestService
    {
        public IMapper Mapper { get; set; }


        public BaseTestService()
        {
            Mapper = new AutoMapperFixture().GetMapper();
        }
    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new ModelToEntityProfile());
                c.AddProfile(new DtoToModelProfile());
                c.AddProfile(new EntityToDtoProfile());
            });
            return config.CreateMapper();
        }

        public void Dispose()
        {
        }
    }
}
