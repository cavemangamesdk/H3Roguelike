using System.Runtime.InteropServices;

namespace MooseEngine.Graphics.OpenGL;

public partial class GL
{
    internal class Native
    {
        internal const string Library = "opengl32.dll";

        public static void glDrawRangeElements(uint mode, uint start, uint end, int count, uint type, IntPtr indices)
        {
            GetDelegateFor<Delegates.glDrawRangeElementsDelegate>()(mode, start, end, count, type, indices);
        }

        public static void glTexImage3D(uint target, int level, int internalformat, int width, int height, int depth, int border, uint format, uint type, IntPtr pixels)
        {
            GetDelegateFor<Delegates.glTexImage3DDelegate>()(target, level, internalformat, width, height, depth, border, format, type, pixels);
        }

        public static void glTexSubImage3D(uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, IntPtr pixels)
        {
            GetDelegateFor<Delegates.glTexSubImage3DDelegate>()(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
        }

        public static void glCopyTexSubImage3D(uint target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height)
        {
            GetDelegateFor<Delegates.glCopyTexSubImage3DDelegate>()(target, level, xoffset, yoffset, zoffset, x, y, width, height);
        }

        public static void glActiveTexture(uint texture)
        {
            GetDelegateFor<Delegates.glActiveTextureDelegate>()(texture);
        }

        public static void glSampleCoverage(float value, bool invert)
        {
            GetDelegateFor<Delegates.glSampleCoverageDelegate>()(value, invert);
        }

        public static void glCompressedTexImage3D(uint target, int level, uint internalformat, int width, int height, int depth, int border, int imageSize, IntPtr data)
        {
            GetDelegateFor<Delegates.glCompressedTexImage3DDelegate>()(target, level, internalformat, width, height, depth, border, imageSize, data);
        }

        public static void glCompressedTexImage2D(uint target, int level, uint internalformat, int width, int height, int border, int imageSize, IntPtr data)
        {
            GetDelegateFor<Delegates.glCompressedTexImage2DDelegate>()(target, level, internalformat, width, height, border, imageSize, data);
        }

        public static void glCompressedTexImage1D(uint target, int level, uint internalformat, int width, int border, int imageSize, IntPtr data)
        {
            GetDelegateFor<Delegates.glCompressedTexImage1DDelegate>()(target, level, internalformat, width, border, imageSize, data);
        }

        public static void glCompressedTexSubImage3D(uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, int imageSize, IntPtr data)
        {
            GetDelegateFor<Delegates.glCompressedTexSubImage3DDelegate>()(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data);
        }

        public static void glCompressedTexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, int imageSize, IntPtr data)
        {
            GetDelegateFor<Delegates.glCompressedTexSubImage2DDelegate>()(target, level, xoffset, yoffset, width, height, format, imageSize, data);
        }

        public static void glCompressedTexSubImage1D(uint target, int level, int xoffset, int width, uint format, int imageSize, IntPtr data)
        {
            GetDelegateFor<Delegates.glCompressedTexSubImage1DDelegate>()(target, level, xoffset, width, format, imageSize, data);
        }

        public static void glGetCompressedTexImage(uint target, int level, IntPtr img)
        {
            GetDelegateFor<Delegates.glGetCompressedTexImageDelegate>()(target, level, img);
        }

        public static void glClientActiveTexture(uint texture)
        {
            GetDelegateFor<Delegates.glClientActiveTextureDelegate>()(texture);
        }

        public static void glMultiTexCoord1d(uint target, double s)
        {
            GetDelegateFor<Delegates.glMultiTexCoord1dDelegate>()(target, s);
        }

        public static void glMultiTexCoord1dv(uint target, double[] v)
        {
            GetDelegateFor<Delegates.glMultiTexCoord1dvDelegate>()(target, v);
        }

        public static void glMultiTexCoord1f(uint target, float s)
        {
            GetDelegateFor<Delegates.glMultiTexCoord1fDelegate>()(target, s);
        }

        public static void glMultiTexCoord1fv(uint target, float[] v)
        {
            GetDelegateFor<Delegates.glMultiTexCoord1fvDelegate>()(target, v);
        }

        public static void glMultiTexCoord1i(uint target, int s)
        {
            GetDelegateFor<Delegates.glMultiTexCoord1iDelegate>()(target, s);
        }

        public static void glMultiTexCoord1iv(uint target, int[] v)
        {
            GetDelegateFor<Delegates.glMultiTexCoord1ivDelegate>()(target, v);
        }

        public static void glMultiTexCoord1s(uint target, short s)
        {
            GetDelegateFor<Delegates.glMultiTexCoord1sDelegate>()(target, s);
        }

        public static void glMultiTexCoord1sv(uint target, short[] v)
        {
            GetDelegateFor<Delegates.glMultiTexCoord1svDelegate>()(target, v);
        }

        public static void glMultiTexCoord2d(uint target, double s, double t)
        {
            GetDelegateFor<Delegates.glMultiTexCoord2dDelegate>()(target, s, t);
        }

        public static void glMultiTexCoord2dv(uint target, double[] v)
        {
            GetDelegateFor<Delegates.glMultiTexCoord2dvDelegate>()(target, v);
        }

        public static void glMultiTexCoord2f(uint target, float s, float t)
        {
            GetDelegateFor<Delegates.glMultiTexCoord2fDelegate>()(target, s, t);
        }

        public static void glMultiTexCoord2fv(uint target, float[] v)
        {
            GetDelegateFor<Delegates.glMultiTexCoord2fvDelegate>()(target, v);
        }

        public static void glMultiTexCoord2i(uint target, int s, int t)
        {
            GetDelegateFor<Delegates.glMultiTexCoord2iDelegate>()(target, s, t);
        }

        public static void glMultiTexCoord2iv(uint target, int[] v)
        {
            GetDelegateFor<Delegates.glMultiTexCoord2ivDelegate>()(target, v);
        }

        public static void glMultiTexCoord2s(uint target, short s, short t)
        {
            GetDelegateFor<Delegates.glMultiTexCoord2sDelegate>()(target, s, t);
        }

        public static void glMultiTexCoord2sv(uint target, short[] v)
        {
            GetDelegateFor<Delegates.glMultiTexCoord2svDelegate>()(target, v);
        }

        public static void glMultiTexCoord3d(uint target, double s, double t, double r)
        {
            GetDelegateFor<Delegates.glMultiTexCoord3dDelegate>()(target, s, t, r);
        }

        public static void glMultiTexCoord3dv(uint target, double[] v)
        {
            GetDelegateFor<Delegates.glMultiTexCoord3dvDelegate>()(target, v);
        }

        public static void glMultiTexCoord3f(uint target, float s, float t, float r)
        {
            GetDelegateFor<Delegates.glMultiTexCoord3fDelegate>()(target, s, t, r);
        }

        public static void glMultiTexCoord3fv(uint target, float[] v)
        {
            GetDelegateFor<Delegates.glMultiTexCoord3fvDelegate>()(target, v);
        }

        public static void glMultiTexCoord3i(uint target, int s, int t, int r)
        {
            GetDelegateFor<Delegates.glMultiTexCoord3iDelegate>()(target, s, t, r);
        }

        public static void glMultiTexCoord3iv(uint target, int[] v)
        {
            GetDelegateFor<Delegates.glMultiTexCoord3ivDelegate>()(target, v);
        }

        public static void glMultiTexCoord3s(uint target, short s, short t, short r)
        {
            GetDelegateFor<Delegates.glMultiTexCoord3sDelegate>()(target, s, t, r);
        }

        public static void glMultiTexCoord3sv(uint target, short[] v)
        {
            GetDelegateFor<Delegates.glMultiTexCoord3svDelegate>()(target, v);
        }

        public static void glMultiTexCoord4d(uint target, double s, double t, double r, double q)
        {
            GetDelegateFor<Delegates.glMultiTexCoord4dDelegate>()(target, s, t, r, q);
        }

        public static void glMultiTexCoord4dv(uint target, double[] v)
        {
            GetDelegateFor<Delegates.glMultiTexCoord4dvDelegate>()(target, v);
        }

        public static void glMultiTexCoord4f(uint target, float s, float t, float r, float q)
        {
            GetDelegateFor<Delegates.glMultiTexCoord4fDelegate>()(target, s, t, r, q);
        }

        public static void glMultiTexCoord4fv(uint target, float[] v)
        {
            GetDelegateFor<Delegates.glMultiTexCoord4fvDelegate>()(target, v);
        }

        public static void glMultiTexCoord4i(uint target, int s, int t, int r, int q)
        {
            GetDelegateFor<Delegates.glMultiTexCoord4iDelegate>()(target, s, t, r, q);
        }

        public static void glMultiTexCoord4iv(uint target, int[] v)
        {
            GetDelegateFor<Delegates.glMultiTexCoord4ivDelegate>()(target, v);
        }

        public static void glMultiTexCoord4s(uint target, short s, short t, short r, short q)
        {
            GetDelegateFor<Delegates.glMultiTexCoord4sDelegate>()(target, s, t, r, q);
        }

        public static void glMultiTexCoord4sv(uint target, short[] v)
        {
            GetDelegateFor<Delegates.glMultiTexCoord4svDelegate>()(target, v);
        }

        public static void glLoadTransposeMatrixf(float[] m)
        {
            GetDelegateFor<Delegates.glLoadTransposeMatrixfDelegate>()(m);
        }

        public static void glLoadTransposeMatrixd(double[] m)
        {
            GetDelegateFor<Delegates.glLoadTransposeMatrixdDelegate>()(m);
        }

        public static void glMultTransposeMatrixf(float[] m)
        {
            GetDelegateFor<Delegates.glMultTransposeMatrixfDelegate>()(m);
        }

        public static void glMultTransposeMatrixd(double[] m)
        {
            GetDelegateFor<Delegates.glMultTransposeMatrixdDelegate>()(m);
        }

        public static void glBlendFuncSeparate(uint sfactorRGB, uint dfactorRGB, uint sfactorAlpha, uint dfactorAlpha)
        {
            GetDelegateFor<Delegates.glBlendFuncSeparateDelegate>()(sfactorRGB, dfactorRGB, sfactorAlpha, dfactorAlpha);
        }

        public static void glMultiDrawArrays(uint mode, int[] first, int[] count, int drawcount)
        {
            GetDelegateFor<Delegates.glMultiDrawArraysDelegate>()(mode, first, count, drawcount);
        }

        public static void glMultiDrawElements(uint mode, int[] count, uint type, IntPtr indices, int drawcount)
        {
            GetDelegateFor<Delegates.glMultiDrawElementsDelegate>()(mode, count, type, indices, drawcount);
        }

        public static void glPointParameterf(uint pname, float param)
        {
            GetDelegateFor<Delegates.glPointParameterfDelegate>()(pname, param);
        }

        public static void glPointParameterfv(uint pname, float[] @params)
        {
            GetDelegateFor<Delegates.glPointParameterfvDelegate>()(pname, @params);
        }

        public static void glPointParameteri(uint pname, int param)
        {
            GetDelegateFor<Delegates.glPointParameteriDelegate>()(pname, param);
        }

        public static void glPointParameteriv(uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glPointParameterivDelegate>()(pname, @params);
        }

        public static void glFogCoordf(float coord)
        {
            GetDelegateFor<Delegates.glFogCoordfDelegate>()(coord);
        }

        public static void glFogCoordfv(float[] coord)
        {
            GetDelegateFor<Delegates.glFogCoordfvDelegate>()(coord);
        }

        public static void glFogCoordd(double coord)
        {
            GetDelegateFor<Delegates.glFogCoorddDelegate>()(coord);
        }

        public static void glFogCoorddv(double[] coord)
        {
            GetDelegateFor<Delegates.glFogCoorddvDelegate>()(coord);
        }

        public static void glFogCoordPointer(uint type, int stride, IntPtr pointer)
        {
            GetDelegateFor<Delegates.glFogCoordPointerDelegate>()(type, stride, pointer);
        }

        public static void glSecondaryColor3b(byte red, byte green, byte blue)
        {
            GetDelegateFor<Delegates.glSecondaryColor3bDelegate>()(red, green, blue);
        }

        public static void glSecondaryColor3bv(byte[] v)
        {
            GetDelegateFor<Delegates.glSecondaryColor3bvDelegate>()(v);
        }

        public static void glSecondaryColor3d(double red, double green, double blue)
        {
            GetDelegateFor<Delegates.glSecondaryColor3dDelegate>()(red, green, blue);
        }

        public static void glSecondaryColor3dv(double[] v)
        {
            GetDelegateFor<Delegates.glSecondaryColor3dvDelegate>()(v);
        }

        public static void glSecondaryColor3f(float red, float green, float blue)
        {
            GetDelegateFor<Delegates.glSecondaryColor3fDelegate>()(red, green, blue);
        }

        public static void glSecondaryColor3fv(float[] v)
        {
            GetDelegateFor<Delegates.glSecondaryColor3fvDelegate>()(v);
        }

        public static void glSecondaryColor3i(int red, int green, int blue)
        {
            GetDelegateFor<Delegates.glSecondaryColor3iDelegate>()(red, green, blue);
        }

        public static void glSecondaryColor3iv(int[] v)
        {
            GetDelegateFor<Delegates.glSecondaryColor3ivDelegate>()(v);
        }

        public static void glSecondaryColor3s(short red, short green, short blue)
        {
            GetDelegateFor<Delegates.glSecondaryColor3sDelegate>()(red, green, blue);
        }

        public static void glSecondaryColor3sv(short[] v)
        {
            GetDelegateFor<Delegates.glSecondaryColor3svDelegate>()(v);
        }

        public static void glSecondaryColor3ub(byte red, byte green, byte blue)
        {
            GetDelegateFor<Delegates.glSecondaryColor3ubDelegate>()(red, green, blue);
        }

        public static void glSecondaryColor3ubv(byte[] v)
        {
            GetDelegateFor<Delegates.glSecondaryColor3ubvDelegate>()(v);
        }

        public static void glSecondaryColor3ui(uint red, uint green, uint blue)
        {
            GetDelegateFor<Delegates.glSecondaryColor3uiDelegate>()(red, green, blue);
        }

        public static void glSecondaryColor3uiv(uint[] v)
        {
            GetDelegateFor<Delegates.glSecondaryColor3uivDelegate>()(v);
        }

        public static void glSecondaryColor3us(ushort red, ushort green, ushort blue)
        {
            GetDelegateFor<Delegates.glSecondaryColor3usDelegate>()(red, green, blue);
        }

        public static void glSecondaryColor3usv(ushort[] v)
        {
            GetDelegateFor<Delegates.glSecondaryColor3usvDelegate>()(v);
        }

        public static void glSecondaryColorPointer(int size, uint type, int stride, IntPtr pointer)
        {
            GetDelegateFor<Delegates.glSecondaryColorPointerDelegate>()(size, type, stride, pointer);
        }

        public static void glWindowPos2d(double x, double y)
        {
            GetDelegateFor<Delegates.glWindowPos2dDelegate>()(x, y);
        }

        public static void glWindowPos2dv(double[] v)
        {
            GetDelegateFor<Delegates.glWindowPos2dvDelegate>()(v);
        }

        public static void glWindowPos2f(float x, float y)
        {
            GetDelegateFor<Delegates.glWindowPos2fDelegate>()(x, y);
        }

        public static void glWindowPos2fv(float[] v)
        {
            GetDelegateFor<Delegates.glWindowPos2fvDelegate>()(v);
        }

        public static void glWindowPos2i(int x, int y)
        {
            GetDelegateFor<Delegates.glWindowPos2iDelegate>()(x, y);
        }

        public static void glWindowPos2iv(int[] v)
        {
            GetDelegateFor<Delegates.glWindowPos2ivDelegate>()(v);
        }

        public static void glWindowPos2s(short x, short y)
        {
            GetDelegateFor<Delegates.glWindowPos2sDelegate>()(x, y);
        }

        public static void glWindowPos2sv(short[] v)
        {
            GetDelegateFor<Delegates.glWindowPos2svDelegate>()(v);
        }

        public static void glWindowPos3d(double x, double y, double z)
        {
            GetDelegateFor<Delegates.glWindowPos3dDelegate>()(x, y, z);
        }

        public static void glWindowPos3dv(double[] v)
        {
            GetDelegateFor<Delegates.glWindowPos3dvDelegate>()(v);
        }

        public static void glWindowPos3f(float x, float y, float z)
        {
            GetDelegateFor<Delegates.glWindowPos3fDelegate>()(x, y, z);
        }

        public static void glWindowPos3fv(float[] v)
        {
            GetDelegateFor<Delegates.glWindowPos3fvDelegate>()(v);
        }

        public static void glWindowPos3i(int x, int y, int z)
        {
            GetDelegateFor<Delegates.glWindowPos3iDelegate>()(x, y, z);
        }

        public static void glWindowPos3iv(int[] v)
        {
            GetDelegateFor<Delegates.glWindowPos3ivDelegate>()(v);
        }

        public static void glWindowPos3s(short x, short y, short z)
        {
            GetDelegateFor<Delegates.glWindowPos3sDelegate>()(x, y, z);
        }

        public static void glWindowPos3sv(short[] v)
        {
            GetDelegateFor<Delegates.glWindowPos3svDelegate>()(v);
        }

        public static void glBlendColor(float red, float green, float blue, float alpha)
        {
            GetDelegateFor<Delegates.glBlendColorDelegate>()(red, green, blue, alpha);
        }

        public static void glBlendEquation(uint mode)
        {
            GetDelegateFor<Delegates.glBlendEquationDelegate>()(mode);
        }

