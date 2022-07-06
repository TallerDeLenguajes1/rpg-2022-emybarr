// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Text.Json.Serialization;



namespace Juego
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            archivo archivo = new archivo();

            

            int opcion, opcionj, opcionc, opciong; 
            
             string Vencedor;
        
            List<personaje> Grupo= new List<personaje>();
    
            personaje player1 = new personaje();
            personaje player2 = new personaje();
            personaje player3 = new personaje();
            personaje player4 = new personaje();
       

 
        do{
           
         do
         {  
            Console.WriteLine("Seleccione Opcion");
            Console.WriteLine("1 - Iniciar un juego");
            Console.WriteLine("2 - Ranking de Ganadores");
            Console.WriteLine("3 - Salir");
            opcion= Convert.ToInt32(Console.ReadLine());

         }while(opcion < 1 || opcion > 3);

        if(opcion == 2){
                string ruta = @"C:\taller\rpg-2022-emybarr\Juego\";
                List<string[]> ArchivoCsv = archivo.LeerCsv(ruta,"Ganador.csv", ';');
                foreach(string[] filas in ArchivoCsv ){
                    Console.WriteLine(filas[0]);

                }

        }

         if(opcion == 1){

            Console.WriteLine("Elija la forma de crear los jugadores ");
            do
            {
            Console.WriteLine(" 1- Crear los 8 jugadores de forma aleatoria ");
            Console.WriteLine(" 2- Crear cada jugadores ya sea en de forma manual o aleatoria ");
             Console.WriteLine("3- Crear cada jugadores de lista ganadores");
            opcionj=  Convert.ToInt32(Console.ReadLine());
            }while(opcionj > 3);

            if(opcionj == 1)
            {
                Console.WriteLine("Se crearan 4 jugadores ");
                player1 =player1.crearPersonaje();
                player2 =player2.crearPersonaje();
                player3 =player3.crearPersonaje();
                player4 =player4.crearPersonaje();
               
                Grupo.Add(player1);
                Grupo.Add(player3);
                Grupo.Add(player2);
                Grupo.Add(player4);
               

                Console.WriteLine("Grupo");
                foreach (personaje per in Grupo)
            {
               per.MostrarNombre();
            }
            }

            if(opcionj == 2){
                Console.WriteLine("Debera crear 4 personajes puede elegir por cada personaje si lo crea manual o aleatoriamente ");
                do{
                Console.WriteLine("Primer player ");
                Console.WriteLine("1-Manualmente  2-Aleatoriamente");
                 opcionc=  Convert.ToInt32(Console.ReadLine());
                }while(opcionc > 3);

                if(opcionc == 1)
                {
                 player1 =player1.CrearManualmente();
                 Grupo.Add(player1);
                }else{
                 player1 =player1.crearPersonaje();
                  Grupo.Add(player1);
                }
                
                //////////////////////////////////
                do{
                Console.WriteLine("Segundo player ");
                Console.WriteLine("1-Manualmente  2-Aleatoriamente");
                 opcionc=  Convert.ToInt32(Console.ReadLine());
                }while(opcionc > 3);

                if(opcionc == 1)
                {
                 player2 =player2.CrearManualmente();
                  Grupo.Add(player2);
                }else{
                 player2 =player2.crearPersonaje();
                  Grupo.Add(player2);
                }
               
                ///////////////////////////////////
                do{
                Console.WriteLine("Tercer player ");
                Console.WriteLine("1-Manualmente  2-Aleatoriamente");
                opcionc=  Convert.ToInt32(Console.ReadLine());
                }while(opcionc > 3);

                if(opcionc == 1)
                {
                 player3 =player3.CrearManualmente();
                  Grupo.Add(player3);
                }else{
                 player3 =player3.crearPersonaje();
                  Grupo.Add(player3);
                }
              
                ///////////////////////////////////
                do{
                Console.WriteLine("Cuarto player ");
                Console.WriteLine("1-Manualmente  2-Aleatoriamente");
                 opcionc=  Convert.ToInt32(Console.ReadLine());
                }while(opcionc > 3);

                if(opcionc == 1)
                {
                 player4 =player4.CrearManualmente();
                 Grupo.Add(player4);
                }else{
                 player4 =player4.crearPersonaje();
                 Grupo.Add(player4);
                }

                  Console.WriteLine("Grupo");
                foreach (personaje per in Grupo)
            {
               per.MostrarNombre();
            }
            }
            ///////////////////////////////

            while (Grupo.Count != 1)
            {
                int prim = rand.Next(Grupo.Count);
                int seg = rand.Next(Grupo.Count);
            

                for (int i = 1; i < 3; i++)
                {
                    Console.WriteLine($"\t\nPelea {i}");
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    while (prim == seg)
                    {
                        seg = rand.Next(Grupo.Count);
                    }
                    
                    Grupo[prim].Atacar();
                    Grupo[seg].Atacar();
                    Grupo[prim].MostrarSalud();
                    Grupo[seg].MostrarSalud();

                }
                 
                Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                if ( Grupo[prim].nsalud()<  Grupo[seg].nsalud())
                {
                    Vencedor = Grupo[seg].MNombre();
                    Console.WriteLine("El ganador es {0}  ", Vencedor);
                    Grupo[seg].mejorarPersonaje();
                    Grupo[seg].mostrarGanador();
                    Grupo.RemoveAt(prim);

                }
                else
                {
                    Vencedor = Grupo[prim].MNombre();
                    Console.WriteLine("El ganador es {0}  ", Vencedor);
                    Grupo[prim].mejorarPersonaje();
                    Grupo[prim].mostrarGanador();
                    Grupo.RemoveAt(seg);
                }
                string n ;

        
              
                archivo.guardarvencedor("Ganador",Grupo[0], ".csv");
                string json = "jugadores.json";
                string jugadoresJson =JsonSerializer.Serialize(Grupo);
                archivo.GuardarArchivo( json, jugadoresJson );

              
            }
              
            }
         

    }while (opcion != 3);
     
}
} 
}
