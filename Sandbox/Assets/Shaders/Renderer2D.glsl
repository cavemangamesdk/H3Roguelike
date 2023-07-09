#type Vertex
#version 450 core
layout(location = 0) in vec3 POSITION;
layout(location = 1) in vec4 COLOR;
layout(location = 2) in vec2 TEXCOORD;
layout(location = 3) in float TEXTURE;
layout(location = 4) in float TILING_FACTOR;

layout(std140, binding = 0) uniform Camera
{
    mat4 Projection;
    mat4 View;
};

struct VertexOutput
{
	vec4 Color;
	vec2 TexCoord;
	float TilingFactor;
};
layout (location = 0) out VertexOutput Output;
layout (location = 3) out flat float v_Texture;

void main()
{
    Output.Color = COLOR;
    Output.TexCoord = TEXCOORD;
    Output.TilingFactor = TILING_FACTOR;
    v_Texture = TEXTURE;

    gl_Position = Projection * View * vec4(POSITION, 1.0);
}

#type Fragment
#version 450 core
out vec4 FragColor;

struct VertexOutput
{
	vec4 Color;
	vec2 TexCoord;
	float TilingFactor;
};
layout (location = 0) in VertexOutput Input;
layout (location = 3) in flat float v_Texture;

layout (binding = 0) uniform sampler2D u_Textures[32];

void main()
{
    vec4 color = Input.Color;

	switch(int(v_Texture))
	{
		case  0: color *= texture(u_Textures[ 0], Input.TexCoord * Input.TilingFactor); break;
		case  1: color *= texture(u_Textures[ 1], Input.TexCoord * Input.TilingFactor); break;
		case  2: color *= texture(u_Textures[ 2], Input.TexCoord * Input.TilingFactor); break;
		case  3: color *= texture(u_Textures[ 3], Input.TexCoord * Input.TilingFactor); break;
		case  4: color *= texture(u_Textures[ 4], Input.TexCoord * Input.TilingFactor); break;
		case  5: color *= texture(u_Textures[ 5], Input.TexCoord * Input.TilingFactor); break;
		case  6: color *= texture(u_Textures[ 6], Input.TexCoord * Input.TilingFactor); break;
		case  7: color *= texture(u_Textures[ 7], Input.TexCoord * Input.TilingFactor); break;
		case  8: color *= texture(u_Textures[ 8], Input.TexCoord * Input.TilingFactor); break;
		case  9: color *= texture(u_Textures[ 9], Input.TexCoord * Input.TilingFactor); break;
		case 10: color *= texture(u_Textures[10], Input.TexCoord * Input.TilingFactor); break;
		case 11: color *= texture(u_Textures[11], Input.TexCoord * Input.TilingFactor); break;
		case 12: color *= texture(u_Textures[12], Input.TexCoord * Input.TilingFactor); break;
		case 13: color *= texture(u_Textures[13], Input.TexCoord * Input.TilingFactor); break;
		case 14: color *= texture(u_Textures[14], Input.TexCoord * Input.TilingFactor); break;
		case 15: color *= texture(u_Textures[15], Input.TexCoord * Input.TilingFactor); break;
		case 16: color *= texture(u_Textures[16], Input.TexCoord * Input.TilingFactor); break;
		case 17: color *= texture(u_Textures[17], Input.TexCoord * Input.TilingFactor); break;
		case 18: color *= texture(u_Textures[18], Input.TexCoord * Input.TilingFactor); break;
		case 19: color *= texture(u_Textures[19], Input.TexCoord * Input.TilingFactor); break;
		case 20: color *= texture(u_Textures[20], Input.TexCoord * Input.TilingFactor); break;
		case 21: color *= texture(u_Textures[21], Input.TexCoord * Input.TilingFactor); break;
		case 22: color *= texture(u_Textures[22], Input.TexCoord * Input.TilingFactor); break;
		case 23: color *= texture(u_Textures[23], Input.TexCoord * Input.TilingFactor); break;
		case 24: color *= texture(u_Textures[24], Input.TexCoord * Input.TilingFactor); break;
		case 25: color *= texture(u_Textures[25], Input.TexCoord * Input.TilingFactor); break;
		case 26: color *= texture(u_Textures[26], Input.TexCoord * Input.TilingFactor); break;
		case 27: color *= texture(u_Textures[27], Input.TexCoord * Input.TilingFactor); break;
		case 28: color *= texture(u_Textures[28], Input.TexCoord * Input.TilingFactor); break;
		case 29: color *= texture(u_Textures[29], Input.TexCoord * Input.TilingFactor); break;
		case 30: color *= texture(u_Textures[30], Input.TexCoord * Input.TilingFactor); break;
		case 31: color *= texture(u_Textures[31], Input.TexCoord * Input.TilingFactor); break;
	}

    FragColor = color;
}