//using AutoMapper;

using AutoMapper;
using DAL;

namespace BAL
{
    internal class MyMappings : Profile
    {
        public MyMappings()
        {
            CreateMap<Variable, VariableDto>();
        }
    }
}