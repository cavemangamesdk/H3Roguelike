﻿using MooseEngine.Graphics.OpenGL.Enumerations;

namespace MooseEngine.Graphics.OpenGL;

internal sealed class OpenGLRenderer : IRenderer
{
    public void Clear()
    {
        GL.Clear(GLClearMask.ColorBufferBit);
        GL.ClearColor(0.8f, 0.2f, 0.3f, 1.0f);
    }

    public void DrawGeometry(IPipeline? pipeline, IVertexBuffer? vertexBuffer)
    {
        // TODO: Throw if Pipeline or VertexBuffer is null!

        pipeline?.Bind();
        vertexBuffer?.Bind();

        GL.DrawArrays(GLConstants.GL_TRIANGLES, 0, 3);
    }

    public void DrawGeometry(IPipeline? pipeline, IVertexBuffer? vertexBuffer, IIndexBuffer? indexBuffer, int indexCount = 0)
    {
        // TODO: Throw if Pipeline or VertexBuffer is null!

        pipeline?.Bind();
        vertexBuffer?.Bind();
        indexBuffer?.Bind();

        indexCount = (indexCount == 0 && indexBuffer != default) ? indexBuffer.Count : indexCount;
        GL.DrawElements(GLConstants.GL_TRIANGLES, indexCount, GLConstants.GL_UNSIGNED_INT, IntPtr.Zero);

    }
}
