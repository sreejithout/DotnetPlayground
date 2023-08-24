namespace SharedPocos.Options;

public class AppOptions
{
    public const string appConfigOptions = "appOptions";
    public AngularFeatureOptions AngularFeatureOptions { get; set; }
    public CSharpFeatureOptions CSharpFeatures { get; set; }
    public DotnetFeatureOptions DotnetFeatures { get; set; }
}
