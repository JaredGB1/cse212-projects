using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

public class FeatureCollection
{
    // TODO Problem 5 
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public double mag { get; set; }
    public string place { get; set; }
    public long time { get; set; }

}