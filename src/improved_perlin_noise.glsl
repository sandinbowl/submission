// Given a 3d position as a seed, compute an even smoother procedural noise
// value. "Improving Noise" [Perlin 2002].
//
// Inputs:
//   st  3D seed
// Values between  -½ and ½ ?
//
// expects: random_direction, improved_smooth_step
float improved_perlin_noise( vec3 st) 
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code 
  //return 0;
  
  	float x = floor(st.x);
	float y = floor(st.y);
	float z = floor(st.z);
	
	vec3 p0 = vec3(x,y,z);
	vec3 p1 = vec3(x,y+1,z);
	vec3 p2 = vec3(x,y,z+1);
	vec3 p3 = vec3(x,y+1,z+1);
	vec3 p4 = vec3(x+1,y,z);
	vec3 p5 = vec3(x+1,y+1,z);
	vec3 p6 = vec3(x+1,y,z+1);
	vec3 p7 = vec3(x+1,y+1,z+1);

	vec3 ss = improved_smooth_step(st-p0);	
	
	vec3 rd0 = random_direction(p0);
	vec3 rd1 = random_direction(p1);
	vec3 rd2 = random_direction(p2);
	vec3 rd3 = random_direction(p3);
	vec3 rd4 = random_direction(p4);
	vec3 rd5 = random_direction(p5);
	vec3 rd6 = random_direction(p6);
	vec3 rd7 = random_direction(p7);
	
	float len0 = dot(st-p0, rd0);
	float len1 = dot(st-p1, rd1);
	float len2 = dot(st-p2, rd2);
	float len3 = dot(st-p3, rd3);
	float len4 = dot(st-p4, rd4);
	float len5 = dot(st-p5, rd5);
	float len6 = dot(st-p6, rd6);
	float len7 = dot(st-p7, rd7);
	
	float temp0 = (len4-len0)*ss.x+len0;
	float temp1 = (len5-len1)*ss.x+len1;
	float temp2 = (len6-len2)*ss.x+len2;
	float temp3 = (len7-len3)*ss.x+len3;
	float temp4 = (temp3-temp2)*ss.y+temp2;
	float temp5 = (temp1-temp0)*ss.y+temp0;
	return (temp4-temp5)*ss.z+temp5;
	
  /////////////////////////////////////////////////////////////////////////////
}

