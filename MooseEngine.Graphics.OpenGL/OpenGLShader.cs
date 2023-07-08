using MooseEngine.Graphics.OpenGL.Enumerations;
using System.Text;

namespace MooseEngine.Graphics.OpenGL;

internal sealed class OpenGLShader : IShader
{
    private const string VertexShaderSource = """""
        #version 330 core
        layout (location = 0) in vec3 aPos;

        void main()
        {
            gl_Position = vec4(aPos, 1.0);
        }
        """"";

    private const string FragmentShaderSource = """""
        #version 330 core
        out vec4 FragColor;

        void main()
        {
            FragColor = vec4(1.0f, 0.5f, 0.2f, 1.0f);
        }
        """"";

    public OpenGLShader()
    {
        var vertexShader = CompileShader(GLConstants.GL_VERTEX_SHADER, VertexShaderSource);
        var fragmentShader = CompileShader(GLConstants.GL_FRAGMENT_SHADER, FragmentShaderSource);
        ShaderProgram = CreateShaderProgram(vertexShader, fragmentShader);
    }

    private uint ShaderProgram { get; }

    private uint CreateShaderProgram(uint vertexShader, uint fragmentShader)
    {
        var program = GL.CreateProgram();

        GL.AttachShader(program, vertexShader);
        GL.AttachShader(program, fragmentShader);
        GL.LinkProgram(program);

        var success = default(int);
        GL.GetProgramiv(program, GLConstants.GL_LINK_STATUS, ref success);
        if (success == (int)GLBoolean.False)
        {
            var infoLog = new byte[512];
            var length = 0;
            GL.GetProgramInfoLog(program, 512, ref length, infoLog);

            var infoLogStr = Encoding.UTF8.GetString(infoLog, 0, length);

            throw new Exception(infoLogStr);
        }

        GL.DeleteShader(vertexShader);
        GL.DeleteShader(fragmentShader);

        return program;
    }

    private uint CompileShader(uint shaderType, string shaderSource)
    {
        var shader = GL.CreateShader(shaderType);

        GL.ShaderSource(shader, 1, new string[1] { shaderSource }, default!);

        GL.CompileShader(shader);

        var success = default(int);
        GL.GetShaderiv(shader, GLConstants.GL_COMPILE_STATUS, ref success);
        if (success == (int)GLBoolean.False)
        {
            var infoLog = new byte[512];
            var length = 0;
            GL.GetShaderInfoLog(shader, 512, ref length, infoLog);

            throw new Exception();
        }

        return shader;
    }

    public void Bind()
    {
        GL.UseProgram(ShaderProgram);
    }
}
