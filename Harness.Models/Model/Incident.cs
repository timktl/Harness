namespace Harness.Models.Model
{
    public class Incident
    {
        public int Id { get; set; }
        public string? Details { get; set; }
        public Person? ReportedBy { get; set; }
    }
}