// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Text.Json.Serialization;



namespace Juego
{
    class Program
    {
        static void Main(string[] args)
        {
          List<personaje> GrupoA= new List<personaje>();
          List<personaje> GrupoB= new List<personaje>();
          List<personaje> BatallaFinal= new List<personaje>();
          List<personaje> listapersonaje= new List<personaje>();
          archivo archivo = new archivo();
          gamePlay game = new gamePlay();
          int opcion, opcionj;
       
      
           Random rand = new Random();
do{
         do{
            Console.WriteLine("Seleccione Opcion");
            Console.WriteLine("1 - Iniciar un juego");
            Console.WriteLine("2 - Lista de Ganadores");
            Console.WriteLine("3 - Salir");
            opcion= Convert.ToInt32(Console.ReadLine());
         }while(opcion < 1 || opcion > 4);
         
          if(opcion == 1)
         {

            Console.WriteLine("Elija la forma de crear los jugadores ");
            do
            {
            Console.WriteLine(" 1- Crear los 8 jugadores de forma aleatoria ");
             Console.WriteLine("2- Cargar lista jugadores ");
            opcionj=  Convert.ToInt32(Console.ReadLine());
            }while(opcionj > 2);

            for(int i = 0; i < 4; i++)
          {
            GrupoA.Add(new personaje( new datos(), new caracteristicas()));
          }

          for(int i = 0; i < 4; i++)
          {
            GrupoB.Add(new personaje( new datos(), new caracteristicas()));
          }

          if(opcionj == 1)
          {
            Console.WriteLine("\n<<<<<<<<< Jugadores del Grupo A <<<<<<<<<<\n");
            foreach(personaje p in GrupoA){
              Console.WriteLine(p.Dato.Nombre1);
            }
            
            Console.WriteLine("\n<<<<<<<<< Jugadores del Grupo B <<<<<<<<<<\n");
             foreach(personaje p in GrupoB){
              Console.WriteLine(p.Dato.Nombre1);
            }

          

          Console.WriteLine("-------------BATALLAS GRUPO A ------------------");
          game.Pelea(GrupoA);

          Console.WriteLine("-------------BATALLAS GRUPO B ------------------");
          game.Pelea(GrupoB);

          foreach(personaje per in GrupoA){
                  BatallaFinal.Add(per);
          }
           foreach(personaje per in GrupoB){
                  BatallaFinal.Add(per);
          }

          Console.WriteLine("------------------BATLLA FINAL---------------------------");
          game.Pelea(BatallaFinal);
          Console.WriteLine("------------------GANADOR---------------------------");
          foreach(personaje per in BatallaFinal){
                  Console.WriteLine("                 " + per.Dato.Nombre1);
          }
           Console.WriteLine("<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

         archivo.guardarvencedor("Ganador",BatallaFinal[0], ".csv");

         }

          if(opcionj == 2)
          {
           string archivoA = "grupoA.json";
           string grupoAJson =JsonSerializer.Serialize(GrupoA);
           archivo.GuardarArchivo(archivoA,grupoAJson);
           string jsonGrupoA = archivo.AbrirArchivo(archivoA);
           var listaGrupoAJson = JsonSerializer.Deserialize<List<personaje>>(jsonGrupoA);
          Console.WriteLine("\n<<<<<<<<< Jugadores del Grupo A <<<<<<<<<<\n");
           foreach(personaje p in listaGrupoAJson)
           {
            Console.WriteLine(p.Dato.Nombre1);
           }
              
           string archivoB = "grupoB.json";
           string grupoBJson =JsonSerializer.Serialize(GrupoB);
           archivo.GuardarArchivo(archivoB,grupoBJson);
           string jsonGrupoB = archivo.AbrirArchivo(archivoB);
           var listaGrupoBJson = JsonSerializer.Deserialize<List<personaje>>(jsonGrupoB);
           Console.WriteLine("\n<<<<<<<<< Jugadores del Grupo B <<<<<<<<<<\n");
           foreach(personaje p in listaGrupoBJson)
           {
            Console.WriteLine(p.Dato.Nombre1);
           }
           Console.WriteLine("-------------BATALLAS GRUPO A ------------------");
          game.Pelea(GrupoA);

          Console.WriteLine("-------------BATALLAS GRUPO B ------------------");
          game.Pelea(GrupoB);

          foreach(personaje per in GrupoA){
                  BatallaFinal.Add(per);
          }
           foreach(personaje per in GrupoB){
                  BatallaFinal.Add(per);
          }

          Console.WriteLine("------------------BATLLA FINAL---------------------------");
          game.Pelea(BatallaFinal);
          Console.WriteLine("------------------GANADOR---------------------------");
          foreach(personaje per in BatallaFinal){
                  Console.WriteLine("                 " + per.Dato.Nombre1);
          }
           Console.WriteLine("<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

         archivo.guardarvencedor("Ganador",BatallaFinal[0], ".csv");


          }


         if(opcion == 2)
         {
          if (File.Exists("Ganador.csv"))
                        {
                            Console.WriteLine("Mostrar Ganador\n");
                            List<string> lista = new List<string>();
                            string[] listado;
                            lista = File.ReadLines("Ganador.csv").ToList();
                            
                            foreach (string dato in lista)
                            {
                                listado = dato.Split(";");
                                Console.WriteLine($"Nombre: {listado[0]}");
                                Console.WriteLine($"Tipo: {listado[1]}");
                                Console.WriteLine($"Fecha de Batalla: {listado[2]}\n");
                            }

         }
         }
}
    }while(opcion !=3);
        }
}
}