namespace DotnetPlayground.WebApi.ExtensionMethods;

public static class RoutingConstraints
{
    public static void RegisterRoutingConstraints(this IServiceCollection services)
    {
        services.AddRouting(options =>
        {
            options.ConstraintMap.Add("mycustom", typeof(MyCustomRouteConstraint));
        });
    }
}
