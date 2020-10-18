
namespace ConsultaMedica.Data.Models
{
    public class Exam : BaseModel
    {
        public string Name { get; set; }
        public string Observations { get; set; }
        public int ExamTypeID { get; set; }
        public virtual ExamType ExamType { get; set; }
    }
}
