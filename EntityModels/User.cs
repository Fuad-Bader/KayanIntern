namespace KayanIntern.EntityModels;

public class User
{
    public int ID { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String Email { get; set; }
    public String Password { get; set; }
    public DateTime Birthday { get; set; }
    public int PositionID { get; set; }
    public int DepartmentID { get; set; }
    public int AddressID { get; set; }
    
}