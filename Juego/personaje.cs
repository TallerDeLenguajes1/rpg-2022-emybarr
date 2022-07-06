

namespace Juego
{
    public class personaje
    {
        datos dato = new datos();
        caracteristicas carc = new caracteristicas();
    
        public  personaje crearPersonaje(){
            Random rand = new Random();
            personaje nuevopersonaje = new personaje();
            nuevopersonaje.dato.Salud=100;
            nuevopersonaje.dato.Nombre1= Enum.GetName(typeof(datos.Nombre), rand.Next(1, Enum.GetNames(typeof(datos.Nombre)).Length));
            nuevopersonaje.dato.FechaDeNacimiento =  new DateTime(rand.Next(1500, 2020), rand.Next(1, 12),rand.Next(1, 31));
            nuevopersonaje.dato.Edad= dato.calcularEdad(nuevopersonaje.dato.FechaDeNacimiento);
            nuevopersonaje.dato.Tipo= Enum.GetName(typeof(datos.TipoDePersonaje), rand.Next(1, Enum.GetNames(typeof(datos.TipoDePersonaje)).Length));
            nuevopersonaje.carc.Armadura=  rand.Next(1, 10);
            nuevopersonaje.carc.Destreza = rand.Next(1, 5);
            nuevopersonaje.carc.Fuerza =  rand.Next(1, 10);
            nuevopersonaje.carc.Nivel =  rand.Next(1, 10);
            nuevopersonaje.carc.Velocidad =  rand.Next(1, 10);
            return nuevopersonaje;

        }

        public void MostrarPersonaje()
        {
            Console.WriteLine("\nDatos:");
            Console.WriteLine($"Nombre: {dato.Nombre1}");
            Console.WriteLine($"Fecha de nacimiento: {dato.FechaDeNacimiento}");
            Console.WriteLine($"Edad: {dato.Edad}");
            Console.WriteLine($"Tipo: {dato.Tipo}");
            Console.WriteLine("\nCaracteristicas:");
            Console.WriteLine($"Nivel: {carc.Nivel}");
            Console.WriteLine($"Velocidad: {carc.Velocidad}");
            Console.WriteLine($"Destreza: {carc.Destreza}");
            Console.WriteLine($"Fuerza: {carc.Fuerza}");
            Console.WriteLine($"Armadura: {carc.Armadura}");
            

        }     

         public void MostrarNombre()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"Nombre: {dato.Nombre1}");
            Console.WriteLine($"Nivel: {carc.Nivel}");
            Console.WriteLine($"Tipo: {dato.Tipo}");
            Console.WriteLine("------------------------");
        }
         public void MostrarSalud()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"Nombre: {dato.Nombre1}");
            Console.WriteLine($"Nivel: {carc.Nivel}");
            Console.WriteLine($"Tipo: {dato.Tipo}");
            Console.WriteLine($"Salud: {dato.Salud}");
            Console.WriteLine("------------------------");
        }

        public void mostrarGanador(){
                
             Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
             Console.WriteLine($"Nombre: {dato.Nombre1}");
             Console.WriteLine($"Tipo: {dato.Tipo}");
             Console.WriteLine($"Nivel: {carc.Nivel}");
             Console.WriteLine($"Velocidad: {carc.Velocidad}");
             Console.WriteLine($"Destreza: {carc.Destreza}");
             Console.WriteLine($"Fuerza: {carc.Fuerza}");
             Console.WriteLine($"Armadura: {carc.Armadura}");
             Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");

        }

        public float nsalud(){
            return dato.Salud;
        }

           public string MNombre()
        {
            return dato.Nombre1;
           
        }

          public string tipO()
        {
            return dato.Tipo;
           
        }



        public personaje CrearManualmente(){
            Random rand = new Random();
            personaje nuevopersonaje = new personaje();
            DateTime fechaNac;
            int opcionTipo;

            Console.WriteLine("Ingrese el nombre del personaje");
            nuevopersonaje.dato.Nombre1=Console.ReadLine();
            
            do
            {
            Console.WriteLine("Ingrese su fecha de nacimiento (dd/mm/aaaa):");
            } while (!DateTime.TryParse(Console.ReadLine(), out fechaNac));

            do
            {
                Console.WriteLine("Seleccione un tipo de personaje:\n");
                foreach (string tiposPer in Enum.GetNames(typeof(datos.TipoDePersonaje)))
                {
                    Console.WriteLine($"{(int)Enum.Parse(typeof(datos.TipoDePersonaje),tiposPer)} - {tiposPer}\n");
                }

            } while (!int.TryParse(Console.ReadLine(), out opcionTipo));

            nuevopersonaje.dato.Tipo= Enum.GetName(typeof(datos.TipoDePersonaje),opcionTipo);
            nuevopersonaje.dato.FechaDeNacimiento = fechaNac;
            nuevopersonaje.dato.Edad= dato.calcularEdad(nuevopersonaje.dato.FechaDeNacimiento);
            nuevopersonaje.carc.Armadura=  rand.Next(1, 10);
            nuevopersonaje.carc.Destreza = rand.Next(1, 5);
            nuevopersonaje.carc.Fuerza =  rand.Next(1, 10);
            nuevopersonaje.carc.Nivel =  rand.Next(1, 10);
            nuevopersonaje.carc.Velocidad =  rand.Next(1, 10);

            return nuevopersonaje;


        }

           public void Atacar()
        {
            Random rand = new Random();
            float poderDeDisparo = carc.Destreza * carc.Fuerza * carc.Nivel;
            float efectividadDisparo = (float)rand.Next(1, 100)/10;
            float valorDeAtaque = poderDeDisparo * efectividadDisparo;
            float critChance = rand.Next(1, 4);
            float poderDeDefensa = (float)(carc.Armadura * carc.Velocidad);
            float maxDamage = 50000;

            float damage = (((valorDeAtaque * efectividadDisparo) - poderDeDefensa) / maxDamage) * critChance * 100;

            Console.WriteLine("Danio " + damage);
            dato.Salud -= damage;

            if(dato.Salud < 0){
                dato.Salud = 0;
            }
        }



      public void mejorarPersonaje(){
        carc.Nivel +=1 ;
        carc.Fuerza += 1;
        carc.Armadura +=1;
        dato.Salud = 100;
      }
        }

        
}

    

    

 