using GeometryGeneratorNonSampled.Services.Interfaces;

namespace GeometryGeneratorNonSampled.Services.Implementation;
/// <summary>
/// Implements <see cref="IGeometryGeneratorNonSampled"/>.
/// </summary>
public class GeometryGeneratorNonSampledService : IGeometryGeneratorNonSampled
{
    private readonly Random _rand = new();
    public float[] GenerateVertices(int? vertexCount)
    {
        var vertexArrayCapacity = vertexCount ?? _rand.Next(3, 25000);
        var vertices = new float[vertexArrayCapacity * 3];
        for (int i = 0; i < vertices.Length; i++)
        {
            var floatProduct = (float)_rand.NextDouble();
            if(i % 2 == 0){
             floatProduct -= 1;   
            }
            vertices[i] = floatProduct;
        }
        return vertices;
    }
}