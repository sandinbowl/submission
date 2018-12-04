// Set the pixel color to blue or gray depending on is_moon.
//
// Uniforms:
uniform bool mercury;
uniform bool venus;
uniform bool earth;
uniform bool mars;
uniform bool jupiter;
uniform bool saturn;
uniform bool uranus;
uniform bool neptune;
// Outputs:
out vec3 color;
void main()
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code:
  if (mercury) {
	color = vec3(0.5,0.5,0.5);
  } else if (venus) {
  	color = vec3(1,0.9,0.5);
  } else if (earth) {
  	color = vec3(0.2,0.2,0.9);
  } else if (mars) {
  	color = vec3(0.8,0.2,0.2);
  } else if (jupiter) {
  	color = vec3(0.8,0.5,0.5);
  } else if (saturn) {
  	color = vec3(0.9,0.8,0.2);
  } else if (uranus) {
  	color = vec3(0.7,0.7,1);
  } else if (neptune) {
  	color = vec3(0.4,0.4,0.9);
  }
  else {
	color = vec3(1,1,0.9);
  }
  /////////////////////////////////////////////////////////////////////////////
}
