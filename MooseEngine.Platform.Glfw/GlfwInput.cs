namespace MooseEngine.Platform.Glfw;

internal sealed class GlfwInput : IInput
{
    public GlfwInput(IGlfwNativeWindowHandle nativeWindowHandle)
    {
        NativeWindowHandle = nativeWindowHandle;
    }

    private IGlfwNativeWindowHandle NativeWindowHandle { get; }

    public bool IsKeyPressed(Keycode keycode)
    {
        var state = Glfw.GetKey(NativeWindowHandle.GlfwNativeWindowHandle, (int)keycode);
        return state == GlfwConstants.GLFW_PRESS || state == GlfwConstants.GLFW_REPEAT;
    }
}