        public static void glGenQueries(int n, uint[] ids)
        {
            GetDelegateFor<Delegates.glGenQueriesDelegate>()(n, ids);
        }

        public static void glDeleteQueries(int n, uint[] ids)
        {
            GetDelegateFor<Delegates.glDeleteQueriesDelegate>()(n, ids);
        }

        public static bool glIsQuery(uint id)
        {
            return (bool)GetDelegateFor<Delegates.glIsQueryDelegate>()(id);
        }

        public static void glBeginQuery(uint target, uint id)
        {
            GetDelegateFor<Delegates.glBeginQueryDelegate>()(target, id);
        }

        public static void glEndQuery(uint target)
        {
            GetDelegateFor<Delegates.glEndQueryDelegate>()(target);
        }

        public static void glGetQueryiv(uint target, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetQueryivDelegate>()(target, pname, @params);
        }

        public static void glGetQueryObjectiv(uint id, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetQueryObjectivDelegate>()(id, pname, @params);
        }

        public static void glGetQueryObjectuiv(uint id, uint pname, uint[] @params)
        {
            GetDelegateFor<Delegates.glGetQueryObjectuivDelegate>()(id, pname, @params);
        }

        public static void glBindBuffer(uint target, uint buffer)
        {
            GetDelegateFor<Delegates.glBindBufferDelegate>()(target, buffer);
        }

        public static void glDeleteBuffers(int n, uint[] buffers)
        {
            GetDelegateFor<Delegates.glDeleteBuffersDelegate>()(n, buffers);
        }

        public static void glGenBuffers(int n, uint[] buffers)
        {
            GetDelegateFor<Delegates.glGenBuffersDelegate>()(n, buffers);
        }

        public static bool glIsBuffer(uint buffer)
        {
            return (bool)GetDelegateFor<Delegates.glIsBufferDelegate>()(buffer);
        }

        public static void glBufferData(uint target, int size, object data, uint usage)
        {
            GetDelegateFor<Delegates.glBufferDataObjectDelegate>("glBufferData")(target, size, data, usage);
        }

        public static void glBufferData(uint target, int size, float[] data, uint usage)
        {
            GetDelegateFor<Delegates.glBufferDataFloatDelegate>("glBufferData")(target, size, data, usage);
        }

        public static void glBufferData(uint target, int size, uint[] data, uint usage)
        {
            GetDelegateFor<Delegates.glBufferDataUintDelegate>("glBufferData")(target, size, data, usage);
        }

        public static void glBufferData(uint target, int size, int[] data, uint usage)
        {
            GetDelegateFor<Delegates.glBufferDataIntDelegate>("glBufferData")(target, size, data, usage);
        }

        public static void glBufferData(uint target, int size, double[] data, uint usage)
        {
            GetDelegateFor<Delegates.glBufferDataDoubleDelegate>("glBufferData")(target, size, data, usage);
        }

        public static void glBufferSubData(uint target, int offset, int size, object data)
        {
            GetDelegateFor<Delegates.glBufferSubDataObjectDelegate>("glBufferSubData")(target, offset, size, data);
        }

        public static void glBufferSubData(uint target, int offset, int size, float[] data)
        {
            GetDelegateFor<Delegates.glBufferSubDataDelegate>()(target, offset, size, data);
        }

        public static void glGetBufferSubData(uint target, IntPtr offset, IntPtr size, IntPtr data)
        {
            GetDelegateFor<Delegates.glGetBufferSubDataDelegate>()(target, offset, size, data);
        }

        public static void glMapBuffer(uint target, uint access)
        {
            GetDelegateFor<Delegates.glMapBufferDelegate>()(target, access);
        }

        public static bool glUnmapBuffer(uint target)
        {
            return (bool)GetDelegateFor<Delegates.glUnmapBufferDelegate>()(target);
        }

        public static void glGetBufferParameteriv(uint target, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetBufferParameterivDelegate>()(target, pname, @params);
        }

        public static void glGetBufferPointerv(uint target, uint pname, IntPtr @params)
        {
            GetDelegateFor<Delegates.glGetBufferPointervDelegate>()(target, pname, @params);
        }

        public static void glBlendEquationSeparate(uint modeRGB, uint modeAlpha)
        {
            GetDelegateFor<Delegates.glBlendEquationSeparateDelegate>()(modeRGB, modeAlpha);
        }

        public static void glDrawBuffers(int n, uint[] bufs)
        {
            GetDelegateFor<Delegates.glDrawBuffersDelegate>()(n, bufs);
        }

        public static void glStencilOpSeparate(uint face, uint sfail, uint dpfail, uint dppass)
        {
            GetDelegateFor<Delegates.glStencilOpSeparateDelegate>()(face, sfail, dpfail, dppass);
        }

        public static void glStencilFuncSeparate(uint face, uint func, int @ref, uint mask)
        {
            GetDelegateFor<Delegates.glStencilFuncSeparateDelegate>()(face, func, @ref, mask);
        }

        public static void glStencilMaskSeparate(uint face, uint mask)
        {
            GetDelegateFor<Delegates.glStencilMaskSeparateDelegate>()(face, mask);
        }

        public static void glAttachShader(uint program, uint shader)
        {
            GetDelegateFor<Delegates.glAttachShaderDelegate>()(program, shader);
        }

        public static void glBindAttribLocation(uint program, uint index, string[] name)
        {
            GetDelegateFor<Delegates.glBindAttribLocationDelegate>()(program, index, name);
        }

        public static void glCompileShader(uint shader)
        {
            GetDelegateFor<Delegates.glCompileShaderDelegate>()(shader);
        }

        public static uint glCreateProgram()
        {
            return (uint)GetDelegateFor<Delegates.glCreateProgramDelegate>()();
        }

        public static uint glCreateShader(uint type)
        {
            return (uint)GetDelegateFor<Delegates.glCreateShaderDelegate>()(type);
        }

        public static void glDeleteProgram(uint program)
        {
            GetDelegateFor<Delegates.glDeleteProgramDelegate>()(program);
        }

        public static void glDeleteShader(uint shader)
        {
            GetDelegateFor<Delegates.glDeleteShaderDelegate>()(shader);
        }

        public static void glDetachShader(uint program, uint shader)
        {
            GetDelegateFor<Delegates.glDetachShaderDelegate>()(program, shader);
        }

        public static void glDisableVertexAttribArray(uint index)
        {
            GetDelegateFor<Delegates.glDisableVertexAttribArrayDelegate>()(index);
        }

        public static void glEnableVertexAttribArray(uint index)
        {
            GetDelegateFor<Delegates.glEnableVertexAttribArrayDelegate>()(index);
        }

        public static void glGetActiveAttrib(uint program, uint index, int bufSize, int[] length, int[] size, uint[] type, string[] name)
        {
            GetDelegateFor<Delegates.glGetActiveAttribDelegate>()(program, index, bufSize, length, size, type, name);
        }

        //public static void glGetActiveUniform(uint program, uint index, int bufSize, int[] length, int[] size, uint[] type, string[] name)
        //{
        //    GetDelegateFor<Delegates.glGetActiveUniformDelegate>()(program, index, bufSize, length, size, type, name);
        //}

        public unsafe static void glGetActiveUniform(uint program, uint index, int bufSize, int* length, int* size, uint* type, char* name)
        {
            GetDelegateFor<Delegates.glGetActiveUniformDelegate>()(program, index, bufSize, length, size, type, name);
        }

        public static void glGetAttachedShaders(uint program, int maxCount, int[] count, uint[] shaders)
        {
            GetDelegateFor<Delegates.glGetAttachedShadersDelegate>()(program, maxCount, count, shaders);
        }

        public static uint glGetAttribLocation(uint program, string name)
        {
            return (uint)GetDelegateFor<Delegates.glGetAttribLocationDelegate>()(program, name);
        }

        public static void glGetProgramiv(uint program, uint pname, ref int @params)
        {
            GetDelegateFor<Delegates.glGetProgramivDelegate>()(program, pname, ref @params);
        }

        public static void glGetProgramInfoLog(uint program, int bufSize, ref int length, byte[] infoLog)
        {
            GetDelegateFor<Delegates.glGetProgramInfoLogDelegate>()(program, bufSize, ref length, infoLog);
        }

        public static void glGetShaderiv(uint shader, uint pname, ref int @params)
        {
            GetDelegateFor<Delegates.glGetShaderivDelegate>()(shader, pname, ref @params);
        }

        public static void glGetShaderInfoLog(uint shader, int bufSize, ref int length, byte[] infoLog)
        {
            GetDelegateFor<Delegates.glGetShaderInfoLogDelegate>()(shader, bufSize, ref length, infoLog);
        }

        public static void glGetShaderSource(uint shader, int bufSize, int[] length, char[] source)
        {
            GetDelegateFor<Delegates.glGetShaderSourceDelegate>()(shader, bufSize, length, source);
        }

        public static uint glGetUniformLocation(uint program, string name)
        {
            return (uint)GetDelegateFor<Delegates.glGetUniformLocationDelegate>()(program, name);
        }

        public static void glGetUniformfv(uint program, uint location, float[] @params)
        {
            GetDelegateFor<Delegates.glGetUniformfvDelegate>()(program, location, @params);
        }

        public static void glGetUniformiv(uint program, uint location, int[] @params)
        {
            GetDelegateFor<Delegates.glGetUniformivDelegate>()(program, location, @params);
        }

        public static void glGetVertexAttribdv(uint index, uint pname, double[] @params)
        {
            GetDelegateFor<Delegates.glGetVertexAttribdvDelegate>()(index, pname, @params);
        }

        public static void glGetVertexAttribfv(uint index, uint pname, float[] @params)
        {
            GetDelegateFor<Delegates.glGetVertexAttribfvDelegate>()(index, pname, @params);
        }

        public static void glGetVertexAttribiv(uint index, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetVertexAttribivDelegate>()(index, pname, @params);
        }

        public static void glGetVertexAttribPointerv(uint index, uint pname, IntPtr pointer)
        {
            GetDelegateFor<Delegates.glGetVertexAttribPointervDelegate>()(index, pname, pointer);
        }

        public static bool glIsProgram(uint program)
        {
            return (bool)GetDelegateFor<Delegates.glIsProgramDelegate>()(program);
        }

        public static bool glIsShader(uint shader)
        {
            return (bool)GetDelegateFor<Delegates.glIsShaderDelegate>()(shader);
        }

        public static void glLinkProgram(uint program)
        {
            GetDelegateFor<Delegates.glLinkProgramDelegate>()(program);
        }

        public static void glShaderSource(uint shader, int count, string[] @string, int[] length)
        {
            GetDelegateFor<Delegates.glShaderSourceDelegate>()(shader, count, @string, length);
        }

        public static void glUseProgram(uint program)
        {
            GetDelegateFor<Delegates.glUseProgramDelegate>()(program);
        }

        public static void glUniform1f(uint location, float v0)
        {
            GetDelegateFor<Delegates.glUniform1fDelegate>()(location, v0);
        }

        public static void glUniform2f(uint location, float v0, float v1)
        {
            GetDelegateFor<Delegates.glUniform2fDelegate>()(location, v0, v1);
        }

        public static void glUniform3f(uint location, float v0, float v1, float v2)
        {
            GetDelegateFor<Delegates.glUniform3fDelegate>()(location, v0, v1, v2);
        }

        public static void glUniform4f(uint location, float v0, float v1, float v2, float v3)
        {
            GetDelegateFor<Delegates.glUniform4fDelegate>()(location, v0, v1, v2, v3);
        }

        public static void glUniform1i(uint location, int v0)
        {
            GetDelegateFor<Delegates.glUniform1iDelegate>()(location, v0);
        }

        public static void glUniform2i(uint location, int v0, int v1)
        {
            GetDelegateFor<Delegates.glUniform2iDelegate>()(location, v0, v1);
        }

        public static void glUniform3i(uint location, int v0, int v1, int v2)
        {
            GetDelegateFor<Delegates.glUniform3iDelegate>()(location, v0, v1, v2);
        }

        public static void glUniform4i(uint location, int v0, int v1, int v2, int v3)
        {
            GetDelegateFor<Delegates.glUniform4iDelegate>()(location, v0, v1, v2, v3);
        }

        public static void glUniform1fv(uint location, int count, float[] value)
        {
            GetDelegateFor<Delegates.glUniform1fvDelegate>()(location, count, value);
        }

        public static void glUniform2fv(uint location, int count, float[] value)
        {
            GetDelegateFor<Delegates.glUniform2fvDelegate>()(location, count, value);
        }

        public static void glUniform3fv(uint location, int count, float[] value)
        {
            GetDelegateFor<Delegates.glUniform3fvDelegate>()(location, count, value);
        }

        public static void glUniform4fv(uint location, int count, float[] value)
        {
            GetDelegateFor<Delegates.glUniform4fvDelegate>()(location, count, value);
        }

        public static void glUniform1iv(uint location, int count, int[] value)
        {
            GetDelegateFor<Delegates.glUniform1ivDelegate>()(location, count, value);
        }

        public static void glUniform2iv(uint location, int count, int[] value)
        {
            GetDelegateFor<Delegates.glUniform2ivDelegate>()(location, count, value);
        }

        public static void glUniform3iv(uint location, int count, int[] value)
        {
            GetDelegateFor<Delegates.glUniform3ivDelegate>()(location, count, value);
        }

        public static void glUniform4iv(uint location, int count, int[] value)
        {
            GetDelegateFor<Delegates.glUniform4ivDelegate>()(location, count, value);
        }

        public static void glUniformMatrix2fv(uint location, int count, bool transpose, float[] value)
        {
            GetDelegateFor<Delegates.glUniformMatrix2fvDelegate>()(location, count, transpose, value);
        }

        public static void glUniformMatrix3fv(uint location, int count, bool transpose, float[] value)
        {
            GetDelegateFor<Delegates.glUniformMatrix3fvDelegate>()(location, count, transpose, value);
        }

        public static void glUniformMatrix4fv(uint location, int count, bool transpose, float[] value)
        {
            GetDelegateFor<Delegates.glUniformMatrix4fvDelegate>()(location, count, transpose, value);
        }

        public static void glValidateProgram(uint program)
        {
            GetDelegateFor<Delegates.glValidateProgramDelegate>()(program);
        }

        public static void glVertexAttrib1d(uint index, double x)
        {
            GetDelegateFor<Delegates.glVertexAttrib1dDelegate>()(index, x);
        }

