namespace GeometryGeneratorNonSampled.Domain;

/// <summary>
/// Domain model representing a generated geometry model.
/// </summary>
public class GeometryModel(string id, float[] vertexData, string? generatedFor)
{
    public string Id { get; set; } = id;
    public float[] VertexData { get; set; } = vertexData;
    public string? GeneratedFor { get; set; } = generatedFor;
}