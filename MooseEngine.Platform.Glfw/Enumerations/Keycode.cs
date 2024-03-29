﻿namespace MooseEngine.Platform.Glfw.Enumerations;

public enum Keycode : int
{
    UNKNOWN = GlfwConstants.GLFW_KEY_UNKNOWN,               // -1
    SPACE = GlfwConstants.GLFW_KEY_SPACE,                   // 32
    APOSTROPHE = GlfwConstants.GLFW_KEY_APOSTROPHE,         // 39
    COMMA = GlfwConstants.GLFW_KEY_COMMA,                   // 44
    MINUS = GlfwConstants.GLFW_KEY_MINUS,                   // 45 
    PERIOD = GlfwConstants.GLFW_KEY_PERIOD,                 // 46
    SLASH = GlfwConstants.GLFW_KEY_SLASH,                   // 47
    KEY0 = GlfwConstants.GLFW_KEY_0,                        // 48
    KEY1 = GlfwConstants.GLFW_KEY_1,                        // 49
    KEY2 = GlfwConstants.GLFW_KEY_2,                        // 50
    KEY3 = GlfwConstants.GLFW_KEY_3,                        // 51
    KEY4 = GlfwConstants.GLFW_KEY_4,                        // 52
    KEY5 = GlfwConstants.GLFW_KEY_5,                        // 53
    KEY6 = GlfwConstants.GLFW_KEY_6,                        // 54
    KEY7 = GlfwConstants.GLFW_KEY_7,                        // 55
    KEY8 = GlfwConstants.GLFW_KEY_8,                        // 56
    KEY9 = GlfwConstants.GLFW_KEY_9,                        // 57
    SEMICOLON = GlfwConstants.GLFW_KEY_SEMICOLON,           // 59
    EQUAL = GlfwConstants.GLFW_KEY_EQUAL,                   // 61
    A = GlfwConstants.GLFW_KEY_A,                           // 65                  
    B = GlfwConstants.GLFW_KEY_B,                           // 66                  
    C = GlfwConstants.GLFW_KEY_C,                           // 67                  
    D = GlfwConstants.GLFW_KEY_D,                           // 68                  
    E = GlfwConstants.GLFW_KEY_E,                           // 69                  
    F = GlfwConstants.GLFW_KEY_F,                           // 70                  
    G = GlfwConstants.GLFW_KEY_G,                           // 71                  
    H = GlfwConstants.GLFW_KEY_H,                           // 72                  
    I = GlfwConstants.GLFW_KEY_I,                           // 73                  
    J = GlfwConstants.GLFW_KEY_J,                           // 74                  
    K = GlfwConstants.GLFW_KEY_K,                           // 75                  
    L = GlfwConstants.GLFW_KEY_L,                           // 76                  
    M = GlfwConstants.GLFW_KEY_M,                           // 77                  
    N = GlfwConstants.GLFW_KEY_N,                           // 78                  
    O = GlfwConstants.GLFW_KEY_O,                           // 79                  
    P = GlfwConstants.GLFW_KEY_P,                           // 80                  
    Q = GlfwConstants.GLFW_KEY_Q,                           // 81                  
    R = GlfwConstants.GLFW_KEY_R,                           // 82                  
    S = GlfwConstants.GLFW_KEY_S,                           // 83                  
    T = GlfwConstants.GLFW_KEY_T,                           // 84                  
    U = GlfwConstants.GLFW_KEY_U,                           // 85                  
    V = GlfwConstants.GLFW_KEY_V,                           // 86                  
    W = GlfwConstants.GLFW_KEY_W,                           // 87                  
    X = GlfwConstants.GLFW_KEY_X,                           // 88                  
    Y = GlfwConstants.GLFW_KEY_Y,                           // 89                  
    Z = GlfwConstants.GLFW_KEY_Z,                           // 90                  
    LEFT_BRACKET = GlfwConstants.GLFW_KEY_LEFT_BRACKET,     // 91
    BACKSLASH = GlfwConstants.GLFW_KEY_BACKSLASH,           // 92
    RIGHT_BRACKET = GlfwConstants.GLFW_KEY_RIGHT_BRACKET,   // 93
    GRAVE_ACCENT = GlfwConstants.GLFW_KEY_GRAVE_ACCENT,     // 96                                         
    WORLD1 = GlfwConstants.GLFW_KEY_WORLD_1,                // 161                                           
    WORLD2 = GlfwConstants.GLFW_KEY_WORLD_2,                // 162                                           
    ESCAPE = GlfwConstants.GLFW_KEY_ESCAPE,                 // 256                                            
    ENTER = GlfwConstants.GLFW_KEY_ENTER,                   // 257                                             
    TAB = GlfwConstants.GLFW_KEY_TAB,                       // 258                                               
    BACKSPACE = GlfwConstants.GLFW_KEY_BACKSPACE,           // 259                                         
    INSERT = GlfwConstants.GLFW_KEY_INSERT,                 // 260                                            
    DELETE = GlfwConstants.GLFW_KEY_DELETE,                 // 261                                            
    RIGHT = GlfwConstants.GLFW_KEY_RIGHT,                   // 262                                             
    LEFT = GlfwConstants.GLFW_KEY_LEFT,                     // 263                                              
    DOWN = GlfwConstants.GLFW_KEY_DOWN,                     // 264                                              
    UP = GlfwConstants.GLFW_KEY_UP,                         // 265                                                  
    PAGE_UP = GlfwConstants.GLFW_KEY_PAGE_UP,               // 266                                             
    PAGE_DOWN = GlfwConstants.GLFW_KEY_PAGE_DOWN,           // 267                                           
    HOME = GlfwConstants.GLFW_KEY_HOME,                     // 268                                                
    END = GlfwConstants.GLFW_KEY_END,                       // 269                                                 
    CAPS_LOCK = GlfwConstants.GLFW_KEY_CAPS_LOCK,           // 280                                           
    SCROLL_LOCK = GlfwConstants.GLFW_KEY_SCROLL_LOCK,       // 281                                         
    NUM_LOCK = GlfwConstants.GLFW_KEY_NUM_LOCK,             // 282                                            
    PRINT_SCREEN = GlfwConstants.GLFW_KEY_PRINT_SCREEN,     // 283                                        
    PAUSE = GlfwConstants.GLFW_KEY_PAUSE,                   // 284                                               
    F1 = GlfwConstants.GLFW_KEY_F1,                         // 290                                                  
    F2 = GlfwConstants.GLFW_KEY_F2,                         // 291                                                  
    F3 = GlfwConstants.GLFW_KEY_F3,                         // 292                                                  
    F4 = GlfwConstants.GLFW_KEY_F4,                         // 293                                                  
    F5 = GlfwConstants.GLFW_KEY_F5,                         // 294                                                  
    F6 = GlfwConstants.GLFW_KEY_F6,                         // 295                                                  
    F7 = GlfwConstants.GLFW_KEY_F7,                         // 296                                                  
    F8 = GlfwConstants.GLFW_KEY_F8,                         // 297                                                  
    F9 = GlfwConstants.GLFW_KEY_F9,                         // 298                                                  
    F10 = GlfwConstants.GLFW_KEY_F10,                       // 299                                                 
    F11 = GlfwConstants.GLFW_KEY_F11,                       // 300                                                 
    F12 = GlfwConstants.GLFW_KEY_F12,                       // 301                                                 
    F13 = GlfwConstants.GLFW_KEY_F13,                       // 302                                                 
    F14 = GlfwConstants.GLFW_KEY_F14,                       // 303                                                 
    F15 = GlfwConstants.GLFW_KEY_F15,                       // 304                                                 
    F16 = GlfwConstants.GLFW_KEY_F16,                       // 305                                                 
    F17 = GlfwConstants.GLFW_KEY_F17,                       // 306                                                 
    F18 = GlfwConstants.GLFW_KEY_F18,                       // 307                                                 
    F19 = GlfwConstants.GLFW_KEY_F19,                       // 308                                                 
    F20 = GlfwConstants.GLFW_KEY_F20,                       // 309                                                 
    F21 = GlfwConstants.GLFW_KEY_F21,                       // 310                                                 
    F22 = GlfwConstants.GLFW_KEY_F22,                       // 311                                                 
    F23 = GlfwConstants.GLFW_KEY_F23,                       // 312                                                 
    F24 = GlfwConstants.GLFW_KEY_F24,                       // 313                                                 
    F25 = GlfwConstants.GLFW_KEY_F25,                       // 314                                                 
    KEYPAD0 = GlfwConstants.GLFW_KEY_KP_0,                  // 320                                         
    KEYPAD1 = GlfwConstants.GLFW_KEY_KP_1,                  // 321                                         
    KEYPAD2 = GlfwConstants.GLFW_KEY_KP_2,                  // 322                                         
    KEYPAD3 = GlfwConstants.GLFW_KEY_KP_3,                  // 323                                         
    KEYPAD4 = GlfwConstants.GLFW_KEY_KP_4,                  // 324                                         
    KEYPAD5 = GlfwConstants.GLFW_KEY_KP_5,                  // 325                                         
    KEYPAD6 = GlfwConstants.GLFW_KEY_KP_6,                  // 326                                         
    KEYPAD7 = GlfwConstants.GLFW_KEY_KP_7,                  // 327                                         
    KEYPAD8 = GlfwConstants.GLFW_KEY_KP_8,                  // 328                                         
    KEYPAD9 = GlfwConstants.GLFW_KEY_KP_9,                  // 329
    KEYPAD_DECIMAL = GlfwConstants.GLFW_KEY_KP_DECIMAL,     // 330                                          
    KEYPAD_DIVIDE = GlfwConstants.GLFW_KEY_KP_DIVIDE,       // 331                                           
    KEYPAD_MULTIPLY = GlfwConstants.GLFW_KEY_KP_MULTIPLY,   // 332                                         
    KEYPAD_SUBTRACT = GlfwConstants.GLFW_KEY_KP_SUBTRACT,   // 333                                         
    KEYPAD_ADD = GlfwConstants.GLFW_KEY_KP_ADD,             // 334                                              
    KEYPAD_ENTER = GlfwConstants.GLFW_KEY_KP_ENTER,         // 335                                            
    KEYPAD_EQUAL = GlfwConstants.GLFW_KEY_KP_EQUAL,         // 336                                            
    LEFT_SHIFT = GlfwConstants.GLFW_KEY_LEFT_SHIFT,         // 340
    LEFT_CONTROL = GlfwConstants.GLFW_KEY_LEFT_CONTROL,     // 341
    LEFT_ALT = GlfwConstants.GLFW_KEY_LEFT_ALT,             // 342
    LEFT_SUPER = GlfwConstants.GLFW_KEY_LEFT_SUPER,         // 343                                          
    RIGHT_SHIFT = GlfwConstants.GLFW_KEY_RIGHT_SHIFT,       // 344                                         
    RIGHT_CONTROL = GlfwConstants.GLFW_KEY_RIGHT_CONTROL,   // 345                                       
    RIGHT_ALT = GlfwConstants.GLFW_KEY_RIGHT_ALT,           // 346                                           
    RIGHT_SUPER = GlfwConstants.GLFW_KEY_RIGHT_SUPER,       // 347                                         
    MENU = GlfwConstants.GLFW_KEY_MENU,                     // 348
    LAST = GlfwConstants.GLFW_KEY_LAST                      // 348
}
