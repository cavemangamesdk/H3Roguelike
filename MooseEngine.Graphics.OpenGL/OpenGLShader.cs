using MooseEngine.Graphics.OpenGL.Enumerations;
using System.Text;

namespace MooseEngine.Graphics.OpenGL;

internal sealed class OpenGLShader : IShader
{
    enum ShaderType
    {
        None = 0,
        Vertex = 1,
        Fragment = 2
    };
    const string TYPE_KEYWORD = "#type";

    private IDictionary<string, uint> _uniformLocations;

    public OpenGLShader(string filepath)
    {
        var shaderSources = ReadShaderFile(filepath);

        var vertexShader = CompileShader(GLConstants.GL_VERTEX_SHADER, shaderSources[ShaderType.Vertex]);
        var fragmentShader = CompileShader(GLConstants.GL_FRAGMENT_SHADER, shaderSources[ShaderType.Fragment]);

        ShaderProgram = CreateShaderProgram(vertexShader, fragmentShader);

        GetActiveUniforms();
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

    private void GetActiveUniforms()
    {
        var output = default(int);
        GL.GetProgramiv(ShaderProgram, GLConstants.GL_ACTIVE_UNIFORMS, ref output);
        var activeUniformsCount = output;
        _uniformLocations = new Dictionary<string, uint>(activeUniformsCount);

        for (uint i = 0; i < activeUniformsCount; i++)
        {
            GL.GetActiveUniform(ShaderProgram, i, 128, out _, out _, out _, out string name);

            var location = GL.GetUniformLocation(ShaderProgram, name);

            _uniformLocations[name] = location;
        }

        Console.WriteLine(activeUniformsCount);
        //Logger.Information($"Loaded shader '{shaderName}' with {activeUniformsCount} active uniforms");
    }

    private IDictionary<ShaderType, string> ReadShaderFile(string filepath)
    {
        var lines = File.ReadAllLines(filepath);
        var shaderType = ShaderType.None;
        IDictionary<ShaderType, string> shaderSources = new Dictionary<ShaderType, string>();

        var shaderSource = string.Empty;
        foreach (var line in lines)
        {
            if (line.Contains(TYPE_KEYWORD))
            {
                if (!string.IsNullOrWhiteSpace(shaderSource))
                {
                    shaderSources[shaderType] = shaderSource;
                    shaderSource = string.Empty;
                }

                var type = line.Substring(TYPE_KEYWORD.Length + 1, line.Length - (TYPE_KEYWORD.Length + 1));
                type = string.Concat(type[0].ToString().ToUpper(), type.AsSpan(1));
                shaderType = (ShaderType)Enum.Parse(typeof(ShaderType), type);
                shaderSources.Add(shaderType, "");
                continue;
            }

            shaderSource += line + "\n";
        }

        shaderSources[shaderType] = shaderSource;
        return shaderSources;
    }
}
