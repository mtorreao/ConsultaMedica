using AutoMapper;
using ConsultaMedica.Data.Models;
using ConsultaMedica.Shared.ViewModels;

namespace ConsultaMedica.Logic.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper mapper;

        public static void RegisterMappings()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Patient, PatientViewModel>();
                cfg.CreateMap<ExamType, ExamTypeViewModel>();
                cfg.CreateMap<Exam, ExamViewModel>();
            });
            configuration.AssertConfigurationIsValid();
            mapper = configuration.CreateMapper();
        }
    }

}
