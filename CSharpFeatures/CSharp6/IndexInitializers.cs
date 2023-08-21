using System.Text.Json.Nodes;

namespace CSharpFeatures.CSharp6
{
    internal class IndexInitializers
    {
        public int X { get; }
        public int Y { get; }

        public IndexInitializers(int x, int y)
        {
            X = x;
            Y = y;
        }

        public JsonObject ToJson() =>
            new JsonObject() { ["x"] = X, ["y"] = Y }; // 1. we needed to add the index setters (["x"]) like result["x"] = X; before this feature.

    }
}
