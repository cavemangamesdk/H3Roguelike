namespace MooseEngine.Platform.Glfw;

public partial class Glfw
{
    public static bool Init() => Functions.glfwInit();
    public static void Terminate() => Functions.glfwTerminate();

    public static void WindowHint(int target, int value) => Functions.glfwWindowHint(target, value);

    public static IntPtr CreateWindow(int width, int height, string title) => CreateWindow(width, height, title, IntPtr.Zero, IntPtr.Zero);
    public static IntPtr CreateWindow(int width, int height, string title, IntPtr monitor, IntPtr share) => Functions.glfwCreateWindow(width, height, title, monitor, share);
    public static void DestroyWindow(IntPtr windowPtr) => Functions.glfwDestroyWindow(windowPtr);

    public static void MakeContextCurrent(IntPtr windowHandlePtr) => Functions.glfwMakeContextCurrent(windowHandlePtr);
    public static bool WindowShouldClose(IntPtr windowHandlePtr) => Functions.glfwWindowShouldClose(windowHandlePtr);

    public static void SwapBuffers(IntPtr windowHandlePtr) => Functions.glfwSwapBuffers(windowHandlePtr);
    public static void PollEvents() => Functions.glfwPollEvents();

    // Events
    public static Delegates.GLFWwindowclosefun SetWindowCloseCallback(IntPtr windowHandlePtr, Delegates.GLFWwindowclosefun windowclosefun) => Functions.glfwSetWindowCloseCallback(windowHandlePtr, windowclosefun);
    public static Delegates.GLFWwindowsizefun SetWindowSizeCallback(IntPtr windowHandlePtr, Delegates.GLFWwindowsizefun windowsizefun) => Functions.glfwSetWindowSizeCallback(windowHandlePtr, windowsizefun);

    // Native
    public static IntPtr GetWin32Window(IntPtr glfwWindowPtr) => Native.glfwGetWin32Window(glfwWindowPtr);
}