        public static void glVertexAttrib1dv(uint index, double[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib1dvDelegate>()(index, v);
        }

        public static void glVertexAttrib1f(uint index, float x)
        {
            GetDelegateFor<Delegates.glVertexAttrib1fDelegate>()(index, x);
        }

        public static void glVertexAttrib1fv(uint index, float[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib1fvDelegate>()(index, v);
        }

        public static void glVertexAttrib1s(uint index, short x)
        {
            GetDelegateFor<Delegates.glVertexAttrib1sDelegate>()(index, x);
        }

        public static void glVertexAttrib1sv(uint index, short[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib1svDelegate>()(index, v);
        }

        public static void glVertexAttrib2d(uint index, double x, double y)
        {
            GetDelegateFor<Delegates.glVertexAttrib2dDelegate>()(index, x, y);
        }

        public static void glVertexAttrib2dv(uint index, double[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib2dvDelegate>()(index, v);
        }

        public static void glVertexAttrib2f(uint index, float x, float y)
        {
            GetDelegateFor<Delegates.glVertexAttrib2fDelegate>()(index, x, y);
        }

        public static void glVertexAttrib2fv(uint index, float[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib2fvDelegate>()(index, v);
        }

        public static void glVertexAttrib2s(uint index, short x, short y)
        {
            GetDelegateFor<Delegates.glVertexAttrib2sDelegate>()(index, x, y);
        }

        public static void glVertexAttrib2sv(uint index, short[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib2svDelegate>()(index, v);
        }

        public static void glVertexAttrib3d(uint index, double x, double y, double z)
        {
            GetDelegateFor<Delegates.glVertexAttrib3dDelegate>()(index, x, y, z);
        }

        public static void glVertexAttrib3dv(uint index, double[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib3dvDelegate>()(index, v);
        }

        public static void glVertexAttrib3f(uint index, float x, float y, float z)
        {
            GetDelegateFor<Delegates.glVertexAttrib3fDelegate>()(index, x, y, z);
        }

        public static void glVertexAttrib3fv(uint index, float[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib3fvDelegate>()(index, v);
        }

        public static void glVertexAttrib3s(uint index, short x, short y, short z)
        {
            GetDelegateFor<Delegates.glVertexAttrib3sDelegate>()(index, x, y, z);
        }

        public static void glVertexAttrib3sv(uint index, short[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib3svDelegate>()(index, v);
        }

        public static void glVertexAttrib4Nbv(uint index, byte[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib4NbvDelegate>()(index, v);
        }

        public static void glVertexAttrib4Niv(uint index, int[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib4NivDelegate>()(index, v);
        }

        public static void glVertexAttrib4Nsv(uint index, short[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib4NsvDelegate>()(index, v);
        }

        public static void glVertexAttrib4Nub(uint index, byte x, byte y, byte z, byte w)
        {
            GetDelegateFor<Delegates.glVertexAttrib4NubDelegate>()(index, x, y, z, w);
        }

        public static void glVertexAttrib4Nubv(uint index, byte[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib4NubvDelegate>()(index, v);
        }

        public static void glVertexAttrib4Nuiv(uint index, uint[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib4NuivDelegate>()(index, v);
        }

        public static void glVertexAttrib4Nusv(uint index, ushort[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib4NusvDelegate>()(index, v);
        }

        public static void glVertexAttrib4bv(uint index, byte[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib4bvDelegate>()(index, v);
        }

        public static void glVertexAttrib4d(uint index, double x, double y, double z, double w)
        {
            GetDelegateFor<Delegates.glVertexAttrib4dDelegate>()(index, x, y, z, w);
        }

        public static void glVertexAttrib4dv(uint index, double[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib4dvDelegate>()(index, v);
        }

        public static void glVertexAttrib4f(uint index, float x, float y, float z, float w)
        {
            GetDelegateFor<Delegates.glVertexAttrib4fDelegate>()(index, x, y, z, w);
        }

        public static void glVertexAttrib4fv(uint index, float[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib4fvDelegate>()(index, v);
        }

        public static void glVertexAttrib4iv(uint index, int[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib4ivDelegate>()(index, v);
        }

        public static void glVertexAttrib4s(uint index, short x, short y, short z, short w)
        {
            GetDelegateFor<Delegates.glVertexAttrib4sDelegate>()(index, x, y, z, w);
        }

        public static void glVertexAttrib4sv(uint index, short[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib4svDelegate>()(index, v);
        }

        public static void glVertexAttrib4ubv(uint index, byte[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib4ubvDelegate>()(index, v);
        }

        public static void glVertexAttrib4uiv(uint index, uint[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib4uivDelegate>()(index, v);
        }

        public static void glVertexAttrib4usv(uint index, ushort[] v)
        {
            GetDelegateFor<Delegates.glVertexAttrib4usvDelegate>()(index, v);
        }

        public static void glVertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer)
        {
            GetDelegateFor<Delegates.glVertexAttribPointerDelegate>()(index, size, type, normalized, stride, pointer);
        }

        public static void glUniformMatrix2x3fv(uint location, int count, bool transpose, float[] value)
        {
            GetDelegateFor<Delegates.glUniformMatrix2x3fvDelegate>()(location, count, transpose, value);
        }

        public static void glUniformMatrix3x2fv(uint location, int count, bool transpose, float[] value)
        {
            GetDelegateFor<Delegates.glUniformMatrix3x2fvDelegate>()(location, count, transpose, value);
        }

        public static void glUniformMatrix2x4fv(uint location, int count, bool transpose, float[] value)
        {
            GetDelegateFor<Delegates.glUniformMatrix2x4fvDelegate>()(location, count, transpose, value);
        }

        public static void glUniformMatrix4x2fv(uint location, int count, bool transpose, float[] value)
        {
            GetDelegateFor<Delegates.glUniformMatrix4x2fvDelegate>()(location, count, transpose, value);
        }

        public static void glUniformMatrix3x4fv(uint location, int count, bool transpose, float[] value)
        {
            GetDelegateFor<Delegates.glUniformMatrix3x4fvDelegate>()(location, count, transpose, value);
        }

        public static void glUniformMatrix4x3fv(uint location, int count, bool transpose, float[] value)
        {
            GetDelegateFor<Delegates.glUniformMatrix4x3fvDelegate>()(location, count, transpose, value);
        }

        public static void glColorMaski(uint index, bool r, bool g, bool b, bool a)
        {
            GetDelegateFor<Delegates.glColorMaskiDelegate>()(index, r, g, b, a);
        }

        public static void glGetBooleani_v(uint target, uint index, bool[] data)
        {
            GetDelegateFor<Delegates.glGetBooleani_vDelegate>()(target, index, data);
        }

        public static void glGetIntegeri_v(uint target, uint index, int[] data)
        {
            GetDelegateFor<Delegates.glGetIntegeri_vDelegate>()(target, index, data);
        }

        public static void glEnablei(uint target, uint index)
        {
            GetDelegateFor<Delegates.glEnableiDelegate>()(target, index);
        }

        public static void glDisablei(uint target, uint index)
        {
            GetDelegateFor<Delegates.glDisableiDelegate>()(target, index);
        }

        public static bool glIsEnabledi(uint target, uint index)
        {
            return (bool)GetDelegateFor<Delegates.glIsEnablediDelegate>()(target, index);
        }

        public static void glBeginTransformFeedback(uint primitiveMode)
        {
            GetDelegateFor<Delegates.glBeginTransformFeedbackDelegate>()(primitiveMode);
        }

        public static void glEndTransformFeedback()
        {
            GetDelegateFor<Delegates.glEndTransformFeedbackDelegate>()();
        }

        public static void glBindBufferRange(uint target, uint index, uint buffer, IntPtr offset, IntPtr size)
        {
            GetDelegateFor<Delegates.glBindBufferRangeDelegate>()(target, index, buffer, offset, size);
        }

        public static void glBindBufferBase(uint target, uint index, uint buffer)
        {
            GetDelegateFor<Delegates.glBindBufferBaseDelegate>()(target, index, buffer);
        }

        public static void glTransformFeedbackVaryings(uint program, int count, char[] varyings, uint bufferMode)
        {
            GetDelegateFor<Delegates.glTransformFeedbackVaryingsDelegate>()(program, count, varyings, bufferMode);
        }

        public static void glGetTransformFeedbackVarying(uint program, uint index, int bufSize, int[] length, int[] size, uint[] type, char[] name)
        {
            GetDelegateFor<Delegates.glGetTransformFeedbackVaryingDelegate>()(program, index, bufSize, length, size, type, name);
        }

        public static void glClampColor(uint target, uint clamp)
        {
            GetDelegateFor<Delegates.glClampColorDelegate>()(target, clamp);
        }

        public static void glBeginConditionalRender(uint id, uint mode)
        {
            GetDelegateFor<Delegates.glBeginConditionalRenderDelegate>()(id, mode);
        }

        public static void glEndConditionalRender()
        {
            GetDelegateFor<Delegates.glEndConditionalRenderDelegate>()();
        }

        public static void glVertexAttribIPointer(uint index, int size, uint type, int stride, IntPtr pointer)
        {
            GetDelegateFor<Delegates.glVertexAttribIPointerDelegate>()(index, size, type, stride, pointer);
        }

        public static void glGetVertexAttribIiv(uint index, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetVertexAttribIivDelegate>()(index, pname, @params);
        }

        public static void glGetVertexAttribIuiv(uint index, uint pname, uint[] @params)
        {
            GetDelegateFor<Delegates.glGetVertexAttribIuivDelegate>()(index, pname, @params);
        }

        public static void glVertexAttribI1i(uint index, int x)
        {
            GetDelegateFor<Delegates.glVertexAttribI1iDelegate>()(index, x);
        }

        public static void glVertexAttribI2i(uint index, int x, int y)
        {
            GetDelegateFor<Delegates.glVertexAttribI2iDelegate>()(index, x, y);
        }

        public static void glVertexAttribI3i(uint index, int x, int y, int z)
        {
            GetDelegateFor<Delegates.glVertexAttribI3iDelegate>()(index, x, y, z);
        }

        public static void glVertexAttribI4i(uint index, int x, int y, int z, int w)
        {
            GetDelegateFor<Delegates.glVertexAttribI4iDelegate>()(index, x, y, z, w);
        }

        public static void glVertexAttribI1ui(uint index, uint x)
        {
            GetDelegateFor<Delegates.glVertexAttribI1uiDelegate>()(index, x);
        }

        public static void glVertexAttribI2ui(uint index, uint x, uint y)
        {
            GetDelegateFor<Delegates.glVertexAttribI2uiDelegate>()(index, x, y);
        }

        public static void glVertexAttribI3ui(uint index, uint x, uint y, uint z)
        {
            GetDelegateFor<Delegates.glVertexAttribI3uiDelegate>()(index, x, y, z);
        }

        public static void glVertexAttribI4ui(uint index, uint x, uint y, uint z, uint w)
        {
            GetDelegateFor<Delegates.glVertexAttribI4uiDelegate>()(index, x, y, z, w);
        }

        public static void glVertexAttribI1iv(uint index, int[] v)
        {
            GetDelegateFor<Delegates.glVertexAttribI1ivDelegate>()(index, v);
        }

        public static void glVertexAttribI2iv(uint index, int[] v)
        {
            GetDelegateFor<Delegates.glVertexAttribI2ivDelegate>()(index, v);
        }

        public static void glVertexAttribI3iv(uint index, int[] v)
        {
            GetDelegateFor<Delegates.glVertexAttribI3ivDelegate>()(index, v);
        }

        public static void glVertexAttribI4iv(uint index, int[] v)
        {
            GetDelegateFor<Delegates.glVertexAttribI4ivDelegate>()(index, v);
        }

        public static void glVertexAttribI1uiv(uint index, uint[] v)
        {
            GetDelegateFor<Delegates.glVertexAttribI1uivDelegate>()(index, v);
        }

        public static void glVertexAttribI2uiv(uint index, uint[] v)
        {
            GetDelegateFor<Delegates.glVertexAttribI2uivDelegate>()(index, v);
        }

        public static void glVertexAttribI3uiv(uint index, uint[] v)
        {
            GetDelegateFor<Delegates.glVertexAttribI3uivDelegate>()(index, v);
        }

        public static void glVertexAttribI4uiv(uint index, uint[] v)
        {
            GetDelegateFor<Delegates.glVertexAttribI4uivDelegate>()(index, v);
        }

        public static void glVertexAttribI4bv(uint index, byte[] v)
        {
            GetDelegateFor<Delegates.glVertexAttribI4bvDelegate>()(index, v);
        }

        public static void glVertexAttribI4sv(uint index, short[] v)
        {
            GetDelegateFor<Delegates.glVertexAttribI4svDelegate>()(index, v);
        }

        public static void glVertexAttribI4ubv(uint index, byte[] v)
        {
            GetDelegateFor<Delegates.glVertexAttribI4ubvDelegate>()(index, v);
        }

        public static void glVertexAttribI4usv(uint index, ushort[] v)
        {
            GetDelegateFor<Delegates.glVertexAttribI4usvDelegate>()(index, v);
        }

        public static void glGetUniformuiv(uint program, uint location, uint[] @params)
        {
            GetDelegateFor<Delegates.glGetUniformuivDelegate>()(program, location, @params);
        }

        public static void glBindFragDataLocation(uint program, uint color, char[] name)
        {
            GetDelegateFor<Delegates.glBindFragDataLocationDelegate>()(program, color, name);
        }

        public static int glGetFragDataLocation(uint program, char[] name)
        {
            return (int)GetDelegateFor<Delegates.glGetFragDataLocationDelegate>()(program, name);
        }

        public static void glUniform1ui(uint location, uint v0)
        {
            GetDelegateFor<Delegates.glUniform1uiDelegate>()(location, v0);
        }

        public static void glUniform2ui(uint location, uint v0, uint v1)
        {
            GetDelegateFor<Delegates.glUniform2uiDelegate>()(location, v0, v1);
        }

        public static void glUniform3ui(uint location, uint v0, uint v1, uint v2)
        {
            GetDelegateFor<Delegates.glUniform3uiDelegate>()(location, v0, v1, v2);
        }

        public static void glUniform4ui(uint location, uint v0, uint v1, uint v2, uint v3)
        {
            GetDelegateFor<Delegates.glUniform4uiDelegate>()(location, v0, v1, v2, v3);
        }

        public static void glUniform1uiv(uint location, int count, uint[] value)
        {
            GetDelegateFor<Delegates.glUniform1uivDelegate>()(location, count, value);
        }

        public static void glUniform2uiv(uint location, int count, uint[] value)
        {
            GetDelegateFor<Delegates.glUniform2uivDelegate>()(location, count, value);
        }

        public static void glUniform3uiv(uint location, int count, uint[] value)
        {
            GetDelegateFor<Delegates.glUniform3uivDelegate>()(location, count, value);
        }

        public static void glUniform4uiv(uint location, int count, uint[] value)
        {
            GetDelegateFor<Delegates.glUniform4uivDelegate>()(location, count, value);
        }

        public static void glTexParameterIiv(uint target, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glTexParameterIivDelegate>()(target, pname, @params);
        }

        public static void glTexParameterIuiv(uint target, uint pname, uint[] @params)
        {
            GetDelegateFor<Delegates.glTexParameterIuivDelegate>()(target, pname, @params);
        }

        public static void glGetTexParameterIiv(uint target, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetTexParameterIivDelegate>()(target, pname, @params);
        }

        public static void glGetTexParameterIuiv(uint target, uint pname, uint[] @params)
        {
            GetDelegateFor<Delegates.glGetTexParameterIuivDelegate>()(target, pname, @params);
        }

        public static void glClearBufferiv(uint buffer, int drawbuffer, int[] value)
        {
            GetDelegateFor<Delegates.glClearBufferivDelegate>()(buffer, drawbuffer, value);
        }

        public static void glClearBufferuiv(uint buffer, int drawbuffer, uint[] value)
        {
            GetDelegateFor<Delegates.glClearBufferuivDelegate>()(buffer, drawbuffer, value);
        }

        public static void glClearBufferfv(uint buffer, int drawbuffer, float[] value)
        {
            GetDelegateFor<Delegates.glClearBufferfvDelegate>()(buffer, drawbuffer, value);
        }

        public static void glClearBufferfi(uint buffer, int drawbuffer, float depth, int stencil)
        {
            GetDelegateFor<Delegates.glClearBufferfiDelegate>()(buffer, drawbuffer, depth, stencil);
        }

        public static bool glIsRenderbuffer(uint renderbuffer)
        {
            return (bool)GetDelegateFor<Delegates.glIsRenderbufferDelegate>()(renderbuffer);
        }

        public static void glBindRenderbuffer(uint target, uint renderbuffer)
        {
            GetDelegateFor<Delegates.glBindRenderbufferDelegate>()(target, renderbuffer);
        }

        public static void glDeleteRenderbuffers(int n, uint[] renderbuffers)
        {
            GetDelegateFor<Delegates.glDeleteRenderbuffersDelegate>()(n, renderbuffers);
        }

        public static void glGenRenderbuffers(int n, uint[] renderbuffers)
        {
            GetDelegateFor<Delegates.glGenRenderbuffersDelegate>()(n, renderbuffers);
        }

        public static void glRenderbufferStorage(uint target, uint internalformat, int width, int height)
        {
            GetDelegateFor<Delegates.glRenderbufferStorageDelegate>()(target, internalformat, width, height);
        }

        public static void glGetRenderbufferParameteriv(uint target, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetRenderbufferParameterivDelegate>()(target, pname, @params);
        }

        public static bool glIsFramebuffer(uint framebuffer)
        {
            return (bool)GetDelegateFor<Delegates.glIsFramebufferDelegate>()(framebuffer);
        }

        public static void glBindFramebuffer(uint target, uint framebuffer)
        {
            GetDelegateFor<Delegates.glBindFramebufferDelegate>()(target, framebuffer);
        }

        public static void glDeleteFramebuffers(int n, uint[] framebuffers)
        {
            GetDelegateFor<Delegates.glDeleteFramebuffersDelegate>()(n, framebuffers);
        }

        public static void glGenFramebuffers(int n, uint[] framebuffers)
        {
            GetDelegateFor<Delegates.glGenFramebuffersDelegate>()(n, framebuffers);
        }

        public static uint glCheckFramebufferStatus(uint target)
        {
            return (uint)GetDelegateFor<Delegates.glCheckFramebufferStatusDelegate>()(target);
        }

        public static void glFramebufferTexture1D(uint target, uint attachment, uint textarget, uint texture, int level)
        {
            GetDelegateFor<Delegates.glFramebufferTexture1DDelegate>()(target, attachment, textarget, texture, level);
        }

        public static void glFramebufferTexture2D(uint target, uint attachment, uint textarget, uint texture, int level)
        {
            GetDelegateFor<Delegates.glFramebufferTexture2DDelegate>()(target, attachment, textarget, texture, level);
        }

        public static void glFramebufferTexture3D(uint target, uint attachment, uint textarget, uint texture, int level, int zoffset)
        {
            GetDelegateFor<Delegates.glFramebufferTexture3DDelegate>()(target, attachment, textarget, texture, level, zoffset);
        }

        public static void glFramebufferRenderbuffer(uint target, uint attachment, uint renderbuffertarget, uint renderbuffer)
        {
            GetDelegateFor<Delegates.glFramebufferRenderbufferDelegate>()(target, attachment, renderbuffertarget, renderbuffer);
        }

        public static void glGetFramebufferAttachmentParameteriv(uint target, uint attachment, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetFramebufferAttachmentParameterivDelegate>()(target, attachment, pname, @params);
        }

        public static void glGenerateMipmap(uint target)
        {
            GetDelegateFor<Delegates.glGenerateMipmapDelegate>()(target);
        }

        public static void glBlitFramebuffer(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, uint mask, uint filter)
        {
            GetDelegateFor<Delegates.glBlitFramebufferDelegate>()(srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);
        }

        public static void glRenderbufferStorageMultisample(uint target, int samples, uint internalformat, int width, int height)
        {
            GetDelegateFor<Delegates.glRenderbufferStorageMultisampleDelegate>()(target, samples, internalformat, width, height);
        }

        public static void glFramebufferTextureLayer(uint target, uint attachment, uint texture, int level, int layer)
        {
            GetDelegateFor<Delegates.glFramebufferTextureLayerDelegate>()(target, attachment, texture, level, layer);
        }

        public static void glMapBufferRange(uint target, IntPtr offset, IntPtr length, uint access)
        {
            GetDelegateFor<Delegates.glMapBufferRangeDelegate>()(target, offset, length, access);
        }

        public static void glFlushMappedBufferRange(uint target, IntPtr offset, IntPtr length)
        {
            GetDelegateFor<Delegates.glFlushMappedBufferRangeDelegate>()(target, offset, length);
        }

        public static void glBindVertexArray(uint array)
        {
            GetDelegateFor<Delegates.glBindVertexArrayDelegate>()(array);
        }

        public static void glDeleteVertexArrays(int n, uint[] arrays)
        {
            GetDelegateFor<Delegates.glDeleteVertexArraysDelegate>()(n, arrays);
        }

        public static void glGenVertexArrays(int n, uint[] arrays)
        {
            GetDelegateFor<Delegates.glGenVertexArraysDelegate>()(n, arrays);
        }

        public static bool glIsVertexArray(uint array)
        {
            return (bool)GetDelegateFor<Delegates.glIsVertexArrayDelegate>()(array);
        }

        public static void glDrawElementsBaseVertex(uint mode, int count, uint type, IntPtr indices, int basevertex)
        {
            GetDelegateFor<Delegates.glDrawElementsBaseVertexDelegate>()(mode, count, type, indices, basevertex);
        }

        public static void glDrawRangeElementsBaseVertex(uint mode, uint start, uint end, int count, uint type, IntPtr indices, int basevertex)
        {
            GetDelegateFor<Delegates.glDrawRangeElementsBaseVertexDelegate>()(mode, start, end, count, type, indices, basevertex);
        }

        public static void glDrawElementsInstancedBaseVertex(uint mode, int count, uint type, IntPtr indices, int instancecount, int basevertex)
        {
            GetDelegateFor<Delegates.glDrawElementsInstancedBaseVertexDelegate>()(mode, count, type, indices, instancecount, basevertex);
        }

        public static void glMultiDrawElementsBaseVertex(uint mode, int[] count, uint type, IntPtr indices, int drawcount, int[] basevertex)
        {
            GetDelegateFor<Delegates.glMultiDrawElementsBaseVertexDelegate>()(mode, count, type, indices, drawcount, basevertex);
        }

        public static void glProvokingVertex(uint mode)
        {
            GetDelegateFor<Delegates.glProvokingVertexDelegate>()(mode);
        }

        public static IntPtr glFenceSync(uint condition, uint flags)
        {
            return (IntPtr)GetDelegateFor<Delegates.glFenceSyncDelegate>()(condition, flags);
        }

        public static bool glIsSync(IntPtr sync)
        {
            return (bool)GetDelegateFor<Delegates.glIsSyncDelegate>()(sync);
        }

        public static void glDeleteSync(IntPtr sync)
        {
            GetDelegateFor<Delegates.glDeleteSyncDelegate>()(sync);
        }

        public static uint glClientWaitSync(IntPtr sync, uint flags, UInt64 timeout)
        {
            return (uint)GetDelegateFor<Delegates.glClientWaitSyncDelegate>()(sync, flags, timeout);
        }

        public static void glWaitSync(IntPtr sync, uint flags, UInt64 timeout)
        {
            GetDelegateFor<Delegates.glWaitSyncDelegate>()(sync, flags, timeout);
        }

        public static void glGetInteger64v(uint pname, Int64[] data)
        {
            GetDelegateFor<Delegates.glGetInteger64vDelegate>()(pname, data);
        }

        public static void glGetSynciv(IntPtr sync, uint pname, int bufSize, int[] length, int[] values)
        {
            GetDelegateFor<Delegates.glGetSyncivDelegate>()(sync, pname, bufSize, length, values);
        }

        public static void glGetInteger64i_v(uint target, uint index, Int64[] data)
        {
            GetDelegateFor<Delegates.glGetInteger64i_vDelegate>()(target, index, data);
        }

        public static void glGetBufferParameteri64v(uint target, uint pname, Int64[] @params)
        {
            GetDelegateFor<Delegates.glGetBufferParameteri64vDelegate>()(target, pname, @params);
        }

        public static void glFramebufferTexture(uint target, uint attachment, uint texture, int level)
        {
            GetDelegateFor<Delegates.glFramebufferTextureDelegate>()(target, attachment, texture, level);
        }

        public static void glTexImage2DMultisample(uint target, int samples, uint internalformat, int width, int height, bool fixedsamplelocations)
        {
            GetDelegateFor<Delegates.glTexImage2DMultisampleDelegate>()(target, samples, internalformat, width, height, fixedsamplelocations);
        }

        public static void glTexImage3DMultisample(uint target, int samples, uint internalformat, int width, int height, int depth, bool fixedsamplelocations)
        {
            GetDelegateFor<Delegates.glTexImage3DMultisampleDelegate>()(target, samples, internalformat, width, height, depth, fixedsamplelocations);
        }

        public static void glGetMultisamplefv(uint pname, uint index, float[] val)
        {
            GetDelegateFor<Delegates.glGetMultisamplefvDelegate>()(pname, index, val);
        }

        public static void glSampleMaski(uint maskNumber, uint mask)
        {
            GetDelegateFor<Delegates.glSampleMaskiDelegate>()(maskNumber, mask);
        }

        public static void glDrawArraysInstanced(uint mode, int first, int count, int instancecount)
        {
            GetDelegateFor<Delegates.glDrawArraysInstancedDelegate>()(mode, first, count, instancecount);
        }

        public static void glDrawElementsInstanced(uint mode, int count, uint type, IntPtr indices, int instancecount)
        {
            GetDelegateFor<Delegates.glDrawElementsInstancedDelegate>()(mode, count, type, indices, instancecount);
        }

        public static void glTexBuffer(uint target, uint internalformat, uint buffer)
        {
            GetDelegateFor<Delegates.glTexBufferDelegate>()(target, internalformat, buffer);
        }

        public static void glPrimitiveRestartIndex(uint index)
        {
            GetDelegateFor<Delegates.glPrimitiveRestartIndexDelegate>()(index);
        }

        public static void glCopyBufferSubData(uint readTarget, uint writeTarget, IntPtr readOffset, IntPtr writeOffset, IntPtr size)
        {
            GetDelegateFor<Delegates.glCopyBufferSubDataDelegate>()(readTarget, writeTarget, readOffset, writeOffset, size);
        }

        public static void glGetUniformIndices(uint program, int uniformCount, char[] uniformNames, uint[] uniformIndices)
        {
            GetDelegateFor<Delegates.glGetUniformIndicesDelegate>()(program, uniformCount, uniformNames, uniformIndices);
        }

        public static void glGetActiveUniformsiv(uint program, int uniformCount, uint[] uniformIndices, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetActiveUniformsivDelegate>()(program, uniformCount, uniformIndices, pname, @params);
        }

        public static void glGetActiveUniformName(uint program, uint uniformIndex, int bufSize, int[] length, char[] uniformName)
        {
            GetDelegateFor<Delegates.glGetActiveUniformNameDelegate>()(program, uniformIndex, bufSize, length, uniformName);
        }

        public static uint glGetUniformBlockIndex(uint program, char[] uniformBlockName)
        {
            return (uint)GetDelegateFor<Delegates.glGetUniformBlockIndexDelegate>()(program, uniformBlockName);
        }

        public static void glGetActiveUniformBlockiv(uint program, uint uniformBlockIndex, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetActiveUniformBlockivDelegate>()(program, uniformBlockIndex, pname, @params);
        }

        public static void glGetActiveUniformBlockName(uint program, uint uniformBlockIndex, int bufSize, int[] length, char[] uniformBlockName)
        {
            GetDelegateFor<Delegates.glGetActiveUniformBlockNameDelegate>()(program, uniformBlockIndex, bufSize, length, uniformBlockName);
        }

        public static void glUniformBlockBinding(uint program, uint uniformBlockIndex, uint uniformBlockBinding)
        {
            GetDelegateFor<Delegates.glUniformBlockBindingDelegate>()(program, uniformBlockIndex, uniformBlockBinding);
        }

        public static void glBindFragDataLocationIndexed(uint program, uint colorNumber, uint index, char[] name)
        {
            GetDelegateFor<Delegates.glBindFragDataLocationIndexedDelegate>()(program, colorNumber, index, name);
        }

        public static int glGetFragDataIndex(uint program, char[] name)
        {
            return (int)GetDelegateFor<Delegates.glGetFragDataIndexDelegate>()(program, name);
        }

        public static void glGenSamplers(int count, uint[] samplers)
        {
            GetDelegateFor<Delegates.glGenSamplersDelegate>()(count, samplers);
        }

        public static void glDeleteSamplers(int count, uint[] samplers)
        {
            GetDelegateFor<Delegates.glDeleteSamplersDelegate>()(count, samplers);
        }

        public static bool glIsSampler(uint sampler)
        {
            return (bool)GetDelegateFor<Delegates.glIsSamplerDelegate>()(sampler);
        }

        public static void glBindSampler(uint unit, uint sampler)
        {
            GetDelegateFor<Delegates.glBindSamplerDelegate>()(unit, sampler);
        }

        public static void glSamplerParameteri(uint sampler, uint pname, int param)
        {
            GetDelegateFor<Delegates.glSamplerParameteriDelegate>()(sampler, pname, param);
        }

        public static void glSamplerParameteriv(uint sampler, uint pname, int[] param)
        {
            GetDelegateFor<Delegates.glSamplerParameterivDelegate>()(sampler, pname, param);
        }

        public static void glSamplerParameterf(uint sampler, uint pname, float param)
        {
            GetDelegateFor<Delegates.glSamplerParameterfDelegate>()(sampler, pname, param);
        }

        public static void glSamplerParameterfv(uint sampler, uint pname, float[] param)
        {
            GetDelegateFor<Delegates.glSamplerParameterfvDelegate>()(sampler, pname, param);
        }

        public static void glSamplerParameterIiv(uint sampler, uint pname, int[] param)
        {
            GetDelegateFor<Delegates.glSamplerParameterIivDelegate>()(sampler, pname, param);
        }

        public static void glSamplerParameterIuiv(uint sampler, uint pname, uint[] param)
        {
            GetDelegateFor<Delegates.glSamplerParameterIuivDelegate>()(sampler, pname, param);
        }

        public static void glGetSamplerParameteriv(uint sampler, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetSamplerParameterivDelegate>()(sampler, pname, @params);
        }

        public static void glGetSamplerParameterIiv(uint sampler, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetSamplerParameterIivDelegate>()(sampler, pname, @params);
        }

        public static void glGetSamplerParameterfv(uint sampler, uint pname, float[] @params)
        {
            GetDelegateFor<Delegates.glGetSamplerParameterfvDelegate>()(sampler, pname, @params);
        }

        public static void glGetSamplerParameterIuiv(uint sampler, uint pname, uint[] @params)
        {
            GetDelegateFor<Delegates.glGetSamplerParameterIuivDelegate>()(sampler, pname, @params);
        }

        public static void glQueryCounter(uint id, uint target)
        {
            GetDelegateFor<Delegates.glQueryCounterDelegate>()(id, target);
        }

        public static void glGetQueryObjecti64v(uint id, uint pname, Int64[] @params)
        {
            GetDelegateFor<Delegates.glGetQueryObjecti64vDelegate>()(id, pname, @params);
        }

        public static void glGetQueryObjectui64v(uint id, uint pname, UInt64[] @params)
        {
            GetDelegateFor<Delegates.glGetQueryObjectui64vDelegate>()(id, pname, @params);
        }

        public static void glVertexAttribDivisor(uint index, uint divisor)
        {
            GetDelegateFor<Delegates.glVertexAttribDivisorDelegate>()(index, divisor);
        }

        public static void glVertexAttribP1ui(uint index, uint type, bool normalized, uint value)
        {
            GetDelegateFor<Delegates.glVertexAttribP1uiDelegate>()(index, type, normalized, value);
        }

        public static void glVertexAttribP1uiv(uint index, uint type, bool normalized, uint[] value)
        {
            GetDelegateFor<Delegates.glVertexAttribP1uivDelegate>()(index, type, normalized, value);
        }

        public static void glVertexAttribP2ui(uint index, uint type, bool normalized, uint value)
        {
            GetDelegateFor<Delegates.glVertexAttribP2uiDelegate>()(index, type, normalized, value);
        }

        public static void glVertexAttribP2uiv(uint index, uint type, bool normalized, uint[] value)
        {
            GetDelegateFor<Delegates.glVertexAttribP2uivDelegate>()(index, type, normalized, value);
        }

        public static void glVertexAttribP3ui(uint index, uint type, bool normalized, uint value)
        {
            GetDelegateFor<Delegates.glVertexAttribP3uiDelegate>()(index, type, normalized, value);
        }

        public static void glVertexAttribP3uiv(uint index, uint type, bool normalized, uint[] value)
        {
            GetDelegateFor<Delegates.glVertexAttribP3uivDelegate>()(index, type, normalized, value);
        }

        public static void glVertexAttribP4ui(uint index, uint type, bool normalized, uint value)
        {
            GetDelegateFor<Delegates.glVertexAttribP4uiDelegate>()(index, type, normalized, value);
        }

        public static void glVertexAttribP4uiv(uint index, uint type, bool normalized, uint[] value)
        {
            GetDelegateFor<Delegates.glVertexAttribP4uivDelegate>()(index, type, normalized, value);
        }

        public static void glVertexP2ui(uint type, uint value)
        {
            GetDelegateFor<Delegates.glVertexP2uiDelegate>()(type, value);
        }

        public static void glVertexP2uiv(uint type, uint[] value)
        {
            GetDelegateFor<Delegates.glVertexP2uivDelegate>()(type, value);
        }

        public static void glVertexP3ui(uint type, uint value)
        {
            GetDelegateFor<Delegates.glVertexP3uiDelegate>()(type, value);
        }

        public static void glVertexP3uiv(uint type, uint[] value)
        {
            GetDelegateFor<Delegates.glVertexP3uivDelegate>()(type, value);
        }

        public static void glVertexP4ui(uint type, uint value)
        {
            GetDelegateFor<Delegates.glVertexP4uiDelegate>()(type, value);
        }

        public static void glVertexP4uiv(uint type, uint[] value)
        {
            GetDelegateFor<Delegates.glVertexP4uivDelegate>()(type, value);
        }

        public static void glTexCoordP1ui(uint type, uint coords)
        {
            GetDelegateFor<Delegates.glTexCoordP1uiDelegate>()(type, coords);
        }

        public static void glTexCoordP1uiv(uint type, uint[] coords)
        {
            GetDelegateFor<Delegates.glTexCoordP1uivDelegate>()(type, coords);
        }

        public static void glTexCoordP2ui(uint type, uint coords)
        {
            GetDelegateFor<Delegates.glTexCoordP2uiDelegate>()(type, coords);
        }

        public static void glTexCoordP2uiv(uint type, uint[] coords)
        {
            GetDelegateFor<Delegates.glTexCoordP2uivDelegate>()(type, coords);
        }

        public static void glTexCoordP3ui(uint type, uint coords)
        {
            GetDelegateFor<Delegates.glTexCoordP3uiDelegate>()(type, coords);
        }

        public static void glTexCoordP3uiv(uint type, uint[] coords)
        {
            GetDelegateFor<Delegates.glTexCoordP3uivDelegate>()(type, coords);
        }

        public static void glTexCoordP4ui(uint type, uint coords)
        {
            GetDelegateFor<Delegates.glTexCoordP4uiDelegate>()(type, coords);
        }

        public static void glTexCoordP4uiv(uint type, uint[] coords)
        {
            GetDelegateFor<Delegates.glTexCoordP4uivDelegate>()(type, coords);
        }

        public static void glMultiTexCoordP1ui(uint texture, uint type, uint coords)
        {
            GetDelegateFor<Delegates.glMultiTexCoordP1uiDelegate>()(texture, type, coords);
        }

        public static void glMultiTexCoordP1uiv(uint texture, uint type, uint[] coords)
        {
            GetDelegateFor<Delegates.glMultiTexCoordP1uivDelegate>()(texture, type, coords);
        }

        public static void glMultiTexCoordP2ui(uint texture, uint type, uint coords)
        {
            GetDelegateFor<Delegates.glMultiTexCoordP2uiDelegate>()(texture, type, coords);
        }

        public static void glMultiTexCoordP2uiv(uint texture, uint type, uint[] coords)
        {
            GetDelegateFor<Delegates.glMultiTexCoordP2uivDelegate>()(texture, type, coords);
        }

        public static void glMultiTexCoordP3ui(uint texture, uint type, uint coords)
        {
            GetDelegateFor<Delegates.glMultiTexCoordP3uiDelegate>()(texture, type, coords);
        }

        public static void glMultiTexCoordP3uiv(uint texture, uint type, uint[] coords)
        {
            GetDelegateFor<Delegates.glMultiTexCoordP3uivDelegate>()(texture, type, coords);
        }

        public static void glMultiTexCoordP4ui(uint texture, uint type, uint coords)
        {
            GetDelegateFor<Delegates.glMultiTexCoordP4uiDelegate>()(texture, type, coords);
        }

        public static void glMultiTexCoordP4uiv(uint texture, uint type, uint[] coords)
        {
            GetDelegateFor<Delegates.glMultiTexCoordP4uivDelegate>()(texture, type, coords);
        }

        public static void glNormalP3ui(uint type, uint coords)
        {
            GetDelegateFor<Delegates.glNormalP3uiDelegate>()(type, coords);
        }

        public static void glNormalP3uiv(uint type, uint[] coords)
        {
            GetDelegateFor<Delegates.glNormalP3uivDelegate>()(type, coords);
        }

        public static void glColorP3ui(uint type, uint color)
        {
            GetDelegateFor<Delegates.glColorP3uiDelegate>()(type, color);
        }

        public static void glColorP3uiv(uint type, uint[] color)
        {
            GetDelegateFor<Delegates.glColorP3uivDelegate>()(type, color);
        }

        public static void glColorP4ui(uint type, uint color)
        {
            GetDelegateFor<Delegates.glColorP4uiDelegate>()(type, color);
        }

        public static void glColorP4uiv(uint type, uint[] color)
        {
            GetDelegateFor<Delegates.glColorP4uivDelegate>()(type, color);
        }

        public static void glSecondaryColorP3ui(uint type, uint color)
        {
            GetDelegateFor<Delegates.glSecondaryColorP3uiDelegate>()(type, color);
        }

        public static void glSecondaryColorP3uiv(uint type, uint[] color)
        {
            GetDelegateFor<Delegates.glSecondaryColorP3uivDelegate>()(type, color);
        }

        public static void glMinSampleShading(float value)
        {
            GetDelegateFor<Delegates.glMinSampleShadingDelegate>()(value);
        }

        public static void glBlendEquationi(uint buf, uint mode)
        {
            GetDelegateFor<Delegates.glBlendEquationiDelegate>()(buf, mode);
        }

        public static void glBlendEquationSeparatei(uint buf, uint modeRGB, uint modeAlpha)
        {
            GetDelegateFor<Delegates.glBlendEquationSeparateiDelegate>()(buf, modeRGB, modeAlpha);
        }

        public static void glBlendFunci(uint buf, uint src, uint dst)
        {
            GetDelegateFor<Delegates.glBlendFunciDelegate>()(buf, src, dst);
        }

        public static void glBlendFuncSeparatei(uint buf, uint srcRGB, uint dstRGB, uint srcAlpha, uint dstAlpha)
        {
            GetDelegateFor<Delegates.glBlendFuncSeparateiDelegate>()(buf, srcRGB, dstRGB, srcAlpha, dstAlpha);
        }

        public static void glDrawArraysIndirect(uint mode, IntPtr indirect)
        {
            GetDelegateFor<Delegates.glDrawArraysIndirectDelegate>()(mode, indirect);
        }

        public static void glDrawElementsIndirect(uint mode, uint type, IntPtr indirect)
        {
            GetDelegateFor<Delegates.glDrawElementsIndirectDelegate>()(mode, type, indirect);
        }

        public static void glUniform1d(uint location, double x)
        {
            GetDelegateFor<Delegates.glUniform1dDelegate>()(location, x);
        }

        public static void glUniform2d(uint location, double x, double y)
        {
            GetDelegateFor<Delegates.glUniform2dDelegate>()(location, x, y);
        }

        public static void glUniform3d(uint location, double x, double y, double z)
        {
            GetDelegateFor<Delegates.glUniform3dDelegate>()(location, x, y, z);
        }

        public static void glUniform4d(uint location, double x, double y, double z, double w)
        {
            GetDelegateFor<Delegates.glUniform4dDelegate>()(location, x, y, z, w);
        }

        public static void glUniform1dv(uint location, int count, double[] value)
        {
            GetDelegateFor<Delegates.glUniform1dvDelegate>()(location, count, value);
        }

        public static void glUniform2dv(uint location, int count, double[] value)
        {
            GetDelegateFor<Delegates.glUniform2dvDelegate>()(location, count, value);
        }

        public static void glUniform3dv(uint location, int count, double[] value)
        {
            GetDelegateFor<Delegates.glUniform3dvDelegate>()(location, count, value);
        }

        public static void glUniform4dv(uint location, int count, double[] value)
        {
            GetDelegateFor<Delegates.glUniform4dvDelegate>()(location, count, value);
        }

        public static void glUniformMatrix2dv(uint location, int count, bool transpose, double[] value)
        {
            GetDelegateFor<Delegates.glUniformMatrix2dvDelegate>()(location, count, transpose, value);
        }

        public static void glUniformMatrix3dv(uint location, int count, bool transpose, double[] value)
        {
            GetDelegateFor<Delegates.glUniformMatrix3dvDelegate>()(location, count, transpose, value);
        }

        public static void glUniformMatrix4dv(uint location, int count, bool transpose, double[] value)
        {
            GetDelegateFor<Delegates.glUniformMatrix4dvDelegate>()(location, count, transpose, value);
        }

        public static void glUniformMatrix2x3dv(uint location, int count, bool transpose, double[] value)
        {
            GetDelegateFor<Delegates.glUniformMatrix2x3dvDelegate>()(location, count, transpose, value);
        }

        public static void glUniformMatrix2x4dv(uint location, int count, bool transpose, double[] value)
        {
            GetDelegateFor<Delegates.glUniformMatrix2x4dvDelegate>()(location, count, transpose, value);
        }

        public static void glUniformMatrix3x2dv(uint location, int count, bool transpose, double[] value)
        {
            GetDelegateFor<Delegates.glUniformMatrix3x2dvDelegate>()(location, count, transpose, value);
        }

        public static void glUniformMatrix3x4dv(uint location, int count, bool transpose, double[] value)
        {
            GetDelegateFor<Delegates.glUniformMatrix3x4dvDelegate>()(location, count, transpose, value);
        }

        public static void glUniformMatrix4x2dv(uint location, int count, bool transpose, double[] value)
        {
            GetDelegateFor<Delegates.glUniformMatrix4x2dvDelegate>()(location, count, transpose, value);
        }

        public static void glUniformMatrix4x3dv(uint location, int count, bool transpose, double[] value)
        {
            GetDelegateFor<Delegates.glUniformMatrix4x3dvDelegate>()(location, count, transpose, value);
        }

        public static void glGetUniformdv(uint program, uint location, double[] @params)
        {
            GetDelegateFor<Delegates.glGetUniformdvDelegate>()(program, location, @params);
        }

        public static int glGetSubroutineUniformLocation(uint program, uint shadertype, char[] name)
        {
            return (int)GetDelegateFor<Delegates.glGetSubroutineUniformLocationDelegate>()(program, shadertype, name);
        }

        public static uint glGetSubroutineIndex(uint program, uint shadertype, char[] name)
        {
            return (uint)GetDelegateFor<Delegates.glGetSubroutineIndexDelegate>()(program, shadertype, name);
        }

        public static void glGetActiveSubroutineUniformiv(uint program, uint shadertype, uint index, uint pname, int[] values)
        {
            GetDelegateFor<Delegates.glGetActiveSubroutineUniformivDelegate>()(program, shadertype, index, pname, values);
        }

        public static void glGetActiveSubroutineUniformName(uint program, uint shadertype, uint index, int bufsize, int[] length, char[] name)
        {
            GetDelegateFor<Delegates.glGetActiveSubroutineUniformNameDelegate>()(program, shadertype, index, bufsize, length, name);
        }

        public static void glGetActiveSubroutineName(uint program, uint shadertype, uint index, int bufsize, int[] length, char[] name)
        {
            GetDelegateFor<Delegates.glGetActiveSubroutineNameDelegate>()(program, shadertype, index, bufsize, length, name);
        }

        public static void glUniformSubroutinesuiv(uint shadertype, int count, uint[] indices)
        {
            GetDelegateFor<Delegates.glUniformSubroutinesuivDelegate>()(shadertype, count, indices);
        }

        public static void glGetUniformSubroutineuiv(uint shadertype, uint location, uint[] @params)
        {
            GetDelegateFor<Delegates.glGetUniformSubroutineuivDelegate>()(shadertype, location, @params);
        }

        public static void glGetProgramStageiv(uint program, uint shadertype, uint pname, int[] values)
        {
            GetDelegateFor<Delegates.glGetProgramStageivDelegate>()(program, shadertype, pname, values);
        }

        public static void glPatchParameteri(uint pname, int value)
        {
            GetDelegateFor<Delegates.glPatchParameteriDelegate>()(pname, value);
        }

        public static void glPatchParameterfv(uint pname, float[] values)
        {
            GetDelegateFor<Delegates.glPatchParameterfvDelegate>()(pname, values);
        }

        public static void glBindTransformFeedback(uint target, uint id)
        {
            GetDelegateFor<Delegates.glBindTransformFeedbackDelegate>()(target, id);
        }

        public static void glDeleteTransformFeedbacks(int n, uint[] ids)
        {
            GetDelegateFor<Delegates.glDeleteTransformFeedbacksDelegate>()(n, ids);
        }

        public static void glGenTransformFeedbacks(int n, uint[] ids)
        {
            GetDelegateFor<Delegates.glGenTransformFeedbacksDelegate>()(n, ids);
        }

        public static bool glIsTransformFeedback(uint id)
        {
            return (bool)GetDelegateFor<Delegates.glIsTransformFeedbackDelegate>()(id);
        }

        public static void glPauseTransformFeedback()
        {
            GetDelegateFor<Delegates.glPauseTransformFeedbackDelegate>()();
        }

        public static void glResumeTransformFeedback()
        {
            GetDelegateFor<Delegates.glResumeTransformFeedbackDelegate>()();
        }

        public static void glDrawTransformFeedback(uint mode, uint id)
        {
            GetDelegateFor<Delegates.glDrawTransformFeedbackDelegate>()(mode, id);
        }

        public static void glDrawTransformFeedbackStream(uint mode, uint id, uint stream)
        {
            GetDelegateFor<Delegates.glDrawTransformFeedbackStreamDelegate>()(mode, id, stream);
        }

        public static void glBeginQueryIndexed(uint target, uint index, uint id)
        {
            GetDelegateFor<Delegates.glBeginQueryIndexedDelegate>()(target, index, id);
        }

        public static void glEndQueryIndexed(uint target, uint index)
        {
            GetDelegateFor<Delegates.glEndQueryIndexedDelegate>()(target, index);
        }

        public static void glGetQueryIndexediv(uint target, uint index, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetQueryIndexedivDelegate>()(target, index, pname, @params);
        }

        public static void glReleaseShaderCompiler()
        {
            GetDelegateFor<Delegates.glReleaseShaderCompilerDelegate>()();
        }

        public static void glShaderBinary(int count, uint[] shaders, uint binaryformat, IntPtr binary, int length)
        {
            GetDelegateFor<Delegates.glShaderBinaryDelegate>()(count, shaders, binaryformat, binary, length);
        }

        public static void glGetShaderPrecisionFormat(uint shadertype, uint precisiontype, int[] range, int[] precision)
        {
            GetDelegateFor<Delegates.glGetShaderPrecisionFormatDelegate>()(shadertype, precisiontype, range, precision);
        }

        public static void glDepthRangef(float n, float f)
        {
            GetDelegateFor<Delegates.glDepthRangefDelegate>()(n, f);
        }

        public static void glClearDepthf(float d)
        {
            GetDelegateFor<Delegates.glClearDepthfDelegate>()(d);
        }

        public static void glGetProgramBinary(uint program, int bufSize, int[] length, uint[] binaryFormat, IntPtr binary)
        {
            GetDelegateFor<Delegates.glGetProgramBinaryDelegate>()(program, bufSize, length, binaryFormat, binary);
        }

        public static void glProgramBinary(uint program, uint binaryFormat, IntPtr binary, int length)
        {
            GetDelegateFor<Delegates.glProgramBinaryDelegate>()(program, binaryFormat, binary, length);
        }

        public static void glProgramParameteri(uint program, uint pname, int value)
        {
            GetDelegateFor<Delegates.glProgramParameteriDelegate>()(program, pname, value);
        }

        public static void glUseProgramStages(uint pipeline, uint stages, uint program)
        {
            GetDelegateFor<Delegates.glUseProgramStagesDelegate>()(pipeline, stages, program);
        }

        public static void glActiveShaderProgram(uint pipeline, uint program)
        {
            GetDelegateFor<Delegates.glActiveShaderProgramDelegate>()(pipeline, program);
        }

        public static uint glCreateShaderProgramv(uint type, int count, char[] strings)
        {
            return (uint)GetDelegateFor<Delegates.glCreateShaderProgramvDelegate>()(type, count, strings);
        }

        public static void glBindProgramPipeline(uint pipeline)
        {
            GetDelegateFor<Delegates.glBindProgramPipelineDelegate>()(pipeline);
        }

        public static void glDeleteProgramPipelines(int n, uint[] pipelines)
        {
            GetDelegateFor<Delegates.glDeleteProgramPipelinesDelegate>()(n, pipelines);
        }

        public static void glGenProgramPipelines(int n, uint[] pipelines)
        {
            GetDelegateFor<Delegates.glGenProgramPipelinesDelegate>()(n, pipelines);
        }

        public static bool glIsProgramPipeline(uint pipeline)
        {
            return (bool)GetDelegateFor<Delegates.glIsProgramPipelineDelegate>()(pipeline);
        }

        public static void glGetProgramPipelineiv(uint pipeline, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetProgramPipelineivDelegate>()(pipeline, pname, @params);
        }

        public static void glProgramUniform1i(uint program, uint location, int v0)
        {
            GetDelegateFor<Delegates.glProgramUniform1iDelegate>()(program, location, v0);
        }

        public static void glProgramUniform1iv(uint program, uint location, int count, int[] value)
        {
            GetDelegateFor<Delegates.glProgramUniform1ivDelegate>()(program, location, count, value);
        }

        public static void glProgramUniform1f(uint program, uint location, float v0)
        {
            GetDelegateFor<Delegates.glProgramUniform1fDelegate>()(program, location, v0);
        }

        public static void glProgramUniform1fv(uint program, uint location, int count, float[] value)
        {
            GetDelegateFor<Delegates.glProgramUniform1fvDelegate>()(program, location, count, value);
        }

        public static void glProgramUniform1d(uint program, uint location, double v0)
        {
            GetDelegateFor<Delegates.glProgramUniform1dDelegate>()(program, location, v0);
        }

        public static void glProgramUniform1dv(uint program, uint location, int count, double[] value)
        {
            GetDelegateFor<Delegates.glProgramUniform1dvDelegate>()(program, location, count, value);
        }

        public static void glProgramUniform1ui(uint program, uint location, uint v0)
        {
            GetDelegateFor<Delegates.glProgramUniform1uiDelegate>()(program, location, v0);
        }

        public static void glProgramUniform1uiv(uint program, uint location, int count, uint[] value)
        {
            GetDelegateFor<Delegates.glProgramUniform1uivDelegate>()(program, location, count, value);
        }

        public static void glProgramUniform2i(uint program, uint location, int v0, int v1)
        {
            GetDelegateFor<Delegates.glProgramUniform2iDelegate>()(program, location, v0, v1);
        }

        public static void glProgramUniform2iv(uint program, uint location, int count, int[] value)
        {
            GetDelegateFor<Delegates.glProgramUniform2ivDelegate>()(program, location, count, value);
        }

        public static void glProgramUniform2f(uint program, uint location, float v0, float v1)
        {
            GetDelegateFor<Delegates.glProgramUniform2fDelegate>()(program, location, v0, v1);
        }

        public static void glProgramUniform2fv(uint program, uint location, int count, float[] value)
        {
            GetDelegateFor<Delegates.glProgramUniform2fvDelegate>()(program, location, count, value);
        }

        public static void glProgramUniform2d(uint program, uint location, double v0, double v1)
        {
            GetDelegateFor<Delegates.glProgramUniform2dDelegate>()(program, location, v0, v1);
        }

        public static void glProgramUniform2dv(uint program, uint location, int count, double[] value)
        {
            GetDelegateFor<Delegates.glProgramUniform2dvDelegate>()(program, location, count, value);
        }

        public static void glProgramUniform2ui(uint program, uint location, uint v0, uint v1)
        {
            GetDelegateFor<Delegates.glProgramUniform2uiDelegate>()(program, location, v0, v1);
        }

        public static void glProgramUniform2uiv(uint program, uint location, int count, uint[] value)
        {
            GetDelegateFor<Delegates.glProgramUniform2uivDelegate>()(program, location, count, value);
        }

        public static void glProgramUniform3i(uint program, uint location, int v0, int v1, int v2)
        {
            GetDelegateFor<Delegates.glProgramUniform3iDelegate>()(program, location, v0, v1, v2);
        }

        public static void glProgramUniform3iv(uint program, uint location, int count, int[] value)
        {
            GetDelegateFor<Delegates.glProgramUniform3ivDelegate>()(program, location, count, value);
        }

        public static void glProgramUniform3f(uint program, uint location, float v0, float v1, float v2)
        {
            GetDelegateFor<Delegates.glProgramUniform3fDelegate>()(program, location, v0, v1, v2);
        }

        public static void glProgramUniform3fv(uint program, uint location, int count, float[] value)
        {
            GetDelegateFor<Delegates.glProgramUniform3fvDelegate>()(program, location, count, value);
        }

        public static void glProgramUniform3d(uint program, uint location, double v0, double v1, double v2)
        {
            GetDelegateFor<Delegates.glProgramUniform3dDelegate>()(program, location, v0, v1, v2);
        }

        public static void glProgramUniform3dv(uint program, uint location, int count, double[] value)
        {
            GetDelegateFor<Delegates.glProgramUniform3dvDelegate>()(program, location, count, value);
        }

        public static void glProgramUniform3ui(uint program, uint location, uint v0, uint v1, uint v2)
        {
            GetDelegateFor<Delegates.glProgramUniform3uiDelegate>()(program, location, v0, v1, v2);
        }

        public static void glProgramUniform3uiv(uint program, uint location, int count, uint[] value)
        {
            GetDelegateFor<Delegates.glProgramUniform3uivDelegate>()(program, location, count, value);
        }

        public static void glProgramUniform4i(uint program, uint location, int v0, int v1, int v2, int v3)
        {
            GetDelegateFor<Delegates.glProgramUniform4iDelegate>()(program, location, v0, v1, v2, v3);
        }

        public static void glProgramUniform4iv(uint program, uint location, int count, int[] value)
        {
            GetDelegateFor<Delegates.glProgramUniform4ivDelegate>()(program, location, count, value);
        }

        public static void glProgramUniform4f(uint program, uint location, float v0, float v1, float v2, float v3)
        {
            GetDelegateFor<Delegates.glProgramUniform4fDelegate>()(program, location, v0, v1, v2, v3);
        }

        public static void glProgramUniform4fv(uint program, uint location, int count, float[] value)
        {
            GetDelegateFor<Delegates.glProgramUniform4fvDelegate>()(program, location, count, value);
        }

        public static void glProgramUniform4d(uint program, uint location, double v0, double v1, double v2, double v3)
        {
            GetDelegateFor<Delegates.glProgramUniform4dDelegate>()(program, location, v0, v1, v2, v3);
        }

        public static void glProgramUniform4dv(uint program, uint location, int count, double[] value)
        {
            GetDelegateFor<Delegates.glProgramUniform4dvDelegate>()(program, location, count, value);
        }

        public static void glProgramUniform4ui(uint program, uint location, uint v0, uint v1, uint v2, uint v3)
        {
            GetDelegateFor<Delegates.glProgramUniform4uiDelegate>()(program, location, v0, v1, v2, v3);
        }

        public static void glProgramUniform4uiv(uint program, uint location, int count, uint[] value)
        {
            GetDelegateFor<Delegates.glProgramUniform4uivDelegate>()(program, location, count, value);
        }

        public static void glProgramUniformMatrix2fv(uint program, uint location, int count, bool transpose, float[] value)
        {
            GetDelegateFor<Delegates.glProgramUniformMatrix2fvDelegate>()(program, location, count, transpose, value);
        }

        public static void glProgramUniformMatrix3fv(uint program, uint location, int count, bool transpose, float[] value)
        {
            GetDelegateFor<Delegates.glProgramUniformMatrix3fvDelegate>()(program, location, count, transpose, value);
        }

        public static void glProgramUniformMatrix4fv(uint program, uint location, int count, bool transpose, float[] value)
        {
            GetDelegateFor<Delegates.glProgramUniformMatrix4fvDelegate>()(program, location, count, transpose, value);
        }

        public static void glProgramUniformMatrix2dv(uint program, uint location, int count, bool transpose, double[] value)
        {
            GetDelegateFor<Delegates.glProgramUniformMatrix2dvDelegate>()(program, location, count, transpose, value);
        }

        public static void glProgramUniformMatrix3dv(uint program, uint location, int count, bool transpose, double[] value)
        {
            GetDelegateFor<Delegates.glProgramUniformMatrix3dvDelegate>()(program, location, count, transpose, value);
        }

        public static void glProgramUniformMatrix4dv(uint program, uint location, int count, bool transpose, double[] value)
        {
            GetDelegateFor<Delegates.glProgramUniformMatrix4dvDelegate>()(program, location, count, transpose, value);
        }

        public static void glProgramUniformMatrix2x3fv(uint program, uint location, int count, bool transpose, float[] value)
        {
            GetDelegateFor<Delegates.glProgramUniformMatrix2x3fvDelegate>()(program, location, count, transpose, value);
        }

        public static void glProgramUniformMatrix3x2fv(uint program, uint location, int count, bool transpose, float[] value)
        {
            GetDelegateFor<Delegates.glProgramUniformMatrix3x2fvDelegate>()(program, location, count, transpose, value);
        }

        public static void glProgramUniformMatrix2x4fv(uint program, uint location, int count, bool transpose, float[] value)
        {
            GetDelegateFor<Delegates.glProgramUniformMatrix2x4fvDelegate>()(program, location, count, transpose, value);
        }

        public static void glProgramUniformMatrix4x2fv(uint program, uint location, int count, bool transpose, float[] value)
        {
            GetDelegateFor<Delegates.glProgramUniformMatrix4x2fvDelegate>()(program, location, count, transpose, value);
        }

        public static void glProgramUniformMatrix3x4fv(uint program, uint location, int count, bool transpose, float[] value)
        {
            GetDelegateFor<Delegates.glProgramUniformMatrix3x4fvDelegate>()(program, location, count, transpose, value);
        }

        public static void glProgramUniformMatrix4x3fv(uint program, uint location, int count, bool transpose, float[] value)
        {
            GetDelegateFor<Delegates.glProgramUniformMatrix4x3fvDelegate>()(program, location, count, transpose, value);
        }

        public static void glProgramUniformMatrix2x3dv(uint program, uint location, int count, bool transpose, double[] value)
        {
            GetDelegateFor<Delegates.glProgramUniformMatrix2x3dvDelegate>()(program, location, count, transpose, value);
        }

        public static void glProgramUniformMatrix3x2dv(uint program, uint location, int count, bool transpose, double[] value)
        {
            GetDelegateFor<Delegates.glProgramUniformMatrix3x2dvDelegate>()(program, location, count, transpose, value);
        }

        public static void glProgramUniformMatrix2x4dv(uint program, uint location, int count, bool transpose, double[] value)
        {
            GetDelegateFor<Delegates.glProgramUniformMatrix2x4dvDelegate>()(program, location, count, transpose, value);
        }

        public static void glProgramUniformMatrix4x2dv(uint program, uint location, int count, bool transpose, double[] value)
        {
            GetDelegateFor<Delegates.glProgramUniformMatrix4x2dvDelegate>()(program, location, count, transpose, value);
        }

        public static void glProgramUniformMatrix3x4dv(uint program, uint location, int count, bool transpose, double[] value)
        {
            GetDelegateFor<Delegates.glProgramUniformMatrix3x4dvDelegate>()(program, location, count, transpose, value);
        }

        public static void glProgramUniformMatrix4x3dv(uint program, uint location, int count, bool transpose, double[] value)
        {
            GetDelegateFor<Delegates.glProgramUniformMatrix4x3dvDelegate>()(program, location, count, transpose, value);
        }

        public static void glValidateProgramPipeline(uint pipeline)
        {
            GetDelegateFor<Delegates.glValidateProgramPipelineDelegate>()(pipeline);
        }

        public static void glGetProgramPipelineInfoLog(uint pipeline, int bufSize, int[] length, char[] infoLog)
        {
            GetDelegateFor<Delegates.glGetProgramPipelineInfoLogDelegate>()(pipeline, bufSize, length, infoLog);
        }

        public static void glVertexAttribL1d(uint index, double x)
        {
            GetDelegateFor<Delegates.glVertexAttribL1dDelegate>()(index, x);
        }

        public static void glVertexAttribL2d(uint index, double x, double y)
        {
            GetDelegateFor<Delegates.glVertexAttribL2dDelegate>()(index, x, y);
        }

        public static void glVertexAttribL3d(uint index, double x, double y, double z)
        {
            GetDelegateFor<Delegates.glVertexAttribL3dDelegate>()(index, x, y, z);
        }

        public static void glVertexAttribL4d(uint index, double x, double y, double z, double w)
        {
            GetDelegateFor<Delegates.glVertexAttribL4dDelegate>()(index, x, y, z, w);
        }

        public static void glVertexAttribL1dv(uint index, double[] v)
        {
            GetDelegateFor<Delegates.glVertexAttribL1dvDelegate>()(index, v);
        }

        public static void glVertexAttribL2dv(uint index, double[] v)
        {
            GetDelegateFor<Delegates.glVertexAttribL2dvDelegate>()(index, v);
        }

        public static void glVertexAttribL3dv(uint index, double[] v)
        {
            GetDelegateFor<Delegates.glVertexAttribL3dvDelegate>()(index, v);
        }

        public static void glVertexAttribL4dv(uint index, double[] v)
        {
            GetDelegateFor<Delegates.glVertexAttribL4dvDelegate>()(index, v);
        }

        public static void glVertexAttribLPointer(uint index, int size, uint type, int stride, IntPtr pointer)
        {
            GetDelegateFor<Delegates.glVertexAttribLPointerDelegate>()(index, size, type, stride, pointer);
        }

        public static void glGetVertexAttribLdv(uint index, uint pname, double[] @params)
        {
            GetDelegateFor<Delegates.glGetVertexAttribLdvDelegate>()(index, pname, @params);
        }

        public static void glViewportArrayv(uint first, int count, float[] v)
        {
            GetDelegateFor<Delegates.glViewportArrayvDelegate>()(first, count, v);
        }

        public static void glViewportIndexedf(uint index, float x, float y, float w, float h)
        {
            GetDelegateFor<Delegates.glViewportIndexedfDelegate>()(index, x, y, w, h);
        }

        public static void glViewportIndexedfv(uint index, float[] v)
        {
            GetDelegateFor<Delegates.glViewportIndexedfvDelegate>()(index, v);
        }

        public static void glScissorArrayv(uint first, int count, int[] v)
        {
            GetDelegateFor<Delegates.glScissorArrayvDelegate>()(first, count, v);
        }

        public static void glScissorIndexed(uint index, int left, int bottom, int width, int height)
        {
            GetDelegateFor<Delegates.glScissorIndexedDelegate>()(index, left, bottom, width, height);
        }

        public static void glScissorIndexedv(uint index, int[] v)
        {
            GetDelegateFor<Delegates.glScissorIndexedvDelegate>()(index, v);
        }

        public static void glDepthRangeArrayv(uint first, int count, double[] v)
        {
            GetDelegateFor<Delegates.glDepthRangeArrayvDelegate>()(first, count, v);
        }

        public static void glDepthRangeIndexed(uint index, double n, double f)
        {
            GetDelegateFor<Delegates.glDepthRangeIndexedDelegate>()(index, n, f);
        }

        public static void glGetFloati_v(uint target, uint index, float[] data)
        {
            GetDelegateFor<Delegates.glGetFloati_vDelegate>()(target, index, data);
        }

        public static void glGetDoublei_v(uint target, uint index, double[] data)
        {
            GetDelegateFor<Delegates.glGetDoublei_vDelegate>()(target, index, data);
        }

        public static void glDrawArraysInstancedBaseInstance(uint mode, int first, int count, int instancecount, uint baseinstance)
        {
            GetDelegateFor<Delegates.glDrawArraysInstancedBaseInstanceDelegate>()(mode, first, count, instancecount, baseinstance);
        }

        public static void glDrawElementsInstancedBaseInstance(uint mode, int count, uint type, IntPtr indices, int instancecount, uint baseinstance)
        {
            GetDelegateFor<Delegates.glDrawElementsInstancedBaseInstanceDelegate>()(mode, count, type, indices, instancecount, baseinstance);
        }

        public static void glDrawElementsInstancedBaseVertexBaseInstance(uint mode, int count, uint type, IntPtr indices, int instancecount, int basevertex, uint baseinstance)
        {
            GetDelegateFor<Delegates.glDrawElementsInstancedBaseVertexBaseInstanceDelegate>()(mode, count, type, indices, instancecount, basevertex, baseinstance);
        }

        public static void glGetInternalformativ(uint target, uint internalformat, uint pname, int bufSize, int[] @params)
        {
            GetDelegateFor<Delegates.glGetInternalformativDelegate>()(target, internalformat, pname, bufSize, @params);
        }

        public static void glGetActiveAtomicCounterBufferiv(uint program, uint bufferIndex, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetActiveAtomicCounterBufferivDelegate>()(program, bufferIndex, pname, @params);
        }

        public static void glBindImageTexture(uint unit, uint texture, int level, bool layered, int layer, uint access, uint format)
        {
            GetDelegateFor<Delegates.glBindImageTextureDelegate>()(unit, texture, level, layered, layer, access, format);
        }

        public static void glMemoryBarrier(uint barriers)
        {
            GetDelegateFor<Delegates.glMemoryBarrierDelegate>()(barriers);
        }

        public static void glTexStorage1D(uint target, int levels, uint internalformat, int width)
        {
            GetDelegateFor<Delegates.glTexStorage1DDelegate>()(target, levels, internalformat, width);
        }

        public static void glTexStorage2D(uint target, int levels, uint internalformat, int width, int height)
        {
            GetDelegateFor<Delegates.glTexStorage2DDelegate>()(target, levels, internalformat, width, height);
        }

        public static void glTexStorage3D(uint target, int levels, uint internalformat, int width, int height, int depth)
        {
            GetDelegateFor<Delegates.glTexStorage3DDelegate>()(target, levels, internalformat, width, height, depth);
        }

        public static void glDrawTransformFeedbackInstanced(uint mode, uint id, int instancecount)
        {
            GetDelegateFor<Delegates.glDrawTransformFeedbackInstancedDelegate>()(mode, id, instancecount);
        }

        public static void glDrawTransformFeedbackStreamInstanced(uint mode, uint id, uint stream, int instancecount)
        {
            GetDelegateFor<Delegates.glDrawTransformFeedbackStreamInstancedDelegate>()(mode, id, stream, instancecount);
        }

        public static void glClearBufferData(uint target, uint internalformat, uint format, uint type, IntPtr data)
        {
            GetDelegateFor<Delegates.glClearBufferDataDelegate>()(target, internalformat, format, type, data);
        }

        public static void glClearBufferSubData(uint target, uint internalformat, IntPtr offset, IntPtr size, uint format, uint type, IntPtr data)
        {
            GetDelegateFor<Delegates.glClearBufferSubDataDelegate>()(target, internalformat, offset, size, format, type, data);
        }

        public static void glDispatchCompute(uint num_groups_x, uint num_groups_y, uint num_groups_z)
        {
            GetDelegateFor<Delegates.glDispatchComputeDelegate>()(num_groups_x, num_groups_y, num_groups_z);
        }

        public static void glDispatchComputeIndirect(IntPtr indirect)
        {
            GetDelegateFor<Delegates.glDispatchComputeIndirectDelegate>()(indirect);
        }

        public static void glCopyImageSubData(uint srcName, uint srcTarget, int srcLevel, int srcX, int srcY, int srcZ, uint dstName, uint dstTarget, int dstLevel, int dstX, int dstY, int dstZ, int srcWidth, int srcHeight, int srcDepth)
        {
            GetDelegateFor<Delegates.glCopyImageSubDataDelegate>()(srcName, srcTarget, srcLevel, srcX, srcY, srcZ, dstName, dstTarget, dstLevel, dstX, dstY, dstZ, srcWidth, srcHeight, srcDepth);
        }

        public static void glFramebufferParameteri(uint target, uint pname, int param)
        {
            GetDelegateFor<Delegates.glFramebufferParameteriDelegate>()(target, pname, param);
        }

        public static void glGetFramebufferParameteriv(uint target, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetFramebufferParameterivDelegate>()(target, pname, @params);
        }

        public static void glGetInternalformati64v(uint target, uint internalformat, uint pname, int bufSize, Int64[] @params)
        {
            GetDelegateFor<Delegates.glGetInternalformati64vDelegate>()(target, internalformat, pname, bufSize, @params);
        }

        public static void glInvalidateTexSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth)
        {
            GetDelegateFor<Delegates.glInvalidateTexSubImageDelegate>()(texture, level, xoffset, yoffset, zoffset, width, height, depth);
        }

        public static void glInvalidateTexImage(uint texture, int level)
        {
            GetDelegateFor<Delegates.glInvalidateTexImageDelegate>()(texture, level);
        }

        public static void glInvalidateBufferSubData(uint buffer, IntPtr offset, IntPtr length)
        {
            GetDelegateFor<Delegates.glInvalidateBufferSubDataDelegate>()(buffer, offset, length);
        }

        public static void glInvalidateBufferData(uint buffer)
        {
            GetDelegateFor<Delegates.glInvalidateBufferDataDelegate>()(buffer);
        }

        public static void glInvalidateFramebuffer(uint target, int numAttachments, uint[] attachments)
        {
            GetDelegateFor<Delegates.glInvalidateFramebufferDelegate>()(target, numAttachments, attachments);
        }

        public static void glInvalidateSubFramebuffer(uint target, int numAttachments, uint[] attachments, int x, int y, int width, int height)
        {
            GetDelegateFor<Delegates.glInvalidateSubFramebufferDelegate>()(target, numAttachments, attachments, x, y, width, height);
        }

        public static void glMultiDrawArraysIndirect(uint mode, IntPtr indirect, int drawcount, int stride)
        {
            GetDelegateFor<Delegates.glMultiDrawArraysIndirectDelegate>()(mode, indirect, drawcount, stride);
        }

        public static void glMultiDrawElementsIndirect(uint mode, uint type, IntPtr indirect, int drawcount, int stride)
        {
            GetDelegateFor<Delegates.glMultiDrawElementsIndirectDelegate>()(mode, type, indirect, drawcount, stride);
        }

        public static void glGetProgramInterfaceiv(uint program, uint programInterface, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetProgramInterfaceivDelegate>()(program, programInterface, pname, @params);
        }

        public static uint glGetProgramResourceIndex(uint program, uint programInterface, char[] name)
        {
            return (uint)GetDelegateFor<Delegates.glGetProgramResourceIndexDelegate>()(program, programInterface, name);
        }

        public static void glGetProgramResourceName(uint program, uint programInterface, uint index, int bufSize, int[] length, char[] name)
        {
            GetDelegateFor<Delegates.glGetProgramResourceNameDelegate>()(program, programInterface, index, bufSize, length, name);
        }

        public static void glGetProgramResourceiv(uint program, uint programInterface, uint index, int propCount, uint[] props, int bufSize, int[] length, int[] @params)
        {
            GetDelegateFor<Delegates.glGetProgramResourceivDelegate>()(program, programInterface, index, propCount, props, bufSize, length, @params);
        }

        public static int glGetProgramResourceLocation(uint program, uint programInterface, char[] name)
        {
            return (int)GetDelegateFor<Delegates.glGetProgramResourceLocationDelegate>()(program, programInterface, name);
        }

        public static int glGetProgramResourceLocationIndex(uint program, uint programInterface, char[] name)
        {
            return (int)GetDelegateFor<Delegates.glGetProgramResourceLocationIndexDelegate>()(program, programInterface, name);
        }

        public static void glShaderStorageBlockBinding(uint program, uint storageBlockIndex, uint storageBlockBinding)
        {
            GetDelegateFor<Delegates.glShaderStorageBlockBindingDelegate>()(program, storageBlockIndex, storageBlockBinding);
        }

        public static void glTexBufferRange(uint target, uint internalformat, uint buffer, IntPtr offset, IntPtr size)
        {
            GetDelegateFor<Delegates.glTexBufferRangeDelegate>()(target, internalformat, buffer, offset, size);
        }

        public static void glTexStorage2DMultisample(uint target, int samples, uint internalformat, int width, int height, bool fixedsamplelocations)
        {
            GetDelegateFor<Delegates.glTexStorage2DMultisampleDelegate>()(target, samples, internalformat, width, height, fixedsamplelocations);
        }

        public static void glTexStorage3DMultisample(uint target, int samples, uint internalformat, int width, int height, int depth, bool fixedsamplelocations)
        {
            GetDelegateFor<Delegates.glTexStorage3DMultisampleDelegate>()(target, samples, internalformat, width, height, depth, fixedsamplelocations);
        }

        public static void glTextureView(uint texture, uint target, uint origtexture, uint internalformat, uint minlevel, uint numlevels, uint minlayer, uint numlayers)
        {
            GetDelegateFor<Delegates.glTextureViewDelegate>()(texture, target, origtexture, internalformat, minlevel, numlevels, minlayer, numlayers);
        }

        public static void glBindVertexBuffer(uint bindingindex, uint buffer, IntPtr offset, int stride)
        {
            GetDelegateFor<Delegates.glBindVertexBufferDelegate>()(bindingindex, buffer, offset, stride);
        }

        public static void glVertexAttribFormat(uint attribindex, int size, uint type, bool normalized, uint relativeoffset)
        {
            GetDelegateFor<Delegates.glVertexAttribFormatDelegate>()(attribindex, size, type, normalized, relativeoffset);
        }

        public static void glVertexAttribIFormat(uint attribindex, int size, uint type, uint relativeoffset)
        {
            GetDelegateFor<Delegates.glVertexAttribIFormatDelegate>()(attribindex, size, type, relativeoffset);
        }

        public static void glVertexAttribLFormat(uint attribindex, int size, uint type, uint relativeoffset)
        {
            GetDelegateFor<Delegates.glVertexAttribLFormatDelegate>()(attribindex, size, type, relativeoffset);
        }

        public static void glVertexAttribBinding(uint attribindex, uint bindingindex)
        {
            GetDelegateFor<Delegates.glVertexAttribBindingDelegate>()(attribindex, bindingindex);
        }

        public static void glVertexBindingDivisor(uint bindingindex, uint divisor)
        {
            GetDelegateFor<Delegates.glVertexBindingDivisorDelegate>()(bindingindex, divisor);
        }

        public static void glDebugMessageControl(uint source, uint type, uint severity, int count, uint[] ids, bool enabled)
        {
            GetDelegateFor<Delegates.glDebugMessageControlDelegate>()(source, type, severity, count, ids, enabled);
        }

        public static void glDebugMessageInsert(uint source, uint type, uint id, uint severity, int length, char[] buf)
        {
            GetDelegateFor<Delegates.glDebugMessageInsertDelegate>()(source, type, id, severity, length, buf);
        }

        public static void glDebugMessageCallback(IntPtr callback, IntPtr userParam)
        {
            GetDelegateFor<Delegates.glDebugMessageCallbackDelegate>()(callback, userParam);
        }

        public static uint glGetDebugMessageLog(uint count, int bufSize, uint[] sources, uint[] types, uint[] ids, uint[] severities, int[] lengths, char[] messageLog)
        {
            return (uint)GetDelegateFor<Delegates.glGetDebugMessageLogDelegate>()(count, bufSize, sources, types, ids, severities, lengths, messageLog);
        }

        public static void glPushDebugGroup(uint source, uint id, int length, char[] message)
        {
            GetDelegateFor<Delegates.glPushDebugGroupDelegate>()(source, id, length, message);
        }

        public static void glPopDebugGroup()
        {
            GetDelegateFor<Delegates.glPopDebugGroupDelegate>()();
        }

        public static void glObjectLabel(uint identifier, uint name, int length, char[] label)
        {
            GetDelegateFor<Delegates.glObjectLabelDelegate>()(identifier, name, length, label);
        }

        public static void glGetObjectLabel(uint identifier, uint name, int bufSize, int[] length, char[] label)
        {
            GetDelegateFor<Delegates.glGetObjectLabelDelegate>()(identifier, name, bufSize, length, label);
        }

        public static void glObjectPtrLabel(IntPtr ptr, int length, char[] label)
        {
            GetDelegateFor<Delegates.glObjectPtrLabelDelegate>()(ptr, length, label);
        }

        public static void glGetObjectPtrLabel(IntPtr ptr, int bufSize, int[] length, char[] label)
        {
            GetDelegateFor<Delegates.glGetObjectPtrLabelDelegate>()(ptr, bufSize, length, label);
        }

        public static void glBufferStorage(uint target, IntPtr size, IntPtr data, uint flags)
        {
            GetDelegateFor<Delegates.glBufferStorageDelegate>()(target, size, data, flags);
        }

        public static void glClearTexImage(uint texture, int level, uint format, uint type, IntPtr data)
        {
            GetDelegateFor<Delegates.glClearTexImageDelegate>()(texture, level, format, type, data);
        }

        public static void glClearTexSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, IntPtr data)
        {
            GetDelegateFor<Delegates.glClearTexSubImageDelegate>()(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, data);
        }

        public static void glBindBuffersBase(uint target, uint first, int count, uint[] buffers)
        {
            GetDelegateFor<Delegates.glBindBuffersBaseDelegate>()(target, first, count, buffers);
        }

        public static void glBindBuffersRange(uint target, uint first, int count, uint[] buffers, IntPtr offsets, IntPtr sizes)
        {
            GetDelegateFor<Delegates.glBindBuffersRangeDelegate>()(target, first, count, buffers, offsets, sizes);
        }

        public static void glBindTextures(uint first, int count, uint[] textures)
        {
            GetDelegateFor<Delegates.glBindTexturesDelegate>()(first, count, textures);
        }

        public static void glBindSamplers(uint first, int count, uint[] samplers)
        {
            GetDelegateFor<Delegates.glBindSamplersDelegate>()(first, count, samplers);
        }

        public static void glBindImageTextures(uint first, int count, uint[] textures)
        {
            GetDelegateFor<Delegates.glBindImageTexturesDelegate>()(first, count, textures);
        }

        public static void glBindVertexBuffers(uint first, int count, uint[] buffers, IntPtr offsets, int[] strides)
        {
            GetDelegateFor<Delegates.glBindVertexBuffersDelegate>()(first, count, buffers, offsets, strides);
        }

        public static void glClipControl(uint origin, uint depth)
        {
            GetDelegateFor<Delegates.glClipControlDelegate>()(origin, depth);
        }

        public static void glCreateTransformFeedbacks(int n, uint[] ids)
        {
            GetDelegateFor<Delegates.glCreateTransformFeedbacksDelegate>()(n, ids);
        }

        public static void glTransformFeedbackBufferBase(uint xfb, uint index, uint buffer)
        {
            GetDelegateFor<Delegates.glTransformFeedbackBufferBaseDelegate>()(xfb, index, buffer);
        }

        public static void glTransformFeedbackBufferRange(uint xfb, uint index, uint buffer, IntPtr offset, IntPtr size)
        {
            GetDelegateFor<Delegates.glTransformFeedbackBufferRangeDelegate>()(xfb, index, buffer, offset, size);
        }

        public static void glGetTransformFeedbackiv(uint xfb, uint pname, int[] param)
        {
            GetDelegateFor<Delegates.glGetTransformFeedbackivDelegate>()(xfb, pname, param);
        }

        public static void glGetTransformFeedbacki_v(uint xfb, uint pname, uint index, int[] param)
        {
            GetDelegateFor<Delegates.glGetTransformFeedbacki_vDelegate>()(xfb, pname, index, param);
        }

        public static void glGetTransformFeedbacki64_v(uint xfb, uint pname, uint index, Int64[] param)
        {
            GetDelegateFor<Delegates.glGetTransformFeedbacki64_vDelegate>()(xfb, pname, index, param);
        }

        public static void glCreateBuffers(int n, uint[] buffers)
        {
            GetDelegateFor<Delegates.glCreateBuffersDelegate>()(n, buffers);
        }

        public static void glNamedBufferStorage(uint buffer, IntPtr size, IntPtr data, uint flags)
        {
            GetDelegateFor<Delegates.glNamedBufferStorageDelegate>()(buffer, size, data, flags);
        }

        public static void glNamedBufferData(uint buffer, IntPtr size, IntPtr data, uint usage)
        {
            GetDelegateFor<Delegates.glNamedBufferDataDelegate>()(buffer, size, data, usage);
        }

        public static void glNamedBufferSubData(uint buffer, IntPtr offset, IntPtr size, IntPtr data)
        {
            GetDelegateFor<Delegates.glNamedBufferSubDataDelegate>()(buffer, offset, size, data);
        }

        public static void glCopyNamedBufferSubData(uint readBuffer, uint writeBuffer, IntPtr readOffset, IntPtr writeOffset, IntPtr size)
        {
            GetDelegateFor<Delegates.glCopyNamedBufferSubDataDelegate>()(readBuffer, writeBuffer, readOffset, writeOffset, size);
        }

        public static void glClearNamedBufferData(uint buffer, uint internalformat, uint format, uint type, IntPtr data)
        {
            GetDelegateFor<Delegates.glClearNamedBufferDataDelegate>()(buffer, internalformat, format, type, data);
        }

        public static void glClearNamedBufferSubData(uint buffer, uint internalformat, IntPtr offset, IntPtr size, uint format, uint type, IntPtr data)
        {
            GetDelegateFor<Delegates.glClearNamedBufferSubDataDelegate>()(buffer, internalformat, offset, size, format, type, data);
        }

        public static void glMapNamedBuffer(uint buffer, uint access)
        {
            GetDelegateFor<Delegates.glMapNamedBufferDelegate>()(buffer, access);
        }

        public static void glMapNamedBufferRange(uint buffer, IntPtr offset, IntPtr length, uint access)
        {
            GetDelegateFor<Delegates.glMapNamedBufferRangeDelegate>()(buffer, offset, length, access);
        }

        public static bool glUnmapNamedBuffer(uint buffer)
        {
            return (bool)GetDelegateFor<Delegates.glUnmapNamedBufferDelegate>()(buffer);
        }

        public static void glFlushMappedNamedBufferRange(uint buffer, IntPtr offset, IntPtr length)
        {
            GetDelegateFor<Delegates.glFlushMappedNamedBufferRangeDelegate>()(buffer, offset, length);
        }

        public static void glGetNamedBufferParameteriv(uint buffer, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetNamedBufferParameterivDelegate>()(buffer, pname, @params);
        }

        public static void glGetNamedBufferParameteri64v(uint buffer, uint pname, Int64[] @params)
        {
            GetDelegateFor<Delegates.glGetNamedBufferParameteri64vDelegate>()(buffer, pname, @params);
        }

        public static void glGetNamedBufferPointerv(uint buffer, uint pname, IntPtr @params)
        {
            GetDelegateFor<Delegates.glGetNamedBufferPointervDelegate>()(buffer, pname, @params);
        }

        public static void glGetNamedBufferSubData(uint buffer, IntPtr offset, IntPtr size, IntPtr data)
        {
            GetDelegateFor<Delegates.glGetNamedBufferSubDataDelegate>()(buffer, offset, size, data);
        }

        public static void glCreateFramebuffers(int n, uint[] framebuffers)
        {
            GetDelegateFor<Delegates.glCreateFramebuffersDelegate>()(n, framebuffers);
        }

        public static void glNamedFramebufferRenderbuffer(uint framebuffer, uint attachment, uint renderbuffertarget, uint renderbuffer)
        {
            GetDelegateFor<Delegates.glNamedFramebufferRenderbufferDelegate>()(framebuffer, attachment, renderbuffertarget, renderbuffer);
        }

        public static void glNamedFramebufferParameteri(uint framebuffer, uint pname, int param)
        {
            GetDelegateFor<Delegates.glNamedFramebufferParameteriDelegate>()(framebuffer, pname, param);
        }

        public static void glNamedFramebufferTexture(uint framebuffer, uint attachment, uint texture, int level)
        {
            GetDelegateFor<Delegates.glNamedFramebufferTextureDelegate>()(framebuffer, attachment, texture, level);
        }

        public static void glNamedFramebufferTextureLayer(uint framebuffer, uint attachment, uint texture, int level, int layer)
        {
            GetDelegateFor<Delegates.glNamedFramebufferTextureLayerDelegate>()(framebuffer, attachment, texture, level, layer);
        }

        public static void glNamedFramebufferDrawBuffer(uint framebuffer, uint buf)
        {
            GetDelegateFor<Delegates.glNamedFramebufferDrawBufferDelegate>()(framebuffer, buf);
        }

        public static void glNamedFramebufferDrawBuffers(uint framebuffer, int n, uint[] bufs)
        {
            GetDelegateFor<Delegates.glNamedFramebufferDrawBuffersDelegate>()(framebuffer, n, bufs);
        }

        public static void glNamedFramebufferReadBuffer(uint framebuffer, uint src)
        {
            GetDelegateFor<Delegates.glNamedFramebufferReadBufferDelegate>()(framebuffer, src);
        }

        public static void glInvalidateNamedFramebufferData(uint framebuffer, int numAttachments, uint[] attachments)
        {
            GetDelegateFor<Delegates.glInvalidateNamedFramebufferDataDelegate>()(framebuffer, numAttachments, attachments);
        }

        public static void glInvalidateNamedFramebufferSubData(uint framebuffer, int numAttachments, uint[] attachments, int x, int y, int width, int height)
        {
            GetDelegateFor<Delegates.glInvalidateNamedFramebufferSubDataDelegate>()(framebuffer, numAttachments, attachments, x, y, width, height);
        }

        public static void glClearNamedFramebufferiv(uint framebuffer, uint buffer, int drawbuffer, int[] value)
        {
            GetDelegateFor<Delegates.glClearNamedFramebufferivDelegate>()(framebuffer, buffer, drawbuffer, value);
        }

        public static void glClearNamedFramebufferuiv(uint framebuffer, uint buffer, int drawbuffer, uint[] value)
        {
            GetDelegateFor<Delegates.glClearNamedFramebufferuivDelegate>()(framebuffer, buffer, drawbuffer, value);
        }

        public static void glClearNamedFramebufferfv(uint framebuffer, uint buffer, int drawbuffer, float[] value)
        {
            GetDelegateFor<Delegates.glClearNamedFramebufferfvDelegate>()(framebuffer, buffer, drawbuffer, value);
        }

        public static void glClearNamedFramebufferfi(uint framebuffer, uint buffer, int drawbuffer, float depth, int stencil)
        {
            GetDelegateFor<Delegates.glClearNamedFramebufferfiDelegate>()(framebuffer, buffer, drawbuffer, depth, stencil);
        }

        public static void glBlitNamedFramebuffer(uint readFramebuffer, uint drawFramebuffer, int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, uint mask, uint filter)
        {
            GetDelegateFor<Delegates.glBlitNamedFramebufferDelegate>()(readFramebuffer, drawFramebuffer, srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);
        }

        public static uint glCheckNamedFramebufferStatus(uint framebuffer, uint target)
        {
            return (uint)GetDelegateFor<Delegates.glCheckNamedFramebufferStatusDelegate>()(framebuffer, target);
        }

        public static void glGetNamedFramebufferParameteriv(uint framebuffer, uint pname, int[] param)
        {
            GetDelegateFor<Delegates.glGetNamedFramebufferParameterivDelegate>()(framebuffer, pname, param);
        }

        public static void glGetNamedFramebufferAttachmentParameteriv(uint framebuffer, uint attachment, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetNamedFramebufferAttachmentParameterivDelegate>()(framebuffer, attachment, pname, @params);
        }

        public static void glCreateRenderbuffers(int n, uint[] renderbuffers)
        {
            GetDelegateFor<Delegates.glCreateRenderbuffersDelegate>()(n, renderbuffers);
        }

        public static void glNamedRenderbufferStorage(uint renderbuffer, uint internalformat, int width, int height)
        {
            GetDelegateFor<Delegates.glNamedRenderbufferStorageDelegate>()(renderbuffer, internalformat, width, height);
        }

        public static void glNamedRenderbufferStorageMultisample(uint renderbuffer, int samples, uint internalformat, int width, int height)
        {
            GetDelegateFor<Delegates.glNamedRenderbufferStorageMultisampleDelegate>()(renderbuffer, samples, internalformat, width, height);
        }

        public static void glGetNamedRenderbufferParameteriv(uint renderbuffer, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetNamedRenderbufferParameterivDelegate>()(renderbuffer, pname, @params);
        }

        public static void glCreateTextures(uint target, int n, uint[] textures)
        {
            GetDelegateFor<Delegates.glCreateTexturesDelegate>()(target, n, textures);
        }

        public static void glTextureBuffer(uint texture, uint internalformat, uint buffer)
        {
            GetDelegateFor<Delegates.glTextureBufferDelegate>()(texture, internalformat, buffer);
        }

        public static void glTextureBufferRange(uint texture, uint internalformat, uint buffer, IntPtr offset, IntPtr size)
        {
            GetDelegateFor<Delegates.glTextureBufferRangeDelegate>()(texture, internalformat, buffer, offset, size);
        }

        public static void glTextureStorage1D(uint texture, int levels, uint internalformat, int width)
        {
            GetDelegateFor<Delegates.glTextureStorage1DDelegate>()(texture, levels, internalformat, width);
        }

        public static void glTextureStorage2D(uint texture, int levels, uint internalformat, int width, int height)
        {
            GetDelegateFor<Delegates.glTextureStorage2DDelegate>()(texture, levels, internalformat, width, height);
        }

        public static void glTextureStorage3D(uint texture, int levels, uint internalformat, int width, int height, int depth)
        {
            GetDelegateFor<Delegates.glTextureStorage3DDelegate>()(texture, levels, internalformat, width, height, depth);
        }

        public static void glTextureStorage2DMultisample(uint texture, int samples, uint internalformat, int width, int height, bool fixedsamplelocations)
        {
            GetDelegateFor<Delegates.glTextureStorage2DMultisampleDelegate>()(texture, samples, internalformat, width, height, fixedsamplelocations);
        }

        public static void glTextureStorage3DMultisample(uint texture, int samples, uint internalformat, int width, int height, int depth, bool fixedsamplelocations)
        {
            GetDelegateFor<Delegates.glTextureStorage3DMultisampleDelegate>()(texture, samples, internalformat, width, height, depth, fixedsamplelocations);
        }

        public static void glTextureSubImage1D(uint texture, int level, int xoffset, int width, uint format, uint type, IntPtr pixels)
        {
            GetDelegateFor<Delegates.glTextureSubImage1DDelegate>()(texture, level, xoffset, width, format, type, pixels);
        }

        public static void glTextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, IntPtr pixels)
        {
            GetDelegateFor<Delegates.glTextureSubImage2DDelegate>()(texture, level, xoffset, yoffset, width, height, format, type, pixels);
        }

        public static void glTextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, IntPtr pixels)
        {
            GetDelegateFor<Delegates.glTextureSubImage3DDelegate>()(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
        }

        public static void glCompressedTextureSubImage1D(uint texture, int level, int xoffset, int width, uint format, int imageSize, IntPtr data)
        {
            GetDelegateFor<Delegates.glCompressedTextureSubImage1DDelegate>()(texture, level, xoffset, width, format, imageSize, data);
        }

        public static void glCompressedTextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, uint format, int imageSize, IntPtr data)
        {
            GetDelegateFor<Delegates.glCompressedTextureSubImage2DDelegate>()(texture, level, xoffset, yoffset, width, height, format, imageSize, data);
        }

        public static void glCompressedTextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, int imageSize, IntPtr data)
        {
            GetDelegateFor<Delegates.glCompressedTextureSubImage3DDelegate>()(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data);
        }

        public static void glCopyTextureSubImage1D(uint texture, int level, int xoffset, int x, int y, int width)
        {
            GetDelegateFor<Delegates.glCopyTextureSubImage1DDelegate>()(texture, level, xoffset, x, y, width);
        }

        public static void glCopyTextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int x, int y, int width, int height)
        {
            GetDelegateFor<Delegates.glCopyTextureSubImage2DDelegate>()(texture, level, xoffset, yoffset, x, y, width, height);
        }

        public static void glCopyTextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height)
        {
            GetDelegateFor<Delegates.glCopyTextureSubImage3DDelegate>()(texture, level, xoffset, yoffset, zoffset, x, y, width, height);
        }

        public static void glTextureParameterf(uint texture, uint pname, float param)
        {
            GetDelegateFor<Delegates.glTextureParameterfDelegate>()(texture, pname, param);
        }

        public static void glTextureParameterfv(uint texture, uint pname, float[] param)
        {
            GetDelegateFor<Delegates.glTextureParameterfvDelegate>()(texture, pname, param);
        }

        public static void glTextureParameteri(uint texture, uint pname, int param)
        {
            GetDelegateFor<Delegates.glTextureParameteriDelegate>()(texture, pname, param);
        }

        public static void glTextureParameterIiv(uint texture, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glTextureParameterIivDelegate>()(texture, pname, @params);
        }

        public static void glTextureParameterIuiv(uint texture, uint pname, uint[] @params)
        {
            GetDelegateFor<Delegates.glTextureParameterIuivDelegate>()(texture, pname, @params);
        }

        public static void glTextureParameteriv(uint texture, uint pname, int[] param)
        {
            GetDelegateFor<Delegates.glTextureParameterivDelegate>()(texture, pname, param);
        }

        public static void glGenerateTextureMipmap(uint texture)
        {
            GetDelegateFor<Delegates.glGenerateTextureMipmapDelegate>()(texture);
        }

        public static void glBindTextureUnit(uint unit, uint texture)
        {
            GetDelegateFor<Delegates.glBindTextureUnitDelegate>()(unit, texture);
        }

        public static void glGetTextureImage(uint texture, int level, uint format, uint type, int bufSize, IntPtr pixels)
        {
            GetDelegateFor<Delegates.glGetTextureImageDelegate>()(texture, level, format, type, bufSize, pixels);
        }

        public static void glGetCompressedTextureImage(uint texture, int level, int bufSize, IntPtr pixels)
        {
            GetDelegateFor<Delegates.glGetCompressedTextureImageDelegate>()(texture, level, bufSize, pixels);
        }

        public static void glGetTextureLevelParameterfv(uint texture, int level, uint pname, float[] @params)
        {
            GetDelegateFor<Delegates.glGetTextureLevelParameterfvDelegate>()(texture, level, pname, @params);
        }

        public static void glGetTextureLevelParameteriv(uint texture, int level, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetTextureLevelParameterivDelegate>()(texture, level, pname, @params);
        }

        public static void glGetTextureParameterfv(uint texture, uint pname, float[] @params)
        {
            GetDelegateFor<Delegates.glGetTextureParameterfvDelegate>()(texture, pname, @params);
        }

        public static void glGetTextureParameterIiv(uint texture, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetTextureParameterIivDelegate>()(texture, pname, @params);
        }

        public static void glGetTextureParameterIuiv(uint texture, uint pname, uint[] @params)
        {
            GetDelegateFor<Delegates.glGetTextureParameterIuivDelegate>()(texture, pname, @params);
        }

        public static void glGetTextureParameteriv(uint texture, uint pname, int[] @params)
        {
            GetDelegateFor<Delegates.glGetTextureParameterivDelegate>()(texture, pname, @params);
        }

        public static void glCreateVertexArrays(int n, uint[] arrays)
        {
            GetDelegateFor<Delegates.glCreateVertexArraysDelegate>()(n, arrays);
        }

        public static void glDisableVertexArrayAttrib(uint vaobj, uint index)
        {
            GetDelegateFor<Delegates.glDisableVertexArrayAttribDelegate>()(vaobj, index);
        }

        public static void glEnableVertexArrayAttrib(uint vaobj, uint index)
        {
            GetDelegateFor<Delegates.glEnableVertexArrayAttribDelegate>()(vaobj, index);
        }

        public static void glVertexArrayElementBuffer(uint vaobj, uint buffer)
        {
            GetDelegateFor<Delegates.glVertexArrayElementBufferDelegate>()(vaobj, buffer);
        }

        public static void glVertexArrayVertexBuffer(uint vaobj, uint bindingindex, uint buffer, IntPtr offset, int stride)
        {
            GetDelegateFor<Delegates.glVertexArrayVertexBufferDelegate>()(vaobj, bindingindex, buffer, offset, stride);
        }

        public static void glVertexArrayVertexBuffers(uint vaobj, uint first, int count, uint[] buffers, IntPtr offsets, int[] strides)
        {
            GetDelegateFor<Delegates.glVertexArrayVertexBuffersDelegate>()(vaobj, first, count, buffers, offsets, strides);
        }

        public static void glVertexArrayAttribBinding(uint vaobj, uint attribindex, uint bindingindex)
        {
            GetDelegateFor<Delegates.glVertexArrayAttribBindingDelegate>()(vaobj, attribindex, bindingindex);
        }

        public static void glVertexArrayAttribFormat(uint vaobj, uint attribindex, int size, uint type, bool normalized, uint relativeoffset)
        {
            GetDelegateFor<Delegates.glVertexArrayAttribFormatDelegate>()(vaobj, attribindex, size, type, normalized, relativeoffset);
        }

        public static void glVertexArrayAttribIFormat(uint vaobj, uint attribindex, int size, uint type, uint relativeoffset)
        {
            GetDelegateFor<Delegates.glVertexArrayAttribIFormatDelegate>()(vaobj, attribindex, size, type, relativeoffset);
        }

        public static void glVertexArrayAttribLFormat(uint vaobj, uint attribindex, int size, uint type, uint relativeoffset)
        {
            GetDelegateFor<Delegates.glVertexArrayAttribLFormatDelegate>()(vaobj, attribindex, size, type, relativeoffset);
        }

        public static void glVertexArrayBindingDivisor(uint vaobj, uint bindingindex, uint divisor)
        {
            GetDelegateFor<Delegates.glVertexArrayBindingDivisorDelegate>()(vaobj, bindingindex, divisor);
        }

        public static void glGetVertexArrayiv(uint vaobj, uint pname, int[] param)
        {
            GetDelegateFor<Delegates.glGetVertexArrayivDelegate>()(vaobj, pname, param);
        }

        public static void glGetVertexArrayIndexediv(uint vaobj, uint index, uint pname, int[] param)
        {
            GetDelegateFor<Delegates.glGetVertexArrayIndexedivDelegate>()(vaobj, index, pname, param);
        }

        public static void glGetVertexArrayIndexed64iv(uint vaobj, uint index, uint pname, Int64[] param)
        {
            GetDelegateFor<Delegates.glGetVertexArrayIndexed64ivDelegate>()(vaobj, index, pname, param);
        }

        public static void glCreateSamplers(int n, uint[] samplers)
        {
            GetDelegateFor<Delegates.glCreateSamplersDelegate>()(n, samplers);
        }

        public static void glCreateProgramPipelines(int n, uint[] pipelines)
        {
            GetDelegateFor<Delegates.glCreateProgramPipelinesDelegate>()(n, pipelines);
        }

        public static void glCreateQueries(uint target, int n, uint[] ids)
        {
            GetDelegateFor<Delegates.glCreateQueriesDelegate>()(target, n, ids);
        }

        public static void glGetQueryBufferObjecti64v(uint id, uint buffer, uint pname, IntPtr offset)
        {
            GetDelegateFor<Delegates.glGetQueryBufferObjecti64vDelegate>()(id, buffer, pname, offset);
        }

        public static void glGetQueryBufferObjectiv(uint id, uint buffer, uint pname, IntPtr offset)
        {
            GetDelegateFor<Delegates.glGetQueryBufferObjectivDelegate>()(id, buffer, pname, offset);
        }

        public static void glGetQueryBufferObjectui64v(uint id, uint buffer, uint pname, IntPtr offset)
        {
            GetDelegateFor<Delegates.glGetQueryBufferObjectui64vDelegate>()(id, buffer, pname, offset);
        }

        public static void glGetQueryBufferObjectuiv(uint id, uint buffer, uint pname, IntPtr offset)
        {
            GetDelegateFor<Delegates.glGetQueryBufferObjectuivDelegate>()(id, buffer, pname, offset);
        }

        public static void glMemoryBarrierByRegion(uint barriers)
        {
            GetDelegateFor<Delegates.glMemoryBarrierByRegionDelegate>()(barriers);
        }

        public static void glGetTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, int bufSize, IntPtr pixels)
        {
            GetDelegateFor<Delegates.glGetTextureSubImageDelegate>()(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, bufSize, pixels);
        }

        public static void glGetCompressedTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, int bufSize, IntPtr pixels)
        {
            GetDelegateFor<Delegates.glGetCompressedTextureSubImageDelegate>()(texture, level, xoffset, yoffset, zoffset, width, height, depth, bufSize, pixels);
        }

        public static uint glGetGraphicsResetStatus()
        {
            return (uint)GetDelegateFor<Delegates.glGetGraphicsResetStatusDelegate>()();
        }

        public static void glGetnCompressedTexImage(uint target, int lod, int bufSize, IntPtr pixels)
        {
            GetDelegateFor<Delegates.glGetnCompressedTexImageDelegate>()(target, lod, bufSize, pixels);
        }

        public static void glGetnTexImage(uint target, int level, uint format, uint type, int bufSize, IntPtr pixels)
        {
            GetDelegateFor<Delegates.glGetnTexImageDelegate>()(target, level, format, type, bufSize, pixels);
        }

        public static void glGetnUniformdv(uint program, uint location, int bufSize, double[] @params)
        {
            GetDelegateFor<Delegates.glGetnUniformdvDelegate>()(program, location, bufSize, @params);
        }

        public static void glGetnUniformfv(uint program, uint location, int bufSize, float[] @params)
        {
            GetDelegateFor<Delegates.glGetnUniformfvDelegate>()(program, location, bufSize, @params);
        }

        public static void glGetnUniformiv(uint program, uint location, int bufSize, int[] @params)
        {
            GetDelegateFor<Delegates.glGetnUniformivDelegate>()(program, location, bufSize, @params);
        }

        public static void glGetnUniformuiv(uint program, uint location, int bufSize, uint[] @params)
        {
            GetDelegateFor<Delegates.glGetnUniformuivDelegate>()(program, location, bufSize, @params);
        }

        public static void glReadnPixels(int x, int y, int width, int height, uint format, uint type, int bufSize, IntPtr data)
        {
            GetDelegateFor<Delegates.glReadnPixelsDelegate>()(x, y, width, height, format, type, bufSize, data);
        }

        public static void glGetnMapdv(uint target, uint query, int bufSize, double[] v)
        {
            GetDelegateFor<Delegates.glGetnMapdvDelegate>()(target, query, bufSize, v);
        }

        public static void glGetnMapfv(uint target, uint query, int bufSize, float[] v)
        {
            GetDelegateFor<Delegates.glGetnMapfvDelegate>()(target, query, bufSize, v);
        }

        public static void glGetnMapiv(uint target, uint query, int bufSize, int[] v)
        {
            GetDelegateFor<Delegates.glGetnMapivDelegate>()(target, query, bufSize, v);
        }

        public static void glGetnPixelMapfv(uint map, int bufSize, float[] values)
        {
            GetDelegateFor<Delegates.glGetnPixelMapfvDelegate>()(map, bufSize, values);
        }

        public static void glGetnPixelMapuiv(uint map, int bufSize, uint[] values)
        {
            GetDelegateFor<Delegates.glGetnPixelMapuivDelegate>()(map, bufSize, values);
        }

        public static void glGetnPixelMapusv(uint map, int bufSize, ushort[] values)
        {
            GetDelegateFor<Delegates.glGetnPixelMapusvDelegate>()(map, bufSize, values);
        }

        public static void glGetnPolygonStipple(int bufSize, byte[] pattern)
        {
            GetDelegateFor<Delegates.glGetnPolygonStippleDelegate>()(bufSize, pattern);
        }

        public static void glGetnColorTable(uint target, uint format, uint type, int bufSize, IntPtr table)
        {
            GetDelegateFor<Delegates.glGetnColorTableDelegate>()(target, format, type, bufSize, table);
        }

        public static void glGetnConvolutionFilter(uint target, uint format, uint type, int bufSize, IntPtr image)
        {
            GetDelegateFor<Delegates.glGetnConvolutionFilterDelegate>()(target, format, type, bufSize, image);
        }

        public static void glGetnSeparableFilter(uint target, uint format, uint type, int rowBufSize, IntPtr row, int columnBufSize, IntPtr column, IntPtr span)
        {
            GetDelegateFor<Delegates.glGetnSeparableFilterDelegate>()(target, format, type, rowBufSize, row, columnBufSize, column, span);
        }

        public static void glGetnHistogram(uint target, bool reset, uint format, uint type, int bufSize, IntPtr values)
        {
            GetDelegateFor<Delegates.glGetnHistogramDelegate>()(target, reset, format, type, bufSize, values);
        }

        public static void glGetnMinmax(uint target, bool reset, uint format, uint type, int bufSize, IntPtr values)
        {
            GetDelegateFor<Delegates.glGetnMinmaxDelegate>()(target, reset, format, type, bufSize, values);
        }

        public static void glTextureBarrier()
        {
            GetDelegateFor<Delegates.glTextureBarrierDelegate>()();
        }

        [DllImport(Native.Library, EntryPoint = "wglGetProcAddress", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern IntPtr wglGetProcAddress(string name);

        private static T GetDelegateFor<T>() where T : class => GetDelegateFor<T>(typeof(T).Name.Replace("Delegate", ""));

        private static T GetDelegateFor<T>(string name) where T : class
        {
            Type delegateType = typeof(T);
            IntPtr proc = wglGetProcAddress(name);
            Delegate del = Marshal.GetDelegateForFunctionPointer(proc, delegateType);

            return del as T;
        }
    }
}
