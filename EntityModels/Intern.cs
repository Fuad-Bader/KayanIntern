namespace KayanIntern.EntityModels
{
    public class Intern
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public DateTime AcceptanceDate { get; set; }
        public int RoundID { get; set; }
        public int FeedbackID { get; set; }
        public int Score { get; set; }
    }
}
