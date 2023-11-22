namespace KayanIntern.EntityModels;

public class Feedback
{
    public int ID { get; set; }
    public String Description { get; set; }
    public int SupervisorID { get; set; }
    public int InternID { get; set; }
}