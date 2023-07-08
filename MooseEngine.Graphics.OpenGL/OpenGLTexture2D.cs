using MooseEngine.Extensions.SixLabors.ImageSharp;
using System.Runtime.InteropServices;

namespace MooseEngine.Graphics.OpenGL;

internal sealed class OpenGLTexture2D : ITexture2D
{
    public OpenGLTexture2D(IImageLoader imageLoader, string filepath, bool flipVertically = true)
    {
        var textures = new uint[1];
        GL.GenTextures(1, textures);
        RendererId = textures[0];

        GL.BindTexture(GLConstants.GL_TEXTURE_2D, RendererId);

        GL.TexParameteri(GLConstants.GL_TEXTURE_2D, GLConstants.GL_TEXTURE_WRAP_S, GLConstants.GL_REPEAT);
        GL.TexParameteri(GLConstants.GL_TEXTURE_2D, GLConstants.GL_TEXTURE_WRAP_T, GLConstants.GL_REPEAT);
        GL.TexParameteri(GLConstants.GL_TEXTURE_2D, GLConstants.GL_TEXTURE_MIN_FILTER, GLConstants.GL_NEAREST);
        GL.TexParameteri(GLConstants.GL_TEXTURE_2D, GLConstants.GL_TEXTURE_MAG_FILTER, GLConstants.GL_NEAREST);

        var imageData = imageLoader.LoadImage(filepath, flipVertically);
        IntPtr pointer = IntPtr.Zero;
        if (imageData.Pixels != null)
        {
            pointer = Marshal.AllocHGlobal(imageData.Pixels.Length);
            Marshal.Copy(imageData.Pixels, 0, pointer, imageData.Pixels.Length);
        }
        GL.TexImage2D(GLConstants.GL_TEXTURE_2D, 0, GLConstants.GL_RGBA, imageData.Width, imageData.Height, 0, GLConstants.GL_RGBA, GLConstants.GL_UNSIGNED_BYTE, pointer);

        GL.GenerateMipmap(GLConstants.GL_TEXTURE_2D);
    }

    private uint RendererId { get; }

    public void Bind(uint slot = 0)
    {
        GL.ActiveTexture(GLConstants.GL_TEXTURE0 + slot);
        GL.BindTexture(GLConstants.GL_TEXTURE_2D, RendererId);
    }
}