namespace RecruitmentTasksAH.FirstTask.Model
{
    public class AccountNumber
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public int EntrepreneurId { get; set; }
        public Entrepreneur Entrepreneur { get; set; }
    }

}
