namespace VerticalSliceArchitecture.WebAPI.Common.Abstractions;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
