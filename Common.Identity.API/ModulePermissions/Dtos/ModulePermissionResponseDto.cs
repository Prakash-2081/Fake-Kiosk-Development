namespace Common.Identity.API.ModulePermissions.Dtos
{
    public class ModulePermissionResponseDto
    {
        public Guid ModulePermissionId { get; set; }
        public Guid ModuleId { get; set; }
        public string ModuleName { get; set; }  
        public string Alias { get; set; }
        public Guid PermissionId { get; set;}
        public string PermissionName { get; set; }       
    }
}
