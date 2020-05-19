using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace OpenGL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int RayTracingProgramID;
        int RayTracingVertexShader;
        int RayTracingFragmentShader;
        float reflection = 0.4f;
        int materialType = 2;
        float refraction = 1.5f;
        float transparent = 50.0f;
        float positionX = 0;
        float positionY = 0;
        int tracingDepth = 8;
        Vector3 figuresColor = new Vector3(0, 1, 1);

        private bool InitShaders()
        {
            RayTracingProgramID = GL.CreateProgram();
            List<String> vertexShaderText = new List<string>();
            vertexShaderText.Add("..\\..\\Shaders\\raytracing.vert");
            List<String> fragmentShaderText = new List<string>();
            fragmentShaderText.Add("..\\..\\Shaders\\raytracing.frag");
            loadShader(vertexShaderText, ShaderType.VertexShader, RayTracingProgramID, out RayTracingVertexShader);
            loadShader(fragmentShaderText, ShaderType.FragmentShader, RayTracingProgramID, out RayTracingFragmentShader);
            //Now that the shaders are added, the program needs to be linked.
            //Like C code, the code is first compiled, then linked, so that it goes
            //from human-readable code to the machine language needed.
            GL.LinkProgram(RayTracingProgramID);
            Console.WriteLine(GL.GetProgramInfoLog(RayTracingProgramID));
            GL.Enable(EnableCap.Texture2D);
            return true;
        }

        /// <summary>
        /// This creates a new shader (using a value from the ShaderType enum), loads code for it, compiles it, and adds it to our program.
        /// It also prints any errors it found to the console, which is really nice for when you make a mistake in a shader (it will also yell at you if you use deprecated code).
        /// </summary>
        /// <param name="filename">File to load the shader from</param>
        /// <param name="type">Type of shader to load</param>
        /// <param name="program">ID of the program to use the shader with</param>
        /// <param name="address">Address of the compiled shader</param>
        void loadShader(List<String> filenames, ShaderType type, int program, out int address)
        {

            address = GL.CreateShader(type);
            String shaderText = "";
            for (int i = 0; i < filenames.Count; i++)
            {
                System.IO.StreamReader sr = new StreamReader(filenames[i]);
                shaderText += sr.ReadToEnd();
            }
            GL.ShaderSource(address, shaderText);
            GL.CompileShader(address);
            GL.AttachShader(program, address);
            Console.WriteLine(GL.GetShaderInfoLog(address));
        }

        private static bool Init()
        {
            GL.Enable(EnableCap.ColorMaterial);
            GL.ShadeModel(ShadingModel.Smooth);

            //GL.Enable(EnableCap.Blend);
            //GL.BlendFunc( BlendingFactorSrc.One, BlendingFactorDest.One);

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.CullFace);



            GL.Enable(EnableCap.Lighting);

            GL.LightModel(LightModelParameter.LightModelTwoSide, 1);

            GL.Enable(EnableCap.Light0);

            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            return true;
        }

        private static void Resize(int width, int height)
        {
            if (height == 0)
            {
                height = 1;
            }
            GL.Viewport(0, 0, width, height);
        }

        private void fillTriangleArraysWall(Vector4[] points, Vector4[] indexes)
        {
            // front wall
            points[0].X = -5; points[0].Y = 5; points[0].Z = -8; points[0].W = 0;
            points[1].X = 5; points[1].Y = 5; points[1].Z = -8; points[1].W = 0;
            points[2].X = 5; points[2].Y = -5; points[2].Z = -8; points[2].W = 0;
            points[3].X = -5; points[3].Y = -5; points[3].Z = -8; points[3].W = 0;

            indexes[0].X = 3; indexes[0].Y = 0; indexes[0].Z = 1; indexes[0].W = 4;
            indexes[1].X = 3; indexes[1].Y = 1; indexes[1].Z = 2; indexes[1].W = 4;

            // back wall
            points[4].X = -5; points[4].Y = 5; points[4].Z = 8; points[4].W = 0;
            points[5].X = 5; points[5].Y = 5; points[5].Z = 8; points[5].W = 0;
            points[6].X = 5; points[6].Y = -5; points[6].Z = 8; points[6].W = 0;
            points[7].X = -5; points[7].Y = -5; points[7].Z = 8; points[7].W = 0;

            indexes[2].X = 4; indexes[2].Y = 7; indexes[2].Z = 5; indexes[2].W = 5;
            indexes[3].X = 5; indexes[3].Y = 7; indexes[3].Z = 6; indexes[3].W = 5;

            // right wall
            indexes[4].X = 2; indexes[4].Y = 1; indexes[4].Z = 5; indexes[4].W = 0;
            indexes[5].X = 2; indexes[5].Y = 5; indexes[5].Z = 6; indexes[5].W = 0;

            // left wall
            indexes[6].X = 4; indexes[6].Y = 0; indexes[6].Z = 3; indexes[6].W = 3;
            indexes[7].X = 4; indexes[7].Y = 3; indexes[7].Z = 7; indexes[7].W = 3;

            // bottom wall
            indexes[8].X = 3; indexes[8].Y = 2; indexes[8].Z = 6; indexes[8].W = 4;
            indexes[9].X = 3; indexes[9].Y = 6; indexes[9].Z = 7; indexes[9].W = 4;

            // top wall
            indexes[10].X = 0; indexes[10].Y = 4; indexes[10].Z = 5; indexes[10].W = 4;
            indexes[11].X = 0; indexes[11].Y = 5; indexes[11].Z = 1; indexes[11].W = 4;

            points[8].X = -1; points[8].Y = 0; points[8].Z = 15; points[8].W = 0;
            points[9].X = 0; points[9].Y = 2; points[9].Z = 15; points[9].W = 0;
            points[10].X = 0; points[10].Y = 0; points[10].Z = 15; points[10].W = 0;

            indexes[12].X = 8; indexes[12].Y = 10; indexes[12].Z = 9; indexes[12].W = 6;
        }

        private void setVec4BufferAsImage(Vector4[] array, BufferUsageHint bufferUsageHint, int unit)
        {
            IntPtr ptr = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            int buf = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.TextureBuffer, buf);
            GL.BufferData(BufferTarget.TextureBuffer, (IntPtr)(sizeof(float) * 4 * array.Length), ptr, BufferUsageHint.StaticDraw);

            int tex = GL.GenTexture();
            GL.BindTexture(TextureTarget.TextureBuffer, tex);
            GL.TexBuffer(TextureBufferTarget.TextureBuffer, SizedInternalFormat.Rgba32f, buf);
            GL.BindImageTexture(unit, tex, 0, false, 0, TextureAccess.ReadOnly, SizedInternalFormat.Rgba32f);
        }

        private void initSceneBuffers()
        {
            Vector4[] WallPoints = new Vector4[11];
            Vector4[] WallIndexes = new Vector4[13];

            Vector4[] CubePoints = new Vector4[11];
            Vector4[] CubeIndexes = new Vector4[13];

            Vector4[] TetraPoints = new Vector4[4];
            Vector4[] TetraIndexes = new Vector4[4];

            fillTriangleArraysWall(WallPoints, WallIndexes);
            fillTriangleArraysTetra(TetraPoints, TetraIndexes);
            fillTriangleArraysCube(CubePoints, CubeIndexes);

            Vector4[] spheres = new Vector4[2];

            spheres[0].X = -2; spheres[0].Y = 2; spheres[0].Z = 2; spheres[0].W = 2;
            spheres[1].X = 2; spheres[1].Y = -0.5f; spheres[1].Z = 1; spheres[1].W = 1;

            for (int i = 0; i < CubePoints.Count(); i++) //позиция куба
            {
                CubePoints[i] = CubePoints[i] + new Vector4(2.0f, -1.0f, -2, 0);
            }

            for (int i = 0; i < TetraPoints.Count(); i++)//позиция тетраэдра
            {
                TetraPoints[i] = TetraPoints[i] + new Vector4(-2.0f, -2.0f, -2.0f, 0);
            }

            setVec4BufferAsImage(WallPoints, BufferUsageHint.StaticDraw, 2);
            setVec4BufferAsImage(WallIndexes, BufferUsageHint.StaticDraw, 3);

            setVec4BufferAsImage(spheres, BufferUsageHint.StaticDraw, 4);

            setVec4BufferAsImage(CubePoints, BufferUsageHint.StaticDraw, 5);
            setVec4BufferAsImage(CubeIndexes, BufferUsageHint.StaticDraw, 6);

            setVec4BufferAsImage(TetraPoints, BufferUsageHint.StaticDraw, 1);
            setVec4BufferAsImage(TetraIndexes, BufferUsageHint.StaticDraw, 0);
        }

        private void fillTriangleArraysTetra(Vector4[] points, Vector4[] indexes)
        {
            //bottom
            points[0].X = -2; points[0].Y = 0; points[0].Z = 1; points[0].W = 0;//left dot
            points[1].X = 2; points[1].Y = 0; points[1].Z = 1; points[1].W = 0;//right dot
            points[2].X = 0; points[2].Y = 0; points[2].Z = -1; points[2].W = 0;//front dot

            indexes[0].X = 2; indexes[0].Y = 0; indexes[0].Z = 1; indexes[0].W = 0;//V
            //left
            points[3].X = 0; points[3].Y = 3; points[3].Z = 0; points[3].W = 0;//up dot

            indexes[1].X = 2; indexes[1].Y = 3; indexes[1].Z = 0; indexes[1].W = 0;//
            //right
            indexes[2].X = 2; indexes[2].Y = 1; indexes[2].Z = 3; indexes[2].W = 0;
            //back
            indexes[3].X = 3; indexes[3].Y = 1; indexes[3].Z = 0; indexes[3].W = 0;
        }

        private void fillTriangleArraysCube(Vector4[] points, Vector4[] indexes)
        {
            //front V
            points[0].X = -1; points[0].Y = 1; points[0].Z = -1; points[0].W = 0;
            points[1].X = 1; points[1].Y = 1; points[1].Z = -1; points[1].W = 0;
            points[2].X = 1; points[2].Y = -1; points[2].Z = -1; points[2].W = 0;
            points[3].X = -1; points[3].Y = -1; points[3].Z = -1; points[3].W = 0;

            indexes[0].X = 3; indexes[0].Y = 1; indexes[0].Z = 0; indexes[0].W = 0;
            indexes[1].X = 3; indexes[1].Y = 2; indexes[1].Z = 1; indexes[1].W = 0;
            // back wall V

            points[4].X = -1; points[4].Y = 1; points[4].Z = 1; points[4].W = 0;
            points[5].X = 1; points[5].Y = 1; points[5].Z = 1; points[5].W = 0;
            points[6].X = 1; points[6].Y = -1; points[6].Z = 1; points[6].W = 0;
            points[7].X = -1; points[7].Y = -1; points[7].Z = 1; points[7].W = 0;

            indexes[2].X = 4; indexes[2].Y = 5; indexes[2].Z = 7; indexes[2].W = 0;
            indexes[3].X = 5; indexes[3].Y = 6; indexes[3].Z = 7; indexes[3].W = 0;

            // right wall V

            indexes[4].X = 2; indexes[4].Y = 5; indexes[4].Z = 1; indexes[4].W = 0;
            indexes[5].X = 2; indexes[5].Y = 6; indexes[5].Z = 5; indexes[5].W = 0;

            // left wall V

            indexes[6].X = 4; indexes[6].Y = 3; indexes[6].Z = 0; indexes[6].W = 0;
            indexes[7].X = 4; indexes[7].Y = 7; indexes[7].Z = 3; indexes[7].W = 0;

            // bottom wall V

            indexes[8].X = 2; indexes[8].Y = 3; indexes[8].Z = 6; indexes[8].W = 0;
            indexes[9].X = 6; indexes[9].Y = 3; indexes[9].Z = 7; indexes[9].W = 0;

            // top wall V

            indexes[10].X = 0; indexes[10].Y = 5; indexes[10].Z = 4; indexes[10].W = 0;
            indexes[11].X = 0; indexes[11].Y = 1; indexes[11].Z = 5; indexes[11].W = 0;

            points[8].X = -1; points[8].Y = 0; points[8].Z = -1; points[8].W = 0;
            points[9].X = 0; points[9].Y = 1; points[9].Z = -1; points[9].W = 0;
            points[10].X = 0; points[10].Y = 0; points[10].Z = -1; points[10].W = 0;
        }

        public const int DIFFUSE_REFLECTION = 1;
        public const int MIRROR_REFLECTION = 2;
        public int REFRACTION = 3;

        Material[] fillMaterials()
        {
            Material[] materials = new Material[7];
            Vector4 lightCoefs = new Vector4(0.4f, 0.9f, 0.2f, 2.0f);
            materials[0] = new Material(new Vector3(0, 1, 0), lightCoefs, 0.5f, 1, DIFFUSE_REFLECTION);
            materials[1] = new Material(new Vector3(0, 0, 1), lightCoefs, 0.5f, 1, DIFFUSE_REFLECTION);
            materials[2] = new Material(new Vector3(0, 0.1f, 0.8f), lightCoefs, 0.5f, 1, DIFFUSE_REFLECTION);
            materials[3] = new Material(new Vector3(1, 0, 0), lightCoefs, 0.5f, 1, DIFFUSE_REFLECTION);
            materials[4] = new Material(new Vector3(1, 1, 1), lightCoefs, 0.5f, 1, DIFFUSE_REFLECTION);
            materials[5] = new Material(new Vector3(0, 1, 1), lightCoefs, 0.5f, 1, DIFFUSE_REFLECTION);
            //const vec4 GlassMaterial = vec4 ( 0.1, 0.1, 0.6, 128.0 );
            // const float GlassAirIndex = 4.5;
            // Ratio of refraction indices of glass and air
            // const float AirGlassIndex = 1.0 / GlassAirIndex;
            // Glass
            materials[6] = new Material(figuresColor, new Vector4(0.4f, 0.9f, 0.9f, 50.0f), reflection, refraction, materialType);

            return materials;
        }

        void initMaterials()
        {
            Material[] materials = fillMaterials();
            int location;
            for (int i = 0; i < materials.Length; i++)
            {
                location = GL.GetUniformLocation(RayTracingProgramID, "uMaterials[" + i + "].Color");
                GL.Uniform3(location, materials[i].Color);
                location = GL.GetUniformLocation(RayTracingProgramID, "uMaterials[" + i + "].LightCoeffs");
                GL.Uniform4(location, materials[i].LightCoeffs);
                location = GL.GetUniformLocation(RayTracingProgramID, "uMaterials[" + i + "].ReflectionCoef");
                GL.Uniform1(location, materials[i].ReflectionCoef);
                location = GL.GetUniformLocation(RayTracingProgramID, "uMaterials[" + i + "].RefractionCoef");
                GL.Uniform1(location, materials[i].RefractionCoef);
                location = GL.GetUniformLocation(RayTracingProgramID, "uMaterials[" + i + "].MaterialType");
                GL.Uniform1(location, materials[i].MaterialType);
            }
        }
        private void Draw()
        {
            GL.ClearColor(Color.AliceBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            ;
            GL.UseProgram(RayTracingProgramID);

            initMaterials();
            initSceneBuffers();
            // Camera
            int location = GL.GetUniformLocation(RayTracingProgramID, "uCamera.Position");
            // GL.Uniform3(location, new Vector3(-1, -1, -2));
            GL.Uniform3(location, new Vector3(positionX, positionY, -7.5f));
            location = GL.GetUniformLocation(RayTracingProgramID, "uCamera.Up");
            GL.Uniform3(location, Vector3.UnitY);
            location = GL.GetUniformLocation(RayTracingProgramID, "uCamera.Side");
            GL.Uniform3(location, Vector3.UnitX);
            location = GL.GetUniformLocation(RayTracingProgramID, "uCamera.View");
            GL.Uniform3(location, Vector3.UnitZ);
            location = GL.GetUniformLocation(RayTracingProgramID, "uCamera.Scale");
            GL.Uniform2(location, new Vector2(1, (float)openGlControl.Height / openGlControl.Width));
            // Light
            location = GL.GetUniformLocation(RayTracingProgramID, "uLight.Position");
            GL.Uniform3(location, new Vector3(2.0f, 0.0f, -4.0f));
            location = GL.GetUniformLocation(RayTracingProgramID, "MAX_TRACE_DEPTH");
            GL.Uniform1(location, tracingDepth);
            // Quad
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0, 1);
            GL.Vertex2(-1, -1);

            GL.TexCoord2(1, 1);
            GL.Vertex2(1, -1);

            GL.TexCoord2(1, 0);
            GL.Vertex2(1, 1);

            GL.TexCoord2(0, 0);
            GL.Vertex2(-1, 1);

            GL.End();

            openGlControl.SwapBuffers();
            GL.UseProgram(0);

        }

        private void openGlControl_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }

        private void openGlControl_Load(object sender, EventArgs e)
        {
            Init();
            Resize(openGlControl.Width, openGlControl.Height);
            InitShaders();

            var convReflection = reflection * 10;
            var convRefraction = refraction * 10;
            tbReflection.Value = (int)convReflection;
            tbMaterial.Value = materialType;
            tbRefraction.Value = (int)convRefraction;
            tbTracing.Value = tracingDepth;
            var convPosition = positionX * 10;
            var convPositionY = positionY * 10;
            tbVision.Value = (int)convPosition;
            tbVisionY.Value = (int)convPositionY;
            textMatType();
            btnColor.BackColor = Color.FromArgb((int)figuresColor.X * 255, (int)figuresColor.Y * 255, (int)figuresColor.Z * 255);
        }


        private void openGlControl_Resize(object sender, EventArgs e)
        {
            Resize(openGlControl.Width, openGlControl.Height);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            openGlControl.Width = this.panel2.Width - 24;
            openGlControl.Height = this.panel2.Height - 24;
        }


        private void tbMaterialType_Scroll(object sender, EventArgs e)
        {
            materialType = tbMaterial.Value;
            textMatType();
            openGlControl.Invalidate();
        }

        private void textMatType()
        {
            switch (materialType)
            {
                case 1:
                    lblType.Text = "МАТОВЫЙ";
                    tbRefraction.Enabled = false;
                    tbReflection.Enabled = false;
                    tbTracing.Enabled = false;
                    break;
                case 2:
                    lblType.Text = "ЗЕРКАЛЬНЫЙ";
                    tbReflection.Enabled = true;
                    tbRefraction.Enabled = false;
                    tbTracing.Enabled = true;
                    break;
                case 3:
                    lblType.Text = "СТЕКЛО";
                    tbRefraction.Enabled = true;
                    tbReflection.Enabled = false;
                    tbTracing.Enabled = true;
                    break;
            }
        }

        private void tbReflection_Scroll(object sender, EventArgs e)
        {
            reflection = (float)tbReflection.Value / 10.0f;
            openGlControl.Invalidate();
        }

        private void tbRefraction_Scroll(object sender, EventArgs e)
        {
            refraction = (float)tbRefraction.Value / 10.0f;
            openGlControl.Invalidate();
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = colorDialog1.Color;
                figuresColor = new Vector3(colorDialog1.Color.R / 255.0f, colorDialog1.Color.G / 255.0f, colorDialog1.Color.B / 255.0f);
            }
            openGlControl.Invalidate();
        }

        private void tbVisionX_Scroll(object sender, EventArgs e)
        {
            positionX = (float)tbVision.Value / 10;
            openGlControl.Invalidate();

        }

        private void tbTransparent_Scroll(object sender, EventArgs e)
        {

        }

        private void tbTracing_Scroll(object sender, EventArgs e)
        {
            tracingDepth = tbTracing.Value;
            openGlControl.Invalidate();

        }

        private void tbVisionY_Scroll(object sender, EventArgs e)
        {
            positionY = (float)tbVisionY.Value / 10;
            openGlControl.Invalidate();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    } // class Form

    public struct Material
    {
        //diffuse color
        public Vector3 Color;
        // ambient, diffuse and specular coeffs
        public Vector4 LightCoeffs;
        // 0 - non-reflection, 1 - mirror
        public float ReflectionCoef;
        public float RefractionCoef;

        public int MaterialType;
        public Material(Vector3 color, Vector4 lightCoefs, float reflectionCoef, float refractionCoef, int type)
        {
            Color = color;
            LightCoeffs = lightCoefs;
            ReflectionCoef = reflectionCoef;
            RefractionCoef = refractionCoef;
            MaterialType = type;
        }
    };

}
