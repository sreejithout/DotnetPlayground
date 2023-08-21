using Newtonsoft.Json.Linq;

namespace CSharpFeatures.CSharp6
{
    internal class NullConditionalOperators
    {
        public static string FromJson(JObject json)
        {
            if (json?["x"]?.Type == JTokenType.Integer) // 1. does null checks with "?."
                return "x";
            return "";
        }
    }
}
