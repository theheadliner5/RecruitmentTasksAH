namespace RecruitmentTasksAH.FirstTask.Model
{
    public class Representative
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nip { get; set; }
        public string? CompanyName { get; set; }
        public int EntrepreneurId { get; set; }
        public Entrepreneur Entrepreneur { get; set; }
    }
}
