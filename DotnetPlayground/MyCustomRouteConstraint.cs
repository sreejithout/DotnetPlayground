namespace DotnetPlayground.WebApi;

public class MyCustomRouteConstraint : IRouteConstraint
{
    public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        if (values.TryGetValue(routeKey, out object value))
        {
            if (value is string strValue)
            {
                return strValue.StartsWith("0");
            }
        }
        return false;
    }
}