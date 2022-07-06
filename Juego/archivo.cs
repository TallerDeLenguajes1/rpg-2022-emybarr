using System.Text.Json;
using System.Text.Json.Serialization;


namespace Juego
{
    public class archivo
    {
        personaje per = new personaje();
     
        public string AbrirArchivo(string nombreArchivo)
        {
            string documento;
              using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    documento = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
            }

            return documento;
        }

    
     public void guardarvencedor(string nombArchivo, personaje vencedor, string formato)
            {
                FileStream Archivo = new FileStream(nombArchivo + formato, FileMode.Create);
                using (StreamWriter strWrite = new StreamWriter(Archivo))
                {
                   string nombre = vencedor.MNombre();
                   string tipo =  vencedor.tipO(); 
                   var dateAndTime = DateTime.Now;
                   var Date = dateAndTime.ToShortDateString();
                
                    strWrite.WriteLine("<{0};{1};{2}>\n",nombre ,tipo, Date);
                    strWrite.Close();
                }
            }

     public static List<string[]> LeerCsv(string rutaDeArchivo, string nombre , char caracter)
        {
            FileStream MiArchivo = new FileStream(rutaDeArchivo + nombre, FileMode.Open);
            StreamReader StrReader = new StreamReader(MiArchivo);

            string Linea = "";
            List<string[]> LecturaDelArchivo = new List<string[]>();

            while ((Linea = StrReader.ReadLine()) != null)
            {
                string[] Fila = Linea.Split(caracter);
                LecturaDelArchivo.Add(Fila);
            }

            return LecturaDelArchivo;
        }

         public void GuardarArchivo(string nombreArchivo, string datos)
        {
             using(var archivo = new FileStream(nombreArchivo, FileMode.Create))
            {
                using (var strWriter = new StreamWriter(archivo))
                {
                    strWriter.WriteLine("{0}", datos);
                    strWriter.Close();
                }
    }
}
           
      }

    }

