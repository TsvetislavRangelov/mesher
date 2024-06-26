using GeometryGeneratorNonSampled.Domain;
using GeometryGeneratorNonSampled.Services.Interfaces;
using GeometryGeneratorNonSampled.Utils;

namespace GeometryGeneratorNonSampled.Services.Implementation;
/// <summary>
/// Implements <see cref="IGeometryGeneratorNonSampled"/>.
/// </summary>
public class GeometryGeneratorNonSampledService : IGeometryGeneratorNonSampled
{
    private readonly Random _rand = new();
    public GeometryModel GenerateVertices(int? vertexCount, string? generatedFor)
    {
        if (vertexCount == 0)
        {
            vertexCount = 3; // set mininmum 3 vertices to be created if 0 are passed in.
        }
        var vertexArrayCapacity = vertexCount ?? _rand.Next(3, 25000);
        var vertices = new float[vertexArrayCapacity * 3];
        for (int i = 0; i < vertices.Length; i++)
        {
            var floatProduct = (float)_rand.NextDouble();
            if (i % 2 == 0)
            {
                floatProduct -= 1;
            }
            vertices[i] = floatProduct;
        }

        return new GeometryModel(GuidGenerator.GenerateUid(), vertices, generatedFor);
    }
}