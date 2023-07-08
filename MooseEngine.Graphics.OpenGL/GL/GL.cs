using MooseEngine.Graphics.OpenGL.Enumerations;
using System.Runtime.InteropServices;

namespace MooseEngine.Graphics.OpenGL;

public partial class GL
{
    public static void Clear(GLClearMask clearMask) => Clear((uint)clearMask);
    public static void Clear(uint mask) => Functions.glClear(mask);
    public static void ClearColor(float red, float green, float blue, float alpha) => Functions.glClearColor(red, green, blue, alpha);

    public static void Enable(uint capability) => Functions.glEnable(capability);

    public static void BlendFunc(uint sfactor, uint dfactor) => Functions.glBlendFunc(sfactor, dfactor);

    public static void VertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer) => Native.glVertexAttribPointer(index, size, type, normalized, stride, pointer);
    public static void EnableVertexAttribArray(uint index) => Native.glEnableVertexAttribArray(index);

    // Vertex Arrays
    public static void GenVertexArrays(int count, uint[] vertexArrays) => Native.glGenVertexArrays(count, vertexArrays);
    public static void BindVertexArray(uint vertexArray) => Native.glBindVertexArray(vertexArray);
    public static void DeleteVertexArrays(int count, uint[] vertexArrays) => Native.glDeleteVertexArrays(count, vertexArrays);

    // Buffers
    public static void GenBuffers(int count, uint[] buffers) => Native.glGenBuffers(count, buffers);
    public static void BindBuffer(uint target, uint buffer) => Native.glBindBuffer(target, buffer);
    public static void BufferData1(uint type, int size, object data, uint usage) => Native.glBufferData(type, size, data, usage);
    public static void BufferData(uint target, int size, float[] data, uint usage) => Native.glBufferData(target, size, data, usage);
    public static void BufferData(uint target, int size, uint[] data, uint usage) => Native.glBufferData(target, size, data, usage);
    public static void BufferSubData(uint target, int offset, int size, float[] data) => Native.glBufferSubData(target, offset, size, data);
    public static void BindBufferBase(uint target, uint binding, uint buffer) => Native.glBindBufferBase(target, binding, buffer);

    // Texturesdd
    public static void GenTextures(int count, uint[] textures) => Functions.glGenTextures(count, textures);
    public static void BindTexture(uint target, uint texture) => Functions.glBindTexture(target, texture);
    public static void ActiveTexture(uint texture) => Native.glActiveTexture(texture);
    public static void TexImage2D(uint target, int level, uint internalFormat, int width, int height, int border, uint format, uint type, IntPtr data) => Functions.glTexImage2D(target, level, internalFormat, width, height, border, format, type, data);

    public static void TexParameteri(uint target, uint pname, uint param) => Functions.glTexParameteri(target, pname, param);

    public static void GenerateMipmap(uint target) => Native.glGenerateMipmap(target);

    // Shaders
    public static uint CreateShader(uint type) => Native.glCreateShader(type);
    public static void ShaderSource(uint shader, int count, string[] @string, int[] length) => Native.glShaderSource(shader, count, @string, length);
    public static void CompileShader(uint shader) => Native.glCompileShader(shader);
    public static void DeleteShader(uint shader) => Native.glDeleteShader(shader);

    public static void GetShaderiv(uint shader, uint pname, ref int @params) => Native.glGetShaderiv(shader, pname, ref @params);
    public static void GetShaderInfoLog(uint shader, int bufSize, ref int length, byte[] infoLog) => Native.glGetShaderInfoLog(shader, bufSize, ref length, infoLog);

    // Uniforms
    public static void UniformMatrix4fv(uint location, int count, bool transpose, float[] matrix) => Native.glUniformMatrix4fv(location, count, transpose, matrix);
    public static void UniformMatrix1i(uint location, int value) => Native.glUniform1i(location, value);
    public static void GetActiveUniform(uint id, uint index, int bufferSize, out int length, out int size, out uint type, out string name)
    {
        int l = default;
        int s = default;
        uint t = default;
        string n = new(' ', bufferSize);

        // TODO: Remove unsafe
        unsafe
        {
            char* ptr = (char*)Marshal.StringToHGlobalAnsi(n).ToPointer();
            Native.glGetActiveUniform(id, index, bufferSize, &l, &s, &t, ptr);

            length = l;
            size = s;
            type = t;
            name = Marshal.PtrToStringAnsi(ptr: (IntPtr)ptr);
        }
    }
    public static uint GetUniformLocation(uint program, string name) => Native.glGetUniformLocation(program, name);

    // Shader programs
    public static uint CreateProgram() => Native.glCreateProgram();
    public static void AttachShader(uint program, uint shader) => Native.glAttachShader(program, shader);
    public static void LinkProgram(uint program) => Native.glLinkProgram(program);
    public static void UseProgram(uint program) => Native.glUseProgram(program);

    public static void GetProgramiv(uint shader, uint pname, ref int @params) => Native.glGetProgramiv(shader, pname, ref @params);
    public static void GetProgramInfoLog(uint shader, int bufSize, ref int length, byte[] infoLog) => Native.glGetProgramInfoLog(shader, bufSize, ref length, infoLog);

    // Draw calls
    public static void DrawArrays(uint mode, int first, int count) => Functions.glDrawArrays(mode, first, count);
    public static void DrawElements(uint mode, int count, uint type, IntPtr indices) => Functions.glDrawElements(mode, count, type, indices);
}
