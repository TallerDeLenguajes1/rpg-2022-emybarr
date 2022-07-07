using System.Text.Json;
using System.Text.Json.Serialization;


namespace Juego
{
    public class archivo
    {
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

         public void guardarvencedor(string nombArchivo, personaje vencedor, string formato)
            {
                FileStream Archivo = new FileStream(nombArchivo + formato, FileMode.Create);
                using (StreamWriter strWrite = new StreamWriter(Archivo))
                {
                  
                   var dateAndTime = DateTime.Now;
                   var Date = dateAndTime.ToShortDateString();
                
                    strWrite.WriteLine("<{0};{1};{2}>\n",vencedor.Dato.Nombre1 ,vencedor.Dato.Tipo, Date);
                    strWrite.Close();
                }
            }


    }
}
