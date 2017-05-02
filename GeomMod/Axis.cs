using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace GeomMod
{
    class Axis
    {
        static float X = 0.0f;       // Translate screen to x direction (left or right)
        static float Y = 0.0f;       // Translate screen to y direction (up or down)
        static float Z = 0.0f;       // Translate screen to z direction (zoom in or out)
        static float rotX = 0.0f;    // Rotate screen on x axis 
        static float rotY = 0.0f;    // Rotate screen on y axis
        static float rotZ = 0.0f;    // Rotate screen on z axis

        static float rotLx = 0.0f;   // Translate screen by using  the glulookAt
                                     // function (left or right)
        static float rotLy = 0.0f;   // Translate screen by using  the glulookAt
                                     // function (up or down)
        static float rotLz = 0.0f;   // Translate screen by using  the glulookAt
                                     // function (zoom in or out)

        // Initiliaze the OpenGL window
        static void init()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);          // Clear the color 
            Gl.glShadeModel(Gl.GL_FLAT);                     // Set the shading model
                                                             // to GL_FLAT
            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glHint(Gl.GL_LINE_SMOOTH_HINT, Gl.GL_NICEST);  // Set Line Antialiasing
        }

        // Draw the lines (x,y,z)
        static void display()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);             // Clear the Color Buffer 
            Gl.glPushMatrix();                              // It is important to push
                                                            // the Matrix before calling
                                                            // glRotatef and glTranslatef
            Gl.glRotatef(rotX, 1.0f, 0.0f, 0.0f);           // Rotate on x
            Gl.glRotatef(rotY, 0.0f, 1.0f, 0.0f);           // Rotate on y
            Gl.glRotatef(rotZ, 0.0f, 0.0f, 1.0f);           // Rotate on z
            Gl.glTranslatef(X, Y, Z);                       // Translates the screen
                                                            // left or right, up or down
                                                            // or zoom in zoom out

            // Draw the positive side of the lines x,y,z
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

            // Dotted lines for the negative sides of x,y,z
            Gl.glEnable(Gl.GL_LINE_STIPPLE);            // Enable line stipple to
                                                        // use a dotted pattern for
                                                        // the lines
            Gl.glLineStipple(1, 0x0101);                // Dotted stipple pattern for
                                                        // the lines
            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);         // Green for x axis
            Gl.glVertex3f(-10f, 0f, 0f);
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);         // Red for y axis
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(0f, -10f, 0f);
            Gl.glColor3f(0.0f, 0.0f, 1.0f);         // Blue for z axis
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(0f, 0f, -10f);
            Gl.glEnd();

            Gl.glDisable(Gl.GL_LINE_STIPPLE);           // Disable the line stipple
            Gl.glPopMatrix();                           // Don't forget to pop the Matrix
            Glut.glutSwapBuffers();
        }

        // This function is called whenever the window size is changed
        static void reshape(int w, int h)
        {

            Gl.glViewport(0, 0, w, h);                // Set the viewport
            Gl.glMatrixMode(Gl.GL_PROJECTION);         // Set the Matrix mode
            Gl.glLoadIdentity();
            Glu.gluPerspective(75f, (float)w / (float)h, 0.10f, 100.0f);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(rotLx, rotLy, 15.0f + rotLz, 0.0f, 0.0f, 0.0f, 0.0f,
                1.0f, 0.0f);
        }

        // This function is used for the navigation keys
        public static void keyboard(byte key, int x, int y)
        {
            switch (key)
            {

                // x,X,y,Y,z,Z uses the glRotatef() function
                case 120:    // x           // Rotates screen on x axis 
                    rotX -= 0.5f;
                    break;
                case 88:    // X            // Opposite way 
                    rotX += 0.5f;
                    break;
                case 121:    // y           // Rotates screen on y axis
                    rotY -= 0.5f;
                    break;
                case 89:    // Y            // Opposite way
                    rotY += 0.5f;
                    break;
                case 122:    // z           // Rotates screen on z axis
                    rotZ -= 0.5f;
                    break;
                case 90:    // Z            // Opposite way
                    rotZ += 0.5f;
                    break;

                // j,J,k,K,l,L uses the gluLookAt function for navigation
                case 106:   // j
                    rotLx -= 0.2f;
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(rotLx, rotLy, 15.0 + rotLz, 0.0, 0.0, 0.0, 0.0, 1.0,
                        0.0);
                    break;
                case 74:    // J
                    rotLx += 0.2f;
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(rotLx, rotLy, 15.0 + rotLz, 0.0, 0.0, 0.0, 0.0, 1.0,
                        0.0);
                    break;
                case 107:   // k
                    rotLy -= 0.2f;
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(rotLx, rotLy, 15.0 + rotLz, 0.0, 0.0, 0.0, 0.0, 1.0,
                        0.0);
                    break;
                case 75:    // K
                    rotLy += 0.2f;
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(rotLx, rotLy, 15.0 + rotLz, 0.0, 0.0, 0.0, 0.0, 1.0,
                        0.0);
                    break;
                case 108: // (l) It has a special case when the rotLZ becames less
                          // than -15 the screen is viewed from the opposite side
                          // therefore this if statement below does not allow rotLz
                          // be less than -15
                    if (rotLz + 14 >= 0)
                        rotLz -= 0.2f;
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(rotLx, rotLy, 15.0 + rotLz, 0.0, 0.0, 0.0, 0.0, 1.0,
                        0.0);
                    break;
                case 76:    // L
                    rotLz += 0.2f;
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(rotLx, rotLy, 15.0 + rotLz, 0.0, 0.0, 0.0, 0.0,
                        1.0, 0.0);
                    break;
                case 98:    // b        // Rotates on x axis by -90 degree
                    rotX -= 90.0f;
                    break;
                case 66:    // B        // Rotates on y axis by 90 degree
                    rotX += 90.0f;
                    break;
                case 110:    // n       // Rotates on y axis by -90 degree
                    rotY -= 90.0f;
                    break;
                case 78:    // N        // Rotates on y axis by 90 degree
                    rotY += 90.0f;
                    break;
                case 109:    // m       // Rotates on z axis by -90 degree
                    rotZ -= 90.0f;
                    break;
                case 77:    // M        // Rotates on z axis by 90 degree
                    rotZ += 90.0f;
                    break;
                case 111:    // o       // Default, resets the translations vies from
                             // starting view
                case 80:    // O        
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
                    Glu.gluLookAt(rotLx, rotLy, 15.0f + rotLz, 0.0f, 0.0f, 0.0f, 0.0f,
                        1.0f, 0.0f);

                    break;
            }
            Glut.glutPostRedisplay();    // Redraw the scene
        }

        // called on special key pressed
        private static void specialKey(int key, int x, int y)
        {

            // The keys below are using the gluLookAt() function for navigation
            // Check which key is pressed
            switch (key)
            {
                case Glut.GLUT_KEY_LEFT:  // Rotate on x axis
                    X -= 0.1f;
                    break;
                case Glut.GLUT_KEY_RIGHT:    // Rotate on x axis (opposite)
                    X += 0.1f;
                    break;
                case Glut.GLUT_KEY_UP:       // Rotate on y axis 
                    Y += 0.1f;
                    break;
                case Glut.GLUT_KEY_DOWN:     // Rotate on y axis (opposite)
                    Y -= 0.1f;
                    break;
                case Glut.GLUT_KEY_PAGE_UP:  // Roatae on z axis
                    Z -= 0.1f;
                    break;
                case Glut.GLUT_KEY_PAGE_DOWN:// Roatae on z axis (opposite)
                    Z += 0.1f;
                    break;
            }
            Glut.glutPostRedisplay();      // Redraw the scene
        }
        static void Gain(string[] args)
        {
            Glut.glutInit();
            // Setup display mode to double buffer and RGB color
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            // Set the screen size
            Glut.glutInitWindowSize(600, 600);
            Glut.glutCreateWindow("OpenGL 3D Navigation Program With Tao");
            init();
            Glut.glutReshapeFunc(reshape);
            Glut.glutDisplayFunc(display);
            // set window's key callback     
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(keyboard));
            // set window's to specialKey callback
            Glut.glutSpecialFunc(new Glut.SpecialCallback(specialKey));
            Glut.glutMainLoop();
        }
    }
}