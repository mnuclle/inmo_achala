using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Formateadores.MultipartData.Infrastructure;


namespace Servicios
{
    public class FileServicio
    {
        

        public string GuardarFile(HttpFile File)
        {
            string path = "";
            string pathString = @"D:\Repos\ImagenesAchala";
            pathString = System.IO.Path.Combine(pathString, File.FileName);

            
                      
            if (!System.IO.File.Exists(pathString))
            {
                System.IO.File.WriteAllBytes(pathString, File.Buffer);
                path = pathString;
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", pathString);
                return path;
            }
        return path;

    }

        public void EliminarFile(string path)
        {
           ;
        }
    }
}
