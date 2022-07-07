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
          archivo archivo = new archivo();
          int opcion, opcionj, prim, seg;
          string vencedor ;
      
           Random rand = new Random();
do{
         do{
            Console.WriteLine("Seleccione Opcion");
            Console.WriteLine("1 - Iniciar un juego");
            Console.WriteLine("2 - Lista de Ganadores");
            Console.WriteLine("3 - Salir");
            opcion= Convert.ToInt32(Console.ReadLine());
         }while(opcion < 1 || opcion > 4);

         if(opcion == 2){
                  Console.WriteLine("hola ");
                }
}while(opcion ==2);

         if(opcion == 1)
         {

            Console.WriteLine("Elija la forma de crear los jugadores ");
            do
            {
            Console.WriteLine(" 1- Crear los 8 jugadores de forma aleatoria ");
             Console.WriteLine("2- Crear cada jugadores de lista ganadores");
            opcionj=  Convert.ToInt32(Console.ReadLine());
            }while(opcionj > 2);
         }
          for(int i = 0; i < 4; i++)
          {
            GrupoA.Add(new personaje( new datos(), new caracteristicas()));
          }

          for(int i = 0; i < 4; i++)
          {
            GrupoB.Add(new personaje( new datos(), new caracteristicas()));
          }

          Console.WriteLine("\n<<<<<<<<< Grupo A <<<<<<<<<<\n");

          

          Console.WriteLine("-------------BATALLAS GRUPO B ------------------");

            while (GrupoA.Count != 1)
            {
                 prim = rand.Next(GrupoA.Count);
                 seg = rand.Next(GrupoA.Count);
            

                for (int i = 1; i < 4; i++)
                {
                    Console.WriteLine($"\t\nPelea {i}");
                    Console.WriteLine( "       " + GrupoA[prim].Dato.Nombre1 + "         VS       " + GrupoA[seg].Dato.Nombre1  );
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    while (prim == seg)
                    {
                        seg = rand.Next(GrupoA.Count);
                    }

                       GrupoA[prim].Atacar();
                       GrupoA[seg].Atacar();
                       Console.WriteLine("Salud : " + GrupoA[prim].Dato.Salud +  "       VS     " + " Salud : " + GrupoA[seg].Dato.Salud);
                    
                }

                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                if ( GrupoA[prim].Dato.Salud <  GrupoA[seg].Dato.Salud)
                {
                    vencedor = GrupoA[seg].Dato.Nombre1;
                    Console.WriteLine("El ganador es {0}  ", vencedor);
                    Console.WriteLine($"Tipo: {GrupoA[seg].Dato.Tipo}");
                    Console.WriteLine($"Nivel: {GrupoA[seg].Carc.Nivel}");
                    GrupoA[seg].mejorarPersonaje();
                    GrupoA.RemoveAt(prim);

                }
                else
                {
                     vencedor = GrupoA[prim].Dato.Nombre1;
                    Console.WriteLine("El ganador es {0}  ", vencedor);
                    Console.WriteLine($"Tipo: {GrupoA[prim].Dato.Tipo}");
                    Console.WriteLine($"Nivel: {GrupoA[prim].Carc.Nivel}");
                    GrupoA[prim].mejorarPersonaje();
                    GrupoA.RemoveAt(seg);
                }
                }

                foreach(personaje per in GrupoA){
                  BatallaFinal.Add(per);
                }

                Console.WriteLine("-------------BATALLAS GRUPO B ------------------");

                 while (GrupoB.Count != 1)
            {
                 prim = rand.Next(GrupoA.Count);
                 seg = rand.Next(GrupoA.Count);
            

                for (int i = 1; i < 4; i++)
                {
                    Console.WriteLine($"\t\nPelea {i}");
                    Console.WriteLine( "       " + GrupoB[prim].Dato.Nombre1 + "         VS       " + GrupoB[seg].Dato.Nombre1  );
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    while (prim == seg)
                    {
                        seg = rand.Next(GrupoB.Count);
                    }

                       GrupoB[prim].Atacar();
                       GrupoB[seg].Atacar();
                       Console.WriteLine("Salud : " + GrupoB[prim].Dato.Salud +  "       VS     " + " Salud : " + GrupoB[seg].Dato.Salud);
                    
                }

                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                if ( GrupoB[prim].Dato.Salud <  GrupoB[seg].Dato.Salud)
                {
                    vencedor = GrupoB[seg].Dato.Nombre1;
                    Console.WriteLine("El ganador es {0}  ", vencedor);
                    Console.WriteLine($"Tipo: {GrupoB[seg].Dato.Tipo}");
                    Console.WriteLine($"Nivel: {GrupoB[seg].Carc.Nivel}");
                    GrupoB[seg].mejorarPersonaje();
                    GrupoB.RemoveAt(prim);

                }
                else
                {
                     vencedor = GrupoB[prim].Dato.Nombre1;
                    Console.WriteLine("El ganador es {0}  ", vencedor);
                    Console.WriteLine($"Tipo: {GrupoB[prim].Dato.Tipo}");
                    Console.WriteLine($"Nivel: {GrupoB[prim].Carc.Nivel}");
                     GrupoB[prim].mejorarPersonaje();
                    GrupoB.RemoveAt(seg);
                }
                }

                foreach(personaje per in GrupoB){
                  BatallaFinal.Add(per);
                }
                
                 Console.WriteLine("------------------BATLLA FINAL---------------------------");

                foreach(personaje p in BatallaFinal){
                   Console.WriteLine($"Nombre: {p.Dato.Nombre1}");
                   Console.WriteLine($"Tipo: {p.Dato.Tipo}");
                   Console.WriteLine($"Nivel: {p.Carc.Nivel}");
                   Console.WriteLine("---------------------------------------------");
                }
                 while (BatallaFinal.Count != 1)
            {
                 prim = rand.Next(BatallaFinal.Count);
                 seg = rand.Next(BatallaFinal.Count);
            

                for (int i = 1; i < 4; i++)
                {
                    Console.WriteLine($"\t\nPelea {i}");
                    Console.WriteLine( "       " + BatallaFinal[prim].Dato.Nombre1 + "         VS       " + BatallaFinal[seg].Dato.Nombre1  );
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    while (prim == seg)
                    {
                        seg = rand.Next(BatallaFinal.Count);
                    }

                       BatallaFinal[prim].Atacar();
                       BatallaFinal[seg].Atacar();
                       Console.WriteLine("Salud : " + BatallaFinal[prim].Dato.Salud +  "       VS     " + " Salud : " + BatallaFinal[seg].Dato.Salud);
                    
                }

                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                if ( BatallaFinal[prim].Dato.Salud <  BatallaFinal[seg].Dato.Salud)
                {
                    vencedor =BatallaFinal[seg].Dato.Nombre1;
                    Console.WriteLine("El ganador es {0}  ", vencedor);
                    Console.WriteLine($"Tipo: {BatallaFinal[seg].Dato.Tipo}");
                    Console.WriteLine($"Nivel: {BatallaFinal[seg].Carc.Nivel}");
                    BatallaFinal[seg].mejorarPersonaje();
                    BatallaFinal.RemoveAt(prim);
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

                }
                else
                {
                    vencedor = BatallaFinal[prim].Dato.Nombre1;
                    Console.WriteLine("El ganador es {0}  ", vencedor);
                    Console.WriteLine($"Tipo: {BatallaFinal[prim].Dato.Tipo}");
                    Console.WriteLine($"Nivel: {BatallaFinal[prim].Carc.Nivel}");
                    BatallaFinal[prim].mejorarPersonaje();
                    BatallaFinal.RemoveAt(seg);
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                }

                   archivo.guardarvencedor("Ganador",BatallaFinal[0], ".csv");
                }
                
    }
    
      }
      
       }


        
