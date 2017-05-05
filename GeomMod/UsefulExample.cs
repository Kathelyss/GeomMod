using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace GeomMod
{
    class UsefulExample
    {
        // Declared static (no need for object reference
        static float X = 0.0f;        // Translate screen to x direction (left or right)
        static float Y = 0.0f;        // Translate screen to y direction (up or down)
        static float Z = 0.0f;        // Translate screen to z direction (zoom in or out)
        static float rotX = 0.0f;    // Rotate screen on x axis 
        static float rotY = 0.0f;    // Rotate screen on y axis
        static float rotZ = 0.0f;    // Rotate screen on z axis

        static float rotLx = 0.0f;   // Translate screen by using the glulookAt function 
                                     // (left or right)
        static float rotLy = 0.0f;   // Translate screen by using the glulookAt function 
                                     // (up or down)
        static float rotLz = 0.0f;   // Translate screen by using the glulookAt function 
                                     // (zoom in or out)

        static bool lines = true;       // Display x,y,z lines (coordinate lines)
        static bool rotation = false;   // Rotate if F2 is pressed   
        static int old_x, old_y;        // Used for mouse event
        static int mousePressed;

        // DrawScene the lines (x,y,z)
        static void Drawings()
        {
            // Clear the Color Buffer and Depth Buffer
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();   // It is important to push the Matrix before 
                                 // calling glRotatef and glTranslatef
            Gl.glRotatef(rotX, 1.0f, 0.0f, 0.0f);            // Rotate on x
            Gl.glRotatef(rotY, 0.0f, 1.0f, 0.0f);            // Rotate on y
            Gl.glRotatef(rotZ, 0.0f, 0.0f, 1.0f);            // Rotate on z

            if (rotation) // If F2 is pressed update x,y,z for rotation of the cube
            {
                rotX += 0.2f;
                rotY += 0.2f;
                rotZ += 0.2f;
            }

            Gl.glTranslatef(X, Y, Z);        // Translates the screen left or right, 
                                             // up or down or zoom in zoom out

            if (lines)  // If F1 is pressed don't draw the lines
            {
                // DrawScene the positive side of the lines x,y,z
                Gl.glBegin(Gl.GL_LINES);
                Gl.glColor3f(0.0f, 1.0f, 0.0f);                // Green for x axis
                Gl.glVertex3f(0f, 0f, 0f);
                Gl.glVertex3f(10f, 0f, 0f);
                Gl.glColor3f(1.0f, 0.0f, 0.0f);                // Red for y axis
                Gl.glVertex3f(0f, 0f, 0f);
                Gl.glVertex3f(0f, 10f, 0f);
                Gl.glColor3f(0.0f, 0.0f, 1.0f);                // Blue for z axis
                Gl.glVertex3f(0f, 0f, 0f);
                Gl.glVertex3f(0f, 0f, 10f);
                Gl.glEnd();

                // Dotted lines for the negative sides of x,y,z coordinates
                Gl.glEnable(Gl.GL_LINE_STIPPLE); // Enable line stipple to use a 
                                                 // dotted pattern for the lines
                Gl.glLineStipple(1, 0x0101);     // Dotted stipple pattern for the lines
                Gl.glBegin(Gl.GL_LINES);
                Gl.glColor3f(0.0f, 1.0f, 0.0f);                    // Green for x axis
                Gl.glVertex3f(-10f, 0f, 0f);
                Gl.glVertex3f(0f, 0f, 0f);
                Gl.glColor3f(1.0f, 0.0f, 0.0f);                    // Red for y axis
                Gl.glVertex3f(0f, 0f, 0f);
                Gl.glVertex3f(0f, -10f, 0f);
                Gl.glColor3f(0.0f, 0.0f, 1.0f);                    // Blue for z axis
                Gl.glVertex3f(0f, 0f, 0f);
                Gl.glVertex3f(0f, 0f, -10f);
                Gl.glEnd();
            }

            // I start to draw my 3D cube
            Gl.glBegin(Gl.GL_POLYGON);
            // I'm setting a new color for each corner, this creates a rainbow effect
            Gl.glColor3f(0.0f, 0.0f, 1.0f);             // Set color to blue
            Gl.glVertex3f(3.0f, 3.0f, 3.0f);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);             // Set color to red
            Gl.glVertex3f(3.0f, -3.0f, 3.0f);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);             // Set color to green
            Gl.glVertex3f(-3.0f, -3.0f, 3.0f);
            Gl.glColor3f(1.0f, 0.0f, 1.0f);     // Set color to something 
                                                //(right now I don't know which color)
            Gl.glVertex3f(-3.0f, 3.0f, 3.0f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.50f, 0.50f, 1.0f);         // Set a new color
            Gl.glVertex3f(3.0f, 3.0f, -3.0f);
            Gl.glVertex3f(3.0f, -3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, -3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, 3.0f, -3.0f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);         // Set a new color (green)
            Gl.glVertex3f(3.0f, 3.0f, 3.0f);
            Gl.glVertex3f(3.0f, 3.0f, -3.0f);
            Gl.glVertex3f(3.0f, -3.0f, -3.0f);
            Gl.glVertex3f(3.0f, -3.0f, 3.0f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.50f, 1.0f, 0.50f);
            Gl.glVertex3f(-3.0f, 3.0f, 3.0f);
            Gl.glVertex3f(-3.0f, -3.0f, 3.0f);
            Gl.glVertex3f(-3.0f, -3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, 3.0f, -3.0f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glVertex3f(3.0f, 3.0f, 3.0f);
            Gl.glVertex3f(3.0f, 3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, 3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, 3.0f, 3.0f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(1.0f, 0.50f, 0.50f);
            Gl.glVertex3f(3.0f, -3.0f, 3.0f);
            Gl.glVertex3f(3.0f, -3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, -3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, -3.0f, 3.0f);
            Gl.glEnd();

            Gl.glDisable(Gl.GL_LINE_STIPPLE);   // Disable the line stipple
            Glut.glutPostRedisplay();           // Redraw the scene
            Gl.glPopMatrix();                   // Don't forget to pop the Matrix
            Glut.glutSwapBuffers();
        }

        // Initialize the OpenGL window
        static void Init()
        {
            Gl.glShadeModel(Gl.GL_SMOOTH);     // Set the shading model to smooth 
            Gl.glClearColor(0, 0, 0, 0.0f);    // Clear the Color
            // Clear the Color and Depth Buffer
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearDepth(1.0f);          // Set the Depth buffer value (ranges[0,1])
            Gl.glEnable(Gl.GL_DEPTH_TEST);  // Enable Depth test
            Gl.glDepthFunc(Gl.GL_LEQUAL);   // If two objects on the same coordinate 
                                            // show the first drawn
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);
        }

        // This function is called whenever the window size is changed
        static void Reshape(int w, int h)
        {
            Gl.glViewport(0, 0, w, h);                // Set the viewport
            Gl.glMatrixMode(Gl.GL_PROJECTION);        // Set the Matrix mode
            Gl.glLoadIdentity();
            Glu.gluPerspective(75f, (float)w / (float)h, 0.10f, 500.0f);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(rotLx, rotLy, 15.0f + rotLz, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
        }

        // This function is used for the navigation keys
        public static void Keyboard(byte key, int x, int y)
        {
            switch (key)
            {
                // x,X,y,Y,z,Z uses the glRotatef() function
                case 120:    // x             // Rotates screen on x axis 
                    rotX -= 2.0f;
                    break;
                case 88:    // X            // Opposite way 
                    rotX += 2.0f;
                    break;
                case 121:    // y            // Rotates screen on y axis
                    rotY -= 2.0f;
                    break;
                case 89:    // Y            // Opposite way
                    rotY += 2.0f;
                    break;
                case 122:    // z            // Rotates screen on z axis
                    rotZ -= 2.0f;
                    break;
                case 90:    // Z            // Opposite way
                    rotZ += 2.0f;
                    break;

                // j,J,k,K,l,L uses the gluLookAt function for navigation
                case 106:   // j
                    rotLx -= 2.0f;
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(rotLx, rotLy, 15.0 + rotLz,
                        0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
                    break;
                case 74:    // J
                    rotLx += 2.0f;
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(rotLx, rotLy, 15.0 + rotLz,
                        0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
                    break;
                case 107:   // k
                    rotLy -= 2.0f;
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(rotLx, rotLy, 15.0 + rotLz,
                        0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
                    break;
                case 75:    // K
                    rotLy += 2.0f;
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(rotLx, rotLy, 15.0 + rotLz,
                        0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
                    break;
                case 108: // (l) It has a special case when the rotLZ becomes 
                          // less than -15 the screen is viewed from the opposite side
                          // therefore this if statement below does not allow 
                          // rotLz be less than -15
                    if (rotLz + 14 >= 0)
                        rotLz -= 2.0f;
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(rotLx, rotLy, 15.0 + rotLz,
                        0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
                    break;
                case 76:    // L
                    rotLz += 2.0f;
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(rotLx, rotLy, 15.0 + rotLz,
                        0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
                    break;
                case 98:    // b        // Rotates on x axis by -90 degree
                    rotX -= 90.0f;
                    break;
                case 66:    // B        // Rotates on y axis by 90 degree
                    rotX += 90.0f;
                    break;
                case 110:    // n        // Rotates on y axis by -90 degree
                    rotY -= 90.0f;
                    break;
                case 78:    // N        // Rotates on y axis by 90 degree
                    rotY += 90.0f;
                    break;
                case 109:    // m        // Rotates on z axis by -90 degree
                    rotZ -= 90.0f;
                    break;
                case 77:    // M        // Rotates on z axis by 90 degree
                    rotZ += 90.0f;
                    break;
                case 111:    // o        // Resets all parameters
                case 80:    // O        // Displays the cube in the starting position
                    rotation = false;
                    X = Y = 0.0f;
                    Z = 0.0f;
                    rotX = 0.0f;
                    rotY = 0.0f;
                    rotZ = 0.0f;
                    rotLx = 0.0f;
                    rotLy = 0.0f;
                    rotLz = 0.0f;
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(rotLx, rotLy, 15.0f + rotLz,
                        0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
                    break;
            }
            Glut.glutPostRedisplay();    // Redraw the scene
        }

        // Called on special key pressed
        private static void SpecialKey(int key, int x, int y)
        {
            // Check which key is pressed
            switch (key)
            {
                case Glut.GLUT_KEY_LEFT:    // Rotate on x axis
                    X -= 2.0f;
                    break;
                case Glut.GLUT_KEY_RIGHT:    // Rotate on x axis (opposite)
                    X += 2.0f;
                    break;
                case Glut.GLUT_KEY_UP:        // Rotate on y axis 
                    Y += 2.0f;
                    break;
                case Glut.GLUT_KEY_DOWN:    // Rotate on y axis (opposite)
                    Y -= 2.0f;
                    break;
                case Glut.GLUT_KEY_PAGE_UP:  // Rotate on z axis
                    Z -= 2.0f;
                    break;
                case Glut.GLUT_KEY_PAGE_DOWN:// Rotate on z axis (opposite)
                    Z += 2.0f;
                    break;
                case Glut.GLUT_KEY_F1:      // Enable/Disable coordinate lines
                    lines = !lines;
                    break;
                case Glut.GLUT_KEY_F2:      // Enable/Disable automatic rotation
                    rotation = !rotation;
                    break;
                default:
                    break;
            }
            Glut.glutPostRedisplay();        // Redraw the scene
        }

        // Capture the mouse click event 
        static void ProcessMouseActiveMotion(int button, int state, int x, int y)
        {
            mousePressed = button;          // Capture which mouse button is down
            old_x = x;                      // Capture the x value
            old_y = y;                      // Capture the y value
        }

        // Translate the x,y windows coordinates to OpenGL coordinates
        static void ProcessMouse(int x, int y)
        {
            if ((mousePressed == 0))        // If left mouse button is pressed
            {
                X = (x - old_x) / 15;       // I did divide by 15 to adjust                                             
                Y = -(y - old_y) / 15;      // for a nice translation
            }

            Glut.glutPostRedisplay();
        }

        // Get the mouse wheel direction
        static void ProcessMouseWheel(int wheel, int direction, int x, int y)
        {
            Z += direction;                 // Adjust the Z value 
            Glut.glutPostRedisplay();
        }

        // Main Starts
        static void Gain(string[] args)
        {
            Glut.glutInit();        // Initialize glut
            // Setup display mode to double buffer and RGB color
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            // Set the screen size
            Glut.glutInitWindowSize(600, 600);
            Glut.glutCreateWindow("OpenGL 3D Navigation Program With Tao");
            Init();
            Glut.glutReshapeFunc(Reshape);
            Glut.glutDisplayFunc(Drawings);
            // Set window's key callback
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            // Set window's to specialKey callback   
            Glut.glutSpecialFunc(new Glut.SpecialCallback(SpecialKey));
            // Set window's to Mouse callback
            Glut.glutMouseFunc(new Glut.MouseCallback(ProcessMouseActiveMotion));
            // Set window's to motion callback
            Glut.glutMotionFunc(new Glut.MotionCallback(ProcessMouse));
            // Set window's to mouse motion callback
            Glut.glutMouseWheelFunc(new Glut.MouseWheelCallback(ProcessMouseWheel));
            Glut.glutMainLoop();
        }
    }
}