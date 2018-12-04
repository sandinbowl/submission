// Input:
//   N  3D unit normal vector
// Outputs:
//   T  3D unit tangent vector
//   B  3D unit tangent vector
void tangent(in vec3 N, out vec3 T, out vec3 B)
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code 
  T = vec3(1,0,0);
  B = vec3(0,1,0);

  vec3 cross0 = cross(N, T);
  vec3 cross1 = cross(N, B);

  if (length(cross0) < length(cross1))
	  T = cross1;
  else 
	  T = cross0;

  T = normalize(T);
  B = normalize(cross(T, N));
  
  /////////////////////////////////////////////////////////////////////////////
}
