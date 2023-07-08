﻿#type Vertex
#version 450 core
layout(location = 0) in vec3 POSITION;
layout(location = 1) in vec3 COLOR;
layout(location = 2) in vec2 TEXCOORD;

layout(std140, binding = 0) uniform Camera
{
    mat4 Projection;
    mat4 View;
    vec3 ViewPosition;
};
uniform mat4 _Model = mat4(1.0);

out vec3 v_Color;
out vec2 v_TexCoord;

void main()
{
    gl_Position = Projection * View * _Model * vec4(POSITION, 1.0);
    v_TexCoord = TEXCOORD;
    v_Color = COLOR;
}

#type Fragment
#version 450 core
out vec4 FragColor;

in vec3 v_Color;
in vec2 v_TexCoord;

uniform sampler2D texture1;
uniform sampler2D texture2;

void main()
{
    FragColor = mix(texture(texture1, v_TexCoord), texture(texture2, v_TexCoord), 0.2) * vec4(v_Color, 1.0);
}