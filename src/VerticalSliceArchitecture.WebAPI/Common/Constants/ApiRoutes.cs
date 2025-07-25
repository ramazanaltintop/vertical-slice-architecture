namespace VerticalSliceArchitecture.WebAPI.Common.Constants;

public static class ApiRoutes
{
    public const string BaseApi = "/api/v1";

    public static class Categories
    {
        public const string Base = BaseApi + "/categories";
        public const string Get = Base + "/{id}";
        public const string Update = Base + "/{id}";
        public const string Patch = Base + "/{id}";
        public const string Delete = Base + "/{id}";
    }
}
