﻿namespace MooseEngine.Graphics.OpenGL.Enumerations;

public enum GLBufferUsage : uint
{
    StreamDraw = GLConstants.GL_STREAM_DRAW,
    StreamRead = GLConstants.GL_STREAM_READ,
    StreamCopy = GLConstants.GL_STREAM_COPY,

    StaticDraw = GLConstants.GL_STATIC_DRAW,
    StaticRead = GLConstants.GL_STATIC_READ,
    StaticCopy = GLConstants.GL_STATIC_COPY,

    DynamicDraw = GLConstants.GL_DYNAMIC_DRAW,
    DynamicRead = GLConstants.GL_DYNAMIC_READ,
    DynamicCopy = GLConstants.GL_DYNAMIC_COPY
}