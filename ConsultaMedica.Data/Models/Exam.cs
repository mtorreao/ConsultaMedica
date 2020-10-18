
namespace ConsultaMedica.Data.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Observations { get; set; }
        public ExamType Type { get; set; }
    }
}
