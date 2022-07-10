// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;



namespace Juego
{
    class Program
    {
        static void Main(string[] args)
        {
          List<personaje> GrupoA= new List<personaje>();
          List<personaje> GrupoB= new List<personaje>();
          List<personaje> listapersonaje= new List<personaje>();
          var BatallaFinal= new List<personaje>();
          var ganadores = new List<string>();
          archivo archivo = new archivo();
          gamePlay game = new gamePlay();
          int opcion, opcionj;
          var dateAndTime = DateTime.Now;
          var Date = dateAndTime.ToShortDateString();
       
      
           Random rand = new Random();
              Console.Clear();
            var arr = new[]
            {
                @"___.   .__                                 .__    .___ ",
                @"\_ |__ |__| ____   _______  __ ____   ____ |__| __| _/_",
                @" | __ \|  |/ __ \ /    \  \/ // __ \ /    \|  |/ __ |/  _ \ ",
                @" | \_\ \  \  ___/|   |  \   /\  ___/|   |  \  / /_/ (  <_> )",
                @" |_ __ /__|\___  >___|  /\_/  \___  >___|  /__\____ |\____/",
                @"     \/        \/     \/          \/     \/        \/   ",
            };

            Console.WindowWidth = 120;
            Console.WriteLine("\n\n");
            foreach (string line in arr)
            {
                Console.WriteLine(line);
                Console.ReadKey();
            }
            Thread.Sleep(1000);
do{
  
         do{
          
            Console.WriteLine("Seleccione Opcion");
            Console.WriteLine("1 - Iniciar un juego");
            Console.WriteLine("2 - Ganador anterior");
            Console.WriteLine("3 - Salir");
            opcion= Convert.ToInt32(Console.ReadLine());
         }while(opcion < 1 || opcion > 4);
         
          if(opcion == 1)
         {

            Console.WriteLine("Elija la forma de crear los jugadores ");
            do
            {
              Console.WriteLine(" 1- Crear los jugadores de forma aleatoria ");
              Console.WriteLine(" 2- Cargar lista jugadores  ");
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
          Console.Clear();

          if(opcionj == 1)
          {
            Console.Clear();
           
            Console.WriteLine("\n<<<<<<<<< Jugadores del Grupo A <<<<<<<<<<\n");
             Thread.Sleep(3000);
            foreach(personaje p in GrupoA)
            {
            Console.WriteLine(p.Dato.Nombre1);
            }
            Console.WriteLine("\n<<<<<<<<< Jugadores del Grupo B <<<<<<<<<<\n");
               Thread.Sleep(3000);
            foreach(personaje p in GrupoB)
            {
              Console.WriteLine(p.Dato.Nombre1);
            }
              Thread.Sleep(3000);

          
          Thread.Sleep(1200);
          Console.WriteLine("-------------BATALLAS GRUPO A ------------------");
          game.Pelea(GrupoA);
          Thread.Sleep(1500);
        
          Console.WriteLine("-------------BATALLAS GRUPO B ------------------");
          game.Pelea(GrupoB);
          Thread.Sleep(1300);
          foreach(personaje per in GrupoA){
                  BatallaFinal.Add(per);
          }
           foreach(personaje per in GrupoB){
                  BatallaFinal.Add(per);
          }
          Thread.Sleep(2000);
          
       

          Console.WriteLine("------------------BATLLA FINAL---------------------------");
          game.Pelea(BatallaFinal);
          Console.WriteLine("--------------######GANADOR#######------------------------");
          foreach(personaje per in BatallaFinal){
                  Console.WriteLine("                 " + per.Dato.Nombre1);
                  Console.WriteLine("          "+"BATALLAS GANADAS "+"  " + per.Dato.CantBatallas); 
                 
          }
           Console.WriteLine("<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
           Thread.Sleep(2000);

           

           foreach(var p in BatallaFinal){
            ganadores.Add( p.Dato.Nombre1 + ";" + p.Dato.Tipo + ";"+ Date + ";" + p.Dato.CantBatallas);
           }
           
           archivo.CrearCSV(ganadores);
         

      
         

         }

          if(opcionj == 2)
          {
            Console.Clear();
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

            Thread.Sleep(1200);
           Console.WriteLine("-------------BATALLAS GRUPO A ------------------");
          game.Pelea(GrupoA);
           Thread.Sleep(1200);
          

          Console.WriteLine("-------------BATALLAS GRUPO B ------------------");
          game.Pelea(GrupoB);
           Thread.Sleep(1200);
        


          foreach(personaje per in GrupoA){
                  BatallaFinal.Add(per);
          }
           foreach(personaje per in GrupoB){
                  BatallaFinal.Add(per);
          }
            Thread.Sleep(2000);

          Console.WriteLine("------------------BATLLA FINAL---------------------------");
          game.Pelea(BatallaFinal);
          Console.WriteLine("--------------######GANADOR#######------------------------");
       
          foreach(personaje per in BatallaFinal){
                  Console.WriteLine("                 " + per.Dato.Nombre1); 
                   Console.WriteLine("          "+"BATALLAS GANADAS "+" "  + per.Dato.CantBatallas);       
          }
        
          Console.WriteLine("<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
           Thread.Sleep(2000);

            foreach(var p in BatallaFinal){
            ganadores.Add( p.Dato.Nombre1 + ";" + p.Dato.Tipo + ";"+ Date + ";" + p.Dato.CantBatallas);
           }
           
           archivo.CrearCSV(ganadores);

          }
         }
        
         if(opcion == 2)
         {
          List<string[]> LCsv= archivo.LeerCSV("Ganadores.csv", ';');
          Console.WriteLine("Nombre" + "Tipo" +"Fecha de Combate" + "Cantidad de batllas ");
   for (int i = LCsv.Count() - 1; i >= 0; i--)
    {
        Console.WriteLine(LCsv[i][0] + " - " + LCsv[i][1] + " - " + LCsv[i][2]+ " - " + LCsv[i][3]);
    }
         }
    }while(opcion != 3);
}

                         
                           
         }
         }
                            
         

    


    
    

