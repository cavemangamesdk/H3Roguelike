﻿using MooseEngine.Graphics.OpenGL.Enumerations;

namespace MooseEngine.Graphics.OpenGL;

internal sealed class OpenGLRenderer : IRenderer
{
    public void Clear()
    {
        GL.Clear(GLClearMask.ColorBufferBit);
        GL.ClearColor(0.8f, 0.2f, 0.3f, 1.0f);
    }
}