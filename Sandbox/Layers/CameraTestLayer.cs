﻿using MooseEngine;
using MooseEngine.Graphics;
using MooseEngine.Mathematics;
using MooseEngine.Mathematics.Matrixes;
using MooseEngine.Mathematics.Vectors;

class CameraTestLayer : LayerBase
{
    public CameraTestLayer(IWindow window, IRenderer renderer, IGraphicsFactory graphicsFactory)
        : base("Camera Test Layer")
    {
        Window = window;
        Renderer = renderer;
        GraphicsFactory = graphicsFactory;
    }

    private IWindow Window { get; }
    private IRenderer Renderer { get; }
    private IGraphicsFactory GraphicsFactory { get; }

    // Runtime
    private CameraData cameraData;
    private OrthographicCamera Camera { get; set; }
    private IUniformBuffer UniformBuffer { get; set; }

    Vector3 viewPosition = new Vector3(0.0f, 0.0f, 0.0f);
    Matrix4 viewMatrix = Matrix4.Identity;

    private IPipeline? Pipeline { get; set; }
    private IVertexBuffer? VertexBuffer { get; set; }
    private IIndexBuffer? IndexBuffer { get; set; }
    private ITexture2D? Texture1 { get; set; }
    private ITexture2D? Texture2 { get; set; }

    public override void OnAttach()
    {
        Camera = new OrthographicCamera(2.0f);
        Camera.SetViewport(Window.Width, Window.Height);

        UniformBuffer = GraphicsFactory.CreateUniformBuffer(140, 0);

        var shader = GraphicsFactory.CreateShader("Assets/Shaders/CameraTest.glsl");

        var bufferLayout = new BufferLayout(new List<BufferElement>
        {
            new BufferElement("POSITION", ShaderDataType.Float3),
            new BufferElement("COLOR", ShaderDataType.Float3),
            new BufferElement("TEXCOORD", ShaderDataType.Float2)
        });
        Pipeline = GraphicsFactory.CreatePipeline(shader, bufferLayout);

        var vertices = new float[4 * (3 + 3 + 2)] {
            // Position             // Colors           // TexCoord
             0.5f,  0.5f, 0.0f,     1.0f, 1.0f, 1.0f,   1.0f, 1.0f,  // top right
             0.5f, -0.5f, 0.0f,     1.0f, 1.0f, 1.0f,   1.0f, 0.0f,  // bottom right
            -0.5f, -0.5f, 0.0f,     1.0f, 1.0f, 1.0f,   0.0f, 0.0f,  // bottom left
            -0.5f,  0.5f, 0.0f,     1.0f, 1.0f, 1.0f,   0.0f, 1.0f   // top left 
        };

        VertexBuffer = GraphicsFactory.CreateVertexBuffer(vertices);

        var indices = new uint[] {  // note that we start from 0!
            0, 1, 3,   // first triangle
            1, 2, 3    // second triangle
        };
        IndexBuffer = GraphicsFactory.CreateIndexBuffer(indices);

        Texture1 = GraphicsFactory.CreateTexture2D("Assets/Textures/container.jpg");
        Texture2 = GraphicsFactory.CreateTexture2D("Assets/Textures/awesomeface.png");

        shader.Bind();
        shader.SetInt("texture1", 0);
        shader.SetInt("texture2", 1);
    }

    public override void OnDetach()
    {
    }

    public override void Update(float deltaTime)
    {
        cameraData.ProjectionMatrix = Camera.Projection.ToFloatArray();
        cameraData.ViewMatrix = Camera.View.ToFloatArray();
        cameraData.ViewPosition = viewPosition.ToFloatArray();

        UniformBuffer.SetData(cameraData.ProjectionMatrix, (4 * 4) * sizeof(float));
        UniformBuffer.SetData(cameraData.ViewMatrix, (4 * 4) * sizeof(float), 64);
        UniformBuffer.SetData(cameraData.ViewPosition, 3 * sizeof(float), 128);

        Renderer.Clear();

        Texture1?.Bind();
        Texture2?.Bind(1);
        Renderer.DrawGeometry(Pipeline, VertexBuffer, IndexBuffer);
    }
}

public struct CameraData
{
    public float[] ProjectionMatrix { get; set; }   // Matrix4 (4 * 4 * sizeof(float)) = 64 bytes
    public float[] ViewMatrix { get; set; }         // Matrix4 (4 * 4 * sizeof(float)) = 64 bytes
    public float[] ViewPosition { get; set; }       // Vector3 (3 * sizeof(float)) = 12 bytes
}                                                   // Total = 140 bytes
