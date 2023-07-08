using MooseEngine.Events;

namespace MooseEngine.Platform.Glfw;

public sealed class GlfwWindow : IWindow
{
    private IntPtr GlfwWindowPtr { get; set; } = IntPtr.Zero;
    private EventCallbackFn? EventCallback { get; set; }

    private Glfw.Delegates.GLFWwindowclosefun? WindowCloseFunc { get; set; }
    private Glfw.Delegates.GLFWwindowsizefun? WindowResizeFunc { get; set; }

    public bool ShouldClose => Glfw.WindowShouldClose(GlfwWindowPtr);

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

        GlfwWindowPtr = Glfw.CreateWindow(1024, 768, "MooseEngine");
        if (GlfwWindowPtr == IntPtr.Zero)
        {
            Glfw.Terminate();
            throw new Exception("Failed to create Glfw window");
        }

        Glfw.MakeContextCurrent(GlfwWindowPtr);

        // TODO: Do something more smart than this... 
        WindowCloseFunc = WindowCloseEventFunc;
        Glfw.SetWindowCloseCallback(GlfwWindowPtr, WindowCloseFunc);

        WindowResizeFunc = WindowResizeEventFunc;
        Glfw.SetWindowSizeCallback(GlfwWindowPtr, WindowResizeFunc);
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
        Glfw.SwapBuffers(GlfwWindowPtr);
        Glfw.PollEvents();
    }

    public void Dispose()
    {
        if(GlfwWindowPtr != IntPtr.Zero)
        {
            Glfw.DestroyWindow(GlfwWindowPtr);
            GlfwWindowPtr = IntPtr.Zero;
        }

        Glfw.Terminate();
    }
}
