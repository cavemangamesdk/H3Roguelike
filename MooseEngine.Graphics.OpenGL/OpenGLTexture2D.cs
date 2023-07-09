using MooseEngine.Extensions.SixLabors.ImageSharp;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MooseEngine.Graphics.OpenGL;

internal sealed class OpenGLTexture2D : ITexture2D
{
    public OpenGLTexture2D(IImageLoader imageLoader, string filepath, bool flipVertically = true)
    {
        RendererId = CreateTexture2D();

        GL.BindTexture(GLConstants.GL_TEXTURE_2D, RendererId);

        SetTextureParameters();

        var imageData = imageLoader.LoadImage(filepath, flipVertically);
        Width = imageData.Width;
        Height = imageData.Height;
        IntPtr pointer = IntPtr.Zero;
        if (imageData.Pixels != null)
        {
            pointer = Marshal.AllocHGlobal(imageData.Pixels.Length);
            Marshal.Copy(imageData.Pixels, 0, pointer, imageData.Pixels.Length);
        }
        GL.TexImage2D(GLConstants.GL_TEXTURE_2D, 0, GLConstants.GL_RGBA, imageData.Width, imageData.Height, 0, GLConstants.GL_RGBA, GLConstants.GL_UNSIGNED_BYTE, pointer);

        GL.GenerateMipmap(GLConstants.GL_TEXTURE_2D);
    }

    public OpenGLTexture2D(int width, int height)
    {
        RendererId = CreateTexture2D();
        Width = width;
        Height = height;

        GL.BindTexture(GLConstants.GL_TEXTURE_2D, RendererId);

        SetTextureParameters();

        GL.TextureStorage2D(RendererId, 1, GLConstants.GL_RGBA8, width, height);
    }

    private uint RendererId { get; }
    private int Width { get; }
    private int Height { get; }

    public void Bind(uint slot = 0)
    {
        GL.ActiveTexture(GLConstants.GL_TEXTURE0 + slot);
        GL.BindTexture(GLConstants.GL_TEXTURE_2D, RendererId);
    }

    public void SetData(IntPtr ptr, int size)
    {
        GL.TextureSubImage2D(RendererId, 0, 0, 0, Width, Height, GLConstants.GL_RGBA, GLConstants.GL_UNSIGNED_BYTE, ptr);
        GL.GenerateMipmap(GLConstants.GL_TEXTURE_2D);
    }

    private static void SetTextureParameters()
    {
        GL.TexParameteri(GLConstants.GL_TEXTURE_2D, GLConstants.GL_TEXTURE_WRAP_S, GLConstants.GL_REPEAT);
        GL.TexParameteri(GLConstants.GL_TEXTURE_2D, GLConstants.GL_TEXTURE_WRAP_T, GLConstants.GL_REPEAT);
        GL.TexParameteri(GLConstants.GL_TEXTURE_2D, GLConstants.GL_TEXTURE_MIN_FILTER, GLConstants.GL_NEAREST);
        GL.TexParameteri(GLConstants.GL_TEXTURE_2D, GLConstants.GL_TEXTURE_MAG_FILTER, GLConstants.GL_NEAREST);
    }

    private uint CreateTexture2D()
    {
        var textures = new uint[1];
        GL.GenTextures(1, textures);
        return textures[0];
    }
}