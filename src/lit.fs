// Add (hard code) an orbiting (point or directional) light to the scene. Light
// the scene using the Blinn-Phong Lighting Model.
//
// Uniforms:
uniform mat4 view;
uniform mat4 proj;
uniform float animation_seconds;
uniform bool mercury;
uniform bool venus;
uniform bool earth;
uniform bool mars;
uniform bool jupiter;
uniform bool saturn;
uniform bool uranus;
uniform bool neptune;
// Inputs:
in vec3 sphere_fs_in;
in vec3 normal_fs_in;
in vec4 pos_fs_in; 
in vec4 view_pos_fs_in; 
// Outputs:
out vec3 color;
// expects: PI, blinn_phong
void main()
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code 
  //color = vec3(1,1,1);

  //mat4 m = model(is_moon, animation_seconds) * vec4(sphere_fs_in, 1);
  vec3 ka, kd, ks;

  if (mercury || venus || earth || mars || jupiter || saturn || uranus || neptune) {
  	  ka = vec3(0.2, 0.2, 0.2);
	  kd = vec3(0.5, 0.5, 0.5);
	  ks = vec3(0.1,0.1,0.1);
  } else {
  	  ka = vec3(0.9,0.9,0.1) * 0.7;
	  kd = vec3(1,1,0.1)*0.3;
	  ks = vec3(0.75, 0.75, 0.75);
  }
  if (mercury) {
	kd = vec3(0.5,0.5,0.5);
  } else if (venus) {
  	kd = vec3(1,0.9,0.5);
  } else if (earth) {
  	kd = vec3(0.2,0.2,0.9);
  } else if (mars) {
  	kd = vec3(0.8,0.2,0.2);
  } else if (jupiter) {
  	kd = vec3(0.8,0.5,0.5);
  } else if (saturn) {
  	kd = vec3(0.9,0.8,0.2);
  } else if (uranus) {
  	kd = vec3(0.7,0.7,1);
  } else if (neptune) {
  	kd = vec3(0.4,0.4,0.9);
  }
  float p = 500;

  //mat4 rotation = rotate_about_y(animation_seconds * M_PI / 4);
  float theta = animation_seconds * M_PI / 2;
  //mat4 rotation = mat4(
  //cos(theta), 0, -sin(theta), 0,
	//0, 1, 0, 0,
	//sin(theta), 0, cos(theta), 0,
	//0, 0, 0, 1);
  mat4 rotation = mat4(
  cos(theta), 0, sin(theta), 0,
	0, 1, 0, 0,
	-sin(theta), 0, cos(theta), 0,
	0, 0, 0, 1);
  vec3 v = normalize(view_pos_fs_in.xyz);
  vec3 l = normalize((view * rotation * vec4(0, 1, 0, 0)).xyz);

  color = blinn_phong(ka, kd, ks, p, normal_fs_in, v, l);

  /////////////////////////////////////////////////////////////////////////////
}
