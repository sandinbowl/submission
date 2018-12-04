computer graphics final image competition

Luyao Yang     yangluy1     1002087500

I've built a solar system based on csc418 Assignment 6, computer-graphics-shader-pipeline.

I only changed six files. They are the main.cpp, src/model.glsl, src/model_view_projection.vs, src/blue_and_gray.fs, snap_to_sphere.tes and lit.fs. All the othre files remain unchanged.

To run the program. We first need to mkdir a build, cd into build, cmake, make. Then run ./shaderpipeline ../data/test-05.json will provide the result.

There are eight planets rotates around the sun in my solar system. The color of each planet is based on their real color.
The rotation speed of different planets are different, the further, the slower, according to reality.
The size of the planets are different, but the size is not based on the real size, since the real size of each planet comparing to the sun is just too small to be recognized.

My folder is quite big, so I put a github link here.
https://github.com/sandinbowl/submission.git