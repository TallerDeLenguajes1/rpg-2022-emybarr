namespace Juego
{
    public class caracteristicas
    {
        private int velocidad;
        private int destreza;
        private int fuerza;
        private int nivel;
        private int armadura;

        private int poderDisparo;
        private int poderDefensa; 

        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public int PoderDisparo { get => poderDisparo; set => poderDisparo = value; }
        public int PoderDefensa { get => poderDefensa; set => poderDefensa = value; }


        public caracteristicas()
        {
            Random rand = new Random();
            Armadura=  rand.Next(1, 10);
            Destreza = rand.Next(1, 5);
            Fuerza =  rand.Next(1, 10);
            Nivel =  rand.Next(1, 10);
            Velocidad =  rand.Next(1, 10);
        }



      
    }
}