namespace Common.Identity.API.ModulePermissions.Modules.Dtos
{
    public static class ModuleMapper
    {
        public static ModuleResponseDto ToModuleResponseDto(Module module)
        {
            return new ModuleResponseDto
            {
                Id = module.Id,
                Name = module.Name,
                Alias = module.Alias,
                Description = module.Description,
                IsActive = module.IsActive,
                IsDeleted = module.IsDeleted
            };
        }
    }
}
