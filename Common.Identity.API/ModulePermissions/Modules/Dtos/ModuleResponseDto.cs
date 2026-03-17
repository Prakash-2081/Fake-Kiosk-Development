namespace Common.Identity.API.ModulePermissions.Modules.Dtos
{
    public class ModuleResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
