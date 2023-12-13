namespace KayanIntern.EntityModels;

public class User
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime Birthday { get; set; }
    public int PositionID { get; set; }
    public int DepartmentID { get; set; }
    public int AddressID { get; set; }
    
}