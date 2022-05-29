namespace mbanq.API.Dtos
{
    public class NewBranchDto
    {
        public int OrganizationId { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? DigitalAddress { get; set; }
        public string? City { get; set; }
        public int? RegionId { get; set; }
        public int? StateId { get; set; }
        public bool IsHead { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Alias { get; set; }
    }

    public class ActivateBranchDto
    {
        public int OrganizationId { get; set; }
        public int BranchId { get; set; }
    }
}
