// Generate a procedural planet and orbiting moon. Use layers of (improved)
// Perlin noise to generate planetary features such as vegetation, gaseous
// clouds, mountains, valleys, ice caps, rivers, oceans. Don't forget about the
// moon. Use `animation_seconds` in your noise input to create (periodic)
// temporal effects.
//
// Uniforms:
uniform mat4 view;
uniform mat4 proj;
uniform float animation_seconds;
uniform bool is_moon;
// Inputs:
in vec3 sphere_fs_in;
in vec3 normal_fs_in;
in vec4 pos_fs_in; 
in vec4 view_pos_fs_in; 
// Outputs:
out vec3 color;
// expects: model, blinn_phong, bump_height, bump_position,
// improved_perlin_noise, tangent

vec3 normal_map(vec3 v) {
	vec3 t, b;
	tangent(v, t, b);
	vec3 A, B, C;
	A = bump_position(is_moon, v);
	B = bump_position(is_moon, v+t/100000);
	C = bump_position(is_moon, v+b/100000);
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
  //color = vec3(1,1,1);
	
	vec3 ka, kd, ks;
	float p = 30;
	vec3 normal = normal_map(sphere_fs_in);
	float theta = animation_seconds * M_PI / 2;
	mat4 rotation = mat4(
	cos(theta), 0, sin(theta), 0,
	0, 1, 0, 0,
	-sin(theta), 0, cos(theta), 0,
	0, 0, 0, 1);
	
	if (is_moon) {
		ka = vec3(0.02, 0.02, 0.02);
		kd = vec3(0.5, 0.5, 0.5);
		ks = vec3(0., 0., 0.);
	} else {
		float ocean = -1;
		vec3 ocean_color = vec3(0.05, 0.25, 0.9);
		vec3 earth_color = vec3(abs(cos((sphere_fs_in.y/2)*M_PI))*0.4,
			min(max(0.1, abs(sin(sphere_fs_in.y*M_PI))),0.4),
			abs(cos(sphere_fs_in.y*M_PI/2))*0.2
				);
		if (ocean > bump_height(is_moon, sphere_fs_in)){
			ka = vec3(0.1, 0.1, 0.2);
			kd = ocean_color;
			ks = vec3(0.75, 0.75, 0.75);
		} else {
			ka = vec3(0.1, 0.1, 0.1);
			kd = earth_color;
			ks = vec3(0, 0, 0);	
		}
	}
	vec3 v = (-view_pos_fs_in).xyz;
	vec3 l = (view * rotation * vec4(1, 1, 0, 0)).xyz;
	
	color = blinn_phong(ka, kd, ks, p, normal, v, l);
	
	// if you don't like the effect of my cloud, you may comment the below out.
	if (!is_moon) {
		vec3 cloud = vec3(0.9, 0.9, 0.9);
		float latit, longi, sec;
		sec = animation_seconds;
		latit = improved_perlin_noise(sphere_fs_in*vec3(0,1,0)* 0.04* sec+0.5);
		longi = abs(sin(improved_perlin_noise(sphere_fs_in*vec3(1,0,1)*4* sec +0.4)))*50;
		
		float alpha = max(0, latit * longi);
		color = alpha * cloud + (1-alpha) * color;
	}

  /////////////////////////////////////////////////////////////////////////////
}
