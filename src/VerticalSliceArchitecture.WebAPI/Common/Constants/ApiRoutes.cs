namespace VerticalSliceArchitecture.WebAPI.Common.Constants;

public static class ApiRoutes
{
    public const string BaseApi = "/api/v1";

    public static class Categories
    {
        public const string Base = BaseApi + "/categories";
        public const string Create = Base + "/create";
        public const string GetAll = Base + "/get-all";
        public const string Get = Base + "/get/{id}";
        public const string Update = Base + "/update/{id}";
    }
}
