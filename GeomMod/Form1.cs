﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// для работы с библиотекой OpenGL 
using Tao.OpenGl;
// для работы с библиотекой FreeGLUT 
using Tao.FreeGlut;
// для работы с элементом управления SimpleOpenGLControl 
using Tao.Platform.Windows;

namespace GeomMod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            simpleOpenGlControl.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
