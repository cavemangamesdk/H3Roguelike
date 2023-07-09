#type Vertex
#version 450 core
layout(location = 0) in vec3 POSITION;
layout(location = 1) in vec4 COLOR;

layout(std140, binding = 0) uniform Camera
{
    mat4 Projection;
    mat4 View;
};

out vec4 v_Color;

void main()
{
    gl_Position = Projection * View * vec4(POSITION, 1.0);
    v_Color = COLOR;
}

#type Fragment
#version 450 core
out vec4 FragColor;

in vec4 v_Color;

void main()
{
    FragColor = v_Color;
}