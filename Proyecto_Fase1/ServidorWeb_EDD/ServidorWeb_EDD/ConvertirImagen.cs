using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace ServidorWeb_EDD
{
    public class ConvertirImagen
    {
        byte[] arregloBytes;
        public byte[] convertirImagenBytes(string ruta)
        {            
            arregloBytes = File.ReadAllBytes(ruta);
            return arregloBytes;
        }
    }
}