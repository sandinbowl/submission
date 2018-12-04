// Generate a pseudorandom unit 3D vector
// 
// Inputs:
//   seed  3D seed
// Returns psuedorandom, unit 3D vector drawn from uniform distribution over
// the unit sphere (assuming random2 is uniform over [0,1]²).
//
// expects: random2.glsl, PI.glsl
vec3 random_direction( vec3 seed)
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code 
		
	vec2 angle = random2(seed) * M_PI / 2.0;
  return vec3(sin(angle.x) * cos(angle.y), sin(angle.x) * sin(angle.y), cos(angle.x));
  /////////////////////////////////////////////////////////////////////////////
}
