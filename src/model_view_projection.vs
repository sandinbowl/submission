// Determine the perspective projection (do not conduct division) in homogenous
// coordinates. If is_moon is true, then shrink the model by 30%, shift away
// from the origin by 2 units and rotate around the origin at a frequency of 1
// revolution per 4 seconds.
//
// Uniforms:
//                  4x4 view transformation matrix: transforms "world
//                  coordinates" into camera coordinates.
uniform mat4 view;
//                  4x4 perspective projection matrix: transforms
uniform mat4 proj;
//                                number of seconds animation has been running
uniform float animation_seconds;
//                     whether we're rendering the moon or the other object
uniform bool mercury;
uniform bool venus;
uniform bool earth;
uniform bool mars;
uniform bool jupiter;
uniform bool saturn;
uniform bool uranus;
uniform bool neptune;
// Inputs:
//                  3D position of mesh vertex
in vec3 pos_vs_in; 
// Ouputs:
//                   transformed and projected position in homogeneous
//                   coordinates
out vec4 pos_cs_in; 
// expects: PI, model
void main()
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code 
  if (mercury) {
	pos_cs_in = proj * (view * (model(mercury, venus, earth, mars, jupiter, saturn, uranus, neptune, animation_seconds) * uniform_scale(0.1) * vec4(pos_vs_in,1.0)));
  } else if (venus) {
	pos_cs_in = proj * (view * (model(mercury, venus, earth, mars, jupiter, saturn, uranus, neptune, animation_seconds) * uniform_scale(0.15) * vec4(pos_vs_in,1.0)));
  } else if (earth) {
	pos_cs_in = proj * (view * (model(mercury, venus, earth, mars, jupiter, saturn, uranus, neptune, animation_seconds) * uniform_scale(0.2) * vec4(pos_vs_in,1.0)));
  } else if (mars) {
	pos_cs_in = proj * (view * (model(mercury, venus, earth, mars, jupiter, saturn, uranus, neptune, animation_seconds) * uniform_scale(0.2) * vec4(pos_vs_in,1.0)));
  } else if (jupiter) {
	pos_cs_in = proj * (view * (model(mercury, venus, earth, mars, jupiter, saturn, uranus, neptune, animation_seconds) * uniform_scale(0.4) * vec4(pos_vs_in,1.0)));
  } else if (saturn) {
	pos_cs_in = proj * (view * (model(mercury, venus, earth, mars, jupiter, saturn, uranus, neptune, animation_seconds) * uniform_scale(0.4) * vec4(pos_vs_in,1.0)));
  } else if (uranus) {
	pos_cs_in = proj * (view * (model(mercury, venus, earth, mars, jupiter, saturn, uranus, neptune, animation_seconds) * uniform_scale(0.3) * vec4(pos_vs_in,1.0)));
  } else if (neptune) {
	pos_cs_in = proj * (view * (model(mercury, venus, earth, mars, jupiter, saturn, uranus, neptune, animation_seconds) * uniform_scale(0.2) * vec4(pos_vs_in,1.0)));
  }
  else {
	pos_cs_in = proj * (view * (model(mercury, venus, earth, mars, jupiter, saturn, uranus, neptune, animation_seconds) * vec4(pos_vs_in,1.0)));
  }
  /////////////////////////////////////////////////////////////////////////////
}
