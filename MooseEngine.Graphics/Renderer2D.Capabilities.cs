namespace MooseEngine.Graphics;

internal sealed partial class Renderer2D
{
    internal class Capabilities
    {
        public const int MaxQuads = 200000;
        public const int MaxVertices = MaxQuads * 4;
        public const int MaxIndices = MaxQuads * 6;
        public const int MaxTextureSlots = 32; // 32 is the max for OpenGL, 16 for DirectX
    }
}
