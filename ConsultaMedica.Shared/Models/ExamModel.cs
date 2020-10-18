
namespace ConsultaMedica.Shared.Models
{
    public class ExamModel : BaseModel
    {
        public string Name { get; set; }
        public string Observations { get; set; }
        public ExamTypeModel Type { get; set; }
    }
}
