namespace MooseEngine.Graphics;

public class BufferLayout
{
    public int Stride { get; private set; }
    public List<BufferElement> Elements { get; }

    public BufferLayout(List<BufferElement> elements)
    {
        Elements = elements;
        CalculateOffsetAndStride();
    }

    private void CalculateOffsetAndStride()
    {
        int offset = 0;
        Stride = 0;
        foreach (BufferElement element in Elements)
        {
            element.Offset = offset;
            offset += element.Size;
            Stride += element.Size;
        }
    }
}

public class BufferElement
{
    public BufferElement(string name, ShaderDataType type, bool normalized = false)
    {
        Name = name;
        Type = type;
        Offset = 0;
        Size = ShaderHelper.ShaderDataTypeSize(Type);
        Normalized = normalized;
    }

    public string? Name { get; set; }
    public ShaderDataType Type { get; set; }
    public int Offset { get; set; }
    public int Size { get; set; }
    public bool Normalized { get; set; }

    public int GetComponentCount()
    {
        return Type switch
        {
            ShaderDataType.Float => 1,
            ShaderDataType.Float2 => 2,
            ShaderDataType.Float3 => 3,
            ShaderDataType.Float4 => 4,
            ShaderDataType.Int => 1,
            ShaderDataType.Int2 => 2,
            ShaderDataType.Int3 => 3,
            ShaderDataType.Int4 => 4,
            ShaderDataType.Mat3 => 3 * 3,
            ShaderDataType.Mat4 => 4 * 4,
            ShaderDataType.Bool => 1,
            _ => 0,
        };
    }
}

public enum ShaderDataType
{
    None = 0,
    Bool,
    Mat3, Mat4,
    Float, Float2, Float3, Float4,
    Int, Int2, Int3, Int4,
}

public static class ShaderHelper
{
    public static uint ShaderDataTypeToOpenGLBaseType(ShaderDataType type)
    {
        return type switch
        {
            ShaderDataType.Float => 0x1406,     // GL_FLOAT
            ShaderDataType.Float2 => 0x1406,    // GL_FLOAT
            ShaderDataType.Float3 => 0x1406,    // GL_FLOAT
            ShaderDataType.Float4 => 0x1406,    // GL_FLOAT
            ShaderDataType.Int => 0x1404,       // GL_INT
            ShaderDataType.Int2 => 0x1404,      // GL_INT
            ShaderDataType.Int3 => 0x1404,      // GL_INT
            ShaderDataType.Int4 => 0x1404,      // GL_INT
            ShaderDataType.Mat3 => 0x1406,      // GL_FLOAT
            ShaderDataType.Mat4 => 0x1406,      // GL_FLOAT
            //ShaderDataType.Bool => GL.GL_BOOL,
            _ => 0,
        };
    }

    public static int ShaderDataTypeSize(ShaderDataType type)
    {
        return type switch
        {
            ShaderDataType.Float => 4,
            ShaderDataType.Float2 => 4 * 2,
            ShaderDataType.Float3 => 4 * 3,
            ShaderDataType.Float4 => 4 * 4,
            ShaderDataType.Mat3 => 4 * 3 * 3,
            ShaderDataType.Mat4 => 4 * 4 * 4,
            ShaderDataType.Int => 4,
            ShaderDataType.Int2 => 4 * 2,
            ShaderDataType.Int3 => 4 * 3,
            ShaderDataType.Int4 => 4 * 4,
            ShaderDataType.Bool => 1,
            _ => 0,
        };
    }
}
