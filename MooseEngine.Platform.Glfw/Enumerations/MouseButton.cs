namespace MooseEngine.Platform.Glfw.Enumerations;

public enum MouseButton
{
    Button1 = GlfwConstants.GLFW_MOUSE_BUTTON_1,
    Button2 = GlfwConstants.GLFW_MOUSE_BUTTON_2,
    Button3 = GlfwConstants.GLFW_MOUSE_BUTTON_3,
    Button4 = GlfwConstants.GLFW_MOUSE_BUTTON_4,
    Button5 = GlfwConstants.GLFW_MOUSE_BUTTON_5,
    Button6 = GlfwConstants.GLFW_MOUSE_BUTTON_6,
    Button7 = GlfwConstants.GLFW_MOUSE_BUTTON_7,
    Button8 = GlfwConstants.GLFW_MOUSE_BUTTON_8,

    Left = Button1,
    Right = Button2,
    Middle = Button3,

    Last = Button8
}