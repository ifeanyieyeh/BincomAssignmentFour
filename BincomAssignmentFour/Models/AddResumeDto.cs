namespace BincomAssignmentFour.Models
{
    public class AddResumeDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public string ExecutiveSummary { get; set; }
        public string WorkExperience { get; set; }
        public string Projects { get; set; }

    }
}


