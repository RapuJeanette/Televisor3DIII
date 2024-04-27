using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Televisor3D
{
    class Cara
    {
        public Dictionary<string, Vector> listaVertices;
        public Color Color;
        public Vector Centro;
        public Vector vectorT = new Vector(0f, 0f, 0f);

        public Cara(Dictionary<string, Vector> lisVertices, Color color, Vector centro)
        {
            this.listaVertices = lisVertices;
            this.Color = color;
            this.Centro = centro;
        }

        public void Adicionar(string key, Vector verticeAdicionar)
        {
            listaVertices.Add(key, verticeAdicionar);
        }

        public void Eliminar(string key, Vector verticeEliminar)
        {
            listaVertices.Remove(key);
        }

        public void SetCentro(Vector centro)
        {
            this.Centro = centro;
        }

        public Vector GetCentro()
        {
            return Centro;
        }
        //virtual porque podemos personalizarlo o cambiar el comportamiento
        public void Dibujar() 
        {
            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(Color);
            //va iterando sobre cada vertice en nuestra lista de vertices
            foreach (var vertice in listaVertices) 
            {
                // Añadimos el punto al vértice y lo dibujamos
                GL.Vertex3(vertice.Value.X + Centro.X, vertice.Value.Y + Centro.Y, vertice.Value.Z + Centro.Z);
            }
            GL.End();
        }

    }
}
