// Create a bumpy surface by using procedural noise to generate a height (
// displacement in normal direction).
//
// Inputs:
//   is_moon  whether we're looking at the moon or centre planet
//   s  3D position of seed for noise generation
// Returns elevation adjust along normal (values between -0.1 and 0.1 are
//   reasonable.
float bump_height( bool is_moon, vec3 s)
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code 

  float t0 = 3.0;
  float noise;
  if (is_moon) {
  	noise = smooth_heaviside(improved_perlin_noise(s * t0) * 10, 2);
  } else {
  	noise = smooth_heaviside(improved_perlin_noise(s * t0) * 5, 5);
  }
  return noise;
  /////////////////////////////////////////////////////////////////////////////
}
