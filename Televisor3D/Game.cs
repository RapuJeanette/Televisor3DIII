using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Televisor3D
{
    class Game: GameWindow
    {
        public Escenario escenario;
        public Dictionary<string, Objeto> objeto = new Dictionary<string, Objeto>();
        public Game(int width, int height, string tittle): base(width, height, GraphicsMode.Default, tittle) { }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            GL.Rotate(1.0f, 0.0f, 0.1f, 0.0f);
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.ClearColor(Color4.AliceBlue);
            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-3.0, 3.0, -3.0, 3.0, -3.0, 3.0);
            GL.MatrixMode(MatrixMode.Modelview);

            escenario = new Escenario(new Vector(-100f, -100f, -100f));
            escenario.Adicionar("Televisor", ArchivoJson.Cargar("../../Objetos/tele.json"));
            escenario.Adicionar("Jarron", ArchivoJson.Cargar("../../Objetos/Jarron.json"));
            escenario.Adicionar("Reproductor", ArchivoJson.Cargar("../../Objetos/Reproductor.json"));
            escenario.Dibujar();

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }
        protected override void OnResize(EventArgs e) {  
            GL.Viewport(0,0, Width, Height);
            base.OnResize(e); 
        }


    }
}
