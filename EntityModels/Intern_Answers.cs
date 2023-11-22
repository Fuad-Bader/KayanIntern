using System.Security.Principal;

namespace KayanIntern.EntityModels;

public class InternAnswers
{
    public int ID { get; set; }
    public int ExamID { get; set; }
    public int QuestionID { get; set; }
    public int InternID { get; set; }
    public int RoundID { get; set; }
}