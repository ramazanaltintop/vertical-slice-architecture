using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
using VerticalSliceArchitecture.WebAPI.Common.Abstractions;

namespace VerticalSliceArchitecture.WebAPI.Common.Extensions;

public static class EndpointExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(assembly);

        ServiceDescriptor[] serviceDescriptors = assembly.DefinedTypes
            .Where(type =>
                type is { IsAbstract: false, IsInterface: false } &&
                type.IsAssignableTo(typeof(IEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
            .Reverse()
            .ToArray();

        services.TryAddEnumerable(serviceDescriptors);

        return services;
    }

    public static IApplicationBuilder MapEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null )
    {
        ArgumentNullException.ThrowIfNull(app);

        IEnumerable<IEndpoint> endpoints = app.Services.GetServices<IEndpoint>();

        IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

        foreach (IEndpoint endpoint in endpoints)
        {
            endpoint.MapEndpoint(builder);
        }

        return app;
    }
}
