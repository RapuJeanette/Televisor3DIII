using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Televisor3D
{
    class ArchivoJson
    {
        public static void Guardar(string path, Objeto objetoPorGuardar)
        {
                string output = JsonConvert.SerializeObject(objetoPorGuardar);
                File.WriteAllText(path, output);
            
        }

        public static Objeto Cargar(string path)
        {

                string output = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<Objeto>(output);
        }
    }
}
