using System.Runtime.InteropServices;
using MooseEngine.Platform.Glfw.Structs;

namespace MooseEngine.Platform.Glfw;

public partial class Glfw
{
    internal class Functions
    {
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern IntPtr glfwGetWindowUserPointer(IntPtr window);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwGetVersion(ref int major, ref int minor, ref int rev);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwGetMonitorPos(IntPtr monitor, ref int xpos, ref int ypos);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwGetMonitorPhysicalSize(IntPtr monitor, ref int widthMM, ref int heightMM);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwGetWindowPos(IntPtr window, ref int xpos, ref int ypos);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwGetWindowSize(IntPtr window, ref int width, ref int height);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwGetFramebufferSize(IntPtr window, ref int width, ref int height);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwGetWindowFrameSize(IntPtr window, ref int left, ref int top, ref int right, ref int bottom);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwGetCursorPos(IntPtr window, ref double xpos, ref double ypos);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwSetGamma(IntPtr monitor, float gamma);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwSetGammaRamp(IntPtr monitor, long ramp);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwSetWindowShouldClose(IntPtr window, int value);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwSetWindowTitle(IntPtr window, string title);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwSetWindowPos(IntPtr window, int xpos, int ypos);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwSetWindowSize(IntPtr window, int width, int height);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwSetWindowUserPointer(IntPtr window, IntPtr pointer);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwSetCursorPos(IntPtr window, double xpos, double ypos);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwSetCursor(IntPtr window, long cursor);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwSetClipboardString(IntPtr window, string @string);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwSetTime(double time);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwSetInputMode(IntPtr window, int mode, int value);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwTerminate();
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwDefaultWindowHints();
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwWindowHint(int target, int hint);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwDestroyWindow(IntPtr window);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwIconifyWindow(IntPtr window);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern IntPtr glfwMaximizeWindow(IntPtr window);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwRestoreWindow(IntPtr window);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwShowWindow(IntPtr window);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwHideWindow(IntPtr window);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwPollEvents();
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwWaitEvents();
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwPostEmptyEvent();
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwDestroyCursor(long cursor);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwMakeContextCurrent(IntPtr window);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwSwapBuffers(IntPtr window);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwSwapInterval(int interval);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]

        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool glfwInit();

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]

        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool glfwWindowShouldClose(IntPtr window);

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern int glfwGetWindowAttrib(IntPtr window, int attrib);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern int glfwGetInputMode(IntPtr window, int mode);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern int glfwGetKey(IntPtr window, int key);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern int glfwGetMouseButton(IntPtr window, int button);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern int glfwJoystickPresent(int joy);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern int glfwExtensionSupported(string extension);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern IntPtr glfwGetJoystickButtons(int joy, out int count);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern string glfwGetVersionString();
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern string glfwGetMonitorName(IntPtr monitor);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern string glfwGetJoystickName(int joy);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern string glfwGetClipboardString(IntPtr window);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern long[] glfwGetVideoModes(IntPtr monitor, ref int count);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern long[] glfwGetMonitors(int count);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern long glfwGetVideoMode(IntPtr monitor);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern long glfwGetGammaRamp(IntPtr monitor);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern IntPtr glfwGetPrimaryMonitor();
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern IntPtr glfwCreateWindow(
            int width,
            int height,
            [MarshalAs(UnmanagedType.LPStr)] string title,
            IntPtr monitor,
            IntPtr share);

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern IntPtr glfwGetWindowMonitor(IntPtr window);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern long glfwCreateCursor(long image, int xhot, int yhot);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern long glfwCreateStandardCursor(int shape);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern long glfwGetCurrentContext();
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern long glfwGetProcAddress(string procname);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern IntPtr glfwGetJoystickAxes(int joy, out int count);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern IntPtr glfwGetJoystickHats(int joy, out int count);
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern double glfwGetTime();
        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void glfwSetWindowIcon(IntPtr window, int count, GLFWImage[] images);

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern Delegates.GLFWerrorfun glfwSetErrorCallback(Delegates.GLFWerrorfun cbfun);

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern Delegates.GLFWmonitorfun glfwSetMonitorCallback(Delegates.GLFWmonitorfun cbfun);

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern Delegates.GLFWwindowposfun glfwSetWindowPosCallback(IntPtr window, Delegates.GLFWwindowposfun cbfun);

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern Delegates.GLFWwindowsizefun glfwSetWindowSizeCallback(IntPtr window, Delegates.GLFWwindowsizefun cbfun);

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern Delegates.GLFWwindowclosefun glfwSetWindowCloseCallback(IntPtr window, Delegates.GLFWwindowclosefun cbfun);

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern Delegates.GLFWwindowrefreshfun glfwSetWindowRefreshCallback(IntPtr window, Delegates.GLFWwindowrefreshfun cbfun);

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern Delegates.GLFWwindowfocusfun glfwSetWindowFocusCallback(IntPtr window, Delegates.GLFWwindowfocusfun cbfun);

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern Delegates.GLFWwindowiconifyfun glfwSetWindowIconifyCallback(IntPtr window, Delegates.GLFWwindowiconifyfun cbfun);

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern Delegates.GLFWframebuffersizefun glfwSetFramebufferSizeCallback(IntPtr window, Delegates.GLFWframebuffersizefun cbfun);

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern Delegates.GLFWkeyfun glfwSetKeyCallback(IntPtr window, Delegates.GLFWkeyfun cbfun);

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern Delegates.GLFWcharfun glfwSetCharCallback(IntPtr window, Delegates.GLFWcharfun cbfun);

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern Delegates.GLFWcharmodsfun glfwSetCharModsCallback(IntPtr window, Delegates.GLFWcharmodsfun cbfun);

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern Delegates.GLFWmousebuttonfun glfwSetMouseButtonCallback(IntPtr window, Delegates.GLFWmousebuttonfun cbfun);

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern Delegates.GLFWcursorposfun glfwSetCursorPosCallback(IntPtr window, Delegates.GLFWcursorposfun cbfun);

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern Delegates.GLFWcursorenterfun glfwSetCursorEnterCallback(IntPtr window, Delegates.GLFWcursorenterfun cbfun);

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern Delegates.GLFWscrollfun glfwSetScrollCallback(IntPtr window, Delegates.GLFWscrollfun cbfun);

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern Delegates.GLFWdropfun glfwSetDropCallback(IntPtr window, Delegates.GLFWdropfun cbfun);

        [DllImport(Native.Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern Delegates.GLFWjoystickfun glfwSetJoystickCallback(Delegates.GLFWjoystickfun cbfun);
    }
}
