// Construct the model transformation matrix. The moon should orbit around the
// origin. The other object should stay still.
//
// Inputs:
//   is_moon  whether we're considering the moon
//   time  seconds on animation clock
// Returns affine model transformation as 4x4 matrix
//
// expects: identity, rotate_about_y, translate, PI
mat4 model(bool mercury, bool venus, bool earth, bool mars, bool jupiter, bool saturn, bool uranus, bool neptune, float time)
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code 
	if (mercury) {
		mat4 rotation = rotate_about_y(M_PI / 0.5 * time);
		mat4 translation = translate(vec3(2, 0, 0));
		return rotation * translation;
	} else if (venus) {
		mat4 rotation = rotate_about_y(M_PI / 1 * time);
		mat4 translation = translate(vec3(4, 0, 0));
		return rotation * translation;
	} else if (earth) {
		mat4 rotation = rotate_about_y(M_PI / 1.5 * time);
		mat4 translation = translate(vec3(7, 0, 0));
		return rotation * translation;
	} else if (mars) {
		mat4 rotation = rotate_about_y(M_PI / 2.5 * time);
		mat4 translation = translate(vec3(10, 0, 0));
		return rotation * translation;
	} else if (jupiter) {
		mat4 rotation = rotate_about_y(M_PI / 3.5 * time);
		mat4 translation = translate(vec3(14, 0, 0));
		return rotation * translation;
	} else if (saturn) {
		mat4 rotation = rotate_about_y(M_PI / 4 * time);
		mat4 translation = translate(vec3(20, 0, 0));
		return rotation * translation;
	} else if (uranus) {
		mat4 rotation = rotate_about_y(M_PI / 5 * time);
		mat4 translation = translate(vec3(30, 0, 0));
		return rotation * translation;
	} else if (neptune) {
		mat4 rotation = rotate_about_y(M_PI / 7 * time);
		mat4 translation = translate(vec3(40, 0, 0));
		return rotation * translation;
	}
	return identity();
  /////////////////////////////////////////////////////////////////////////////
}
