// Set the pixel color using Blinn-Phong shading (e.g., with constant blue and
// gray material color) with a bumpy texture.
// 
// Uniforms:
uniform mat4 view;
uniform mat4 proj;
uniform float animation_seconds;
uniform bool is_moon;
// Inputs:
//                     linearly interpolated from tessellation evaluation shader
//                     output
in vec3 sphere_fs_in;
in vec3 normal_fs_in;
in vec4 pos_fs_in; 
in vec4 view_pos_fs_in; 
// Outputs:
//               rgb color of this pixel
out vec3 color;
// expects: model, blinn_phong, bump_height, bump_position,
// improved_perlin_noise, tangent

vec3 normal_map(vec3 v) {
	vec3 t, b;
	tangent(v, t, b);
	vec3 A, B, C;
	A = bump_position(is_moon, v);
	B = bump_position(is_moon, v-t/10000);
	C = bump_position(is_moon, v-b/10000);
	vec3 AB, AC;
	AB = B-A;
	AC = C-A;
	vec3 n=normalize(cross(AB, AC));
	if (dot(v, n) < 0) 
		n = -n;
	return n;
}

void main()
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code 

  vec3 ka, kd, ks;  
  
  if (is_moon) {
  	  ka = vec3(0.2, 0.2, 0.2);
	  kd = vec3(0.5, 0.5, 0.5);
	  ks = vec3(0.5, 0.5, 0.5);
  } else {
  	  ka = vec3(0.1, 0.1, 0.2);
	  kd = vec3(0.05, 0.25, 0.9);
	  ks = vec3(0.75, 0.75, 0.75);
  }
  float p = 500;

  float theta = animation_seconds * M_PI / 2;
  mat4 rotation = mat4(
  cos(theta), 0, sin(theta), 0,
	0, 1, 0, 0,
	-sin(theta), 0, cos(theta), 0,
	0, 0, 0, 1);
	
  //vec4 temp = inverse(transpose(view * model(is_moon, animation_seconds)));
  vec3 normal = normalize((inverse(transpose(view * model(is_moon, animation_seconds))) * vec4(normal_map(sphere_fs_in), 1.0)).xyz);
  vec3 v = (-view_pos_fs_in).xyz;
  vec3 l = (view * rotation * vec4(1, 1, 0, 0)).xyz;

  color = blinn_phong(ka, kd, ks, p, normal, v, l);
  
  /////////////////////////////////////////////////////////////////////////////
}
