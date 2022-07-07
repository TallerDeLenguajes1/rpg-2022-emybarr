namespace Juego
{
    public class personaje
    {
        private datos dato;
        private caracteristicas carc ; 
        public datos Dato { get => dato; set => dato = value; }
        public caracteristicas Carc { get => carc; set => carc = value; }

        public  personaje ( datos dato , caracteristicas carc ){
             this.Dato = dato;
             this.Carc = carc;
        }

          
           public void Atacar()
        {
            Random rand = new Random();
            float poderDeDisparo = Carc.Destreza * Carc.Fuerza * Carc.Nivel;
            float efectividadDisparo = (float)rand.Next(1, 100)/10;
            float valorDeAtaque = poderDeDisparo * efectividadDisparo;
            float critChance = rand.Next(1, 4);
            float poderDeDefensa = (float)(Carc.Armadura * Carc.Velocidad);
            float maxDamage = 50000;

            float damage = (((valorDeAtaque * efectividadDisparo) - poderDeDefensa) / maxDamage) * critChance * 100;
            Dato.Salud -= damage;
        }

    public void mejorarPersonaje()
    {
        Carc.Nivel +=1 ;
        Carc.Fuerza += 1;
        Carc.Armadura +=1;
        Dato.Salud = 100;
      }
    }
 }






