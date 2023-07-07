using System.Runtime.InteropServices;

namespace MooseEngine.Platform.Glfw;

public partial class Glfw
{
    internal class Native
    {
        internal const string Library = "libs/x64/glfw3.dll";

        [DllImport(Library, EntryPoint = "glfwGetWin32Window", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        extern internal static IntPtr glfwGetWin32Window(IntPtr glfwWindowPtr);
    }
}

