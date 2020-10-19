using ConsultaMedica.Logic.Mappers;

namespace ConsultaMedica.Logic
{
    public static class Initializer
    {
        public static void Start()
        {
            Data.Initializer.Start();
            AutoMapperConfig.RegisterMappings();
        }
    }
}
