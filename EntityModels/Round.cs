namespace KayanIntern.EntityModels;

public class Round
{
    public int ID { get; set; }
    public DateTime Date { get; set; }
    public int Duration { get; set; }
    public int InternID { get; set; }
    public int SupervisorID { get; set; }
    public int DepartmentID { get; set; }
    public int PositionID { get; set; }
    public int CourseID { get; set; }
    public int NameID { get; set; }
    public int DescriptionID { get; set; }
}