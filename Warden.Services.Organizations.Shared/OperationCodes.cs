namespace Warden.Services.Organizations.Shared
{
    public static class OperationCodes
    {

        public static string Success => "success";
        public static string EmptyOrganizationName => "empty_organization_name";
        public static string EmptyWardenName => "empty_warden_name";
        public static string UserNotFound => "user_not_found";
        public static string OrganizationNotFound => "organization_not_found";
        public static string OrganizationNameInUse => "organization_name_in_use";
        public static string WardenNotFound => "warden_not_found";
        public static string WardenNameInUse => "warden_name_in_use";
        public static string Error => "error";
    }
}