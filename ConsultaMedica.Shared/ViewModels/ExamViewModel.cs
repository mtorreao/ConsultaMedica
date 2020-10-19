
namespace ConsultaMedica.Shared.ViewModels
{
    public class ExamViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Observations { get; set; }
        public ExamTypeViewModel ExamType { get; set; }
    }
}
