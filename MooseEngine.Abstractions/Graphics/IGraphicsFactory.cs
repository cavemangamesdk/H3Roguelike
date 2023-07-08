﻿namespace MooseEngine.Graphics;

public interface IBindable
{
    void Bind();
}

public interface IGraphicsFactory
{
    IPipeline CreatePipeline(IShader shader, BufferLayout bufferLayout);

    IVertexBuffer CreateVertexBuffer(float[] vertices);
    IVertexBuffer CreateVertexBuffer(float[] vertices, int size);

    IIndexBuffer CreateIndexBuffer(uint[] indices);
    IIndexBuffer CreateIndexBuffer(uint[] indices, int count);

    IShader CreateShader();
    IShader CreateShader(string filepath);

    IUniformBuffer CreateUniformBuffer(int size, uint binding);

    ITexture2D CreateTexture2D(string filepath);
}
