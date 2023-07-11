using MooseEngine.Events;

namespace MooseEngine.Platform.Glfw;

internal interface IGlfwNativeWindowHandle
{
    IntPtr GlfwNativeWindowHandle { get; }
}

public sealed class GlfwWindow : IWindow, IGlfwNativeWindowHandle
{
    private EventCallbackFn? EventCallback { get; set; }

    private Glfw.Delegates.GLFWwindowclosefun? WindowCloseFunc { get; set; }
    private Glfw.Delegates.GLFWwindowsizefun? WindowResizeFunc { get; set; }

    public int Width => 1024;

    public int Height => 768;

    public bool ShouldClose => Glfw.WindowShouldClose(GlfwNativeWindowHandle);

    public nint GlfwNativeWindowHandle { get; set; } = IntPtr.Zero;

    public void SetEventCallback(EventCallbackFn eventCallbackFn)
    {
        EventCallback = eventCallbackFn;
    }

    public void Initialize()
    {
        if (!Glfw.Init())
        {
            throw new Exception("Failed to initialize Glfw");
        }

        Glfw.WindowHint(GlfwConstants.GLFW_CONTEXT_VERSION_MAJOR, 3);
        Glfw.WindowHint(GlfwConstants.GLFW_CONTEXT_VERSION_MINOR, 3);
        Glfw.WindowHint(GlfwConstants.GLFW_OPENGL_PROFILE, GlfwConstants.GLFW_OPENGL_CORE_PROFILE);

        GlfwNativeWindowHandle = Glfw.CreateWindow(1024, 768, "MooseEngine");
        if (GlfwNativeWindowHandle == IntPtr.Zero)
        {
            Glfw.Terminate();
            throw new Exception("Failed to create Glfw window");
        }

        Glfw.MakeContextCurrent(GlfwNativeWindowHandle);

        // TODO: Do something more smart than this... 
        WindowCloseFunc = WindowCloseEventFunc;
        Glfw.SetWindowCloseCallback(GlfwNativeWindowHandle, WindowCloseFunc);

        WindowResizeFunc = WindowResizeEventFunc;
        Glfw.SetWindowSizeCallback(GlfwNativeWindowHandle, WindowResizeFunc);
    }

    private void WindowResizeEventFunc(nint window, int width, int height)
    {
        EventCallback?.Invoke(new WindowResizeEvent(width, height));
    }

    private void WindowCloseEventFunc(nint window)
    {
        EventCallback?.Invoke(new WindowCloseEvent());
    }

    public void Update()
    {
        Glfw.SwapBuffers(GlfwNativeWindowHandle);
        Glfw.PollEvents();
    }

    public void Dispose()
    {
        if (GlfwNativeWindowHandle != IntPtr.Zero)
        {
            Glfw.DestroyWindow(GlfwNativeWindowHandle);
            GlfwNativeWindowHandle = IntPtr.Zero;
        }

        Glfw.Terminate();
    }
}
