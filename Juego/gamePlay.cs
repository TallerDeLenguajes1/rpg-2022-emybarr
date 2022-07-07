namespace Juego
{
    public class gamePlay
    {
            private int prim;
            private int seg;
            private string vencedor;
            

        
        public int Prim { get => prim; set => prim = value; }
        public int Seg { get => seg; set => seg = value; }
        public string Vencedor { get => vencedor; set => vencedor = value; }

        public void Pelea(List<personaje> lista){
        Random rand = new Random();

        while(lista.Count != 1)
            {
                 prim = rand.Next(lista.Count);
                 seg = rand.Next(lista.Count);
            

                for (int i = 1; i < 4; i++)
                {
                    Console.WriteLine($"\t\nPelea {i}");
                    Console.WriteLine( "       " + lista[prim].Dato.Nombre1 + "         VS       " + lista[seg].Dato.Nombre1  );
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    while (prim == seg)
                    {
                        seg = rand.Next(lista.Count);
                    }

                       lista[prim].Atacar();
                       lista[seg].Atacar();
                       Console.WriteLine("Salud : " + lista[prim].Dato.Salud +  "       VS     " + " Salud : " + lista[seg].Dato.Salud);
                    
                }

                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                if ( lista[prim].Dato.Salud <  lista[seg].Dato.Salud)
                {
                    Vencedor = lista[seg].Dato.Nombre1;
                    Console.WriteLine("El ganador es {0}  ", Vencedor);
                    Console.WriteLine($"Tipo: {lista[seg].Dato.Tipo}");
                    Console.WriteLine($"Nivel: {lista[seg].Carc.Nivel}");
                    lista[seg].mejorarPersonaje();
                    lista.RemoveAt(prim);

                }
                else
                {
                    Vencedor = lista[prim].Dato.Nombre1;
                    Console.WriteLine("El ganador es {0}  ", Vencedor);
                    Console.WriteLine($"Tipo: {lista[prim].Dato.Tipo}");
                    Console.WriteLine($"Nivel: {lista[prim].Carc.Nivel}");
                    lista[prim].mejorarPersonaje();
                    lista.RemoveAt(seg);
                }
                }
    }
}
}