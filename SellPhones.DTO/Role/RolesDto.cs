using static SellPhones.Commons.RoleName;

namespace SellPhones.DTO.Role
{
    public class GroupRolesItemDto
    {
        public RoleBlock GroupRolesEnum { get; set; }
        public string GroupRolesName { get; set; }
        public List<RolesDto> Roles { get; set; }
    }

    public class RolesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public bool Checked { get; set; } = false;
    }

    public class GroupListDto
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string Name { get; set; }
        public bool IsShowed { get; set; }
    }

    public class UserRoleDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class UpdateGroupDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateGroupDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}