namespace O_gym.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Version = "v1";
        public const string Root = "api";
        public const string Base = Root + "/" + Version;

        public static class UserMemberShip
        {
            public const string UserMemberShipBase = Base + "/userMembership";
            public const string AddMembership = UserMemberShipBase + "/addMembership";
        }
    }
}
