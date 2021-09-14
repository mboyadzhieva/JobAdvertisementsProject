namespace JobAds.Server.Data
{
    public class Validation
    {
        public class Advertisement
        {
            public const int MaxDescriptionLength = 2000;
        }

        public class User
        {
            public const int MaxFullNameLength = 100;
            public const int MaxAboutLenght = 200;
        }
    }
}
