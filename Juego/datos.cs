namespace Juego
{
    public class datos
    {
        public enum TipoDePersonaje
        {
            Niñx = 1,
            Psiquiatra,
            Muñeco,
            Payaso,
            Psicopata,
            Asesino,
            Slasher,
            Cuidador


        }

        public enum Nombre
        {
            Annie,
            Alex,
            Norman,
            Jack,
            Benjamin,
            Samara,
            Chucky,
            Hannibal,
            Michael,
            Freddy,
            Jason,
            It
        }

  

        private string nombre;
        private string apodo;
        private DateTime fechaDeNacimiento;
        private int edad;
        private float salud;
        private string tipo;
        private int id; 

        public string Nombre1 { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public int Edad { get => edad; set => edad = value; }

        public string Tipo { get => tipo; set => tipo = value; }
        public int Id { get => id; set => id = value; }
        public float Salud { get => salud; set => salud = value; }

        public int calcularEdad(DateTime FechaDeNacimiento)
        {
            Edad = DateTime.Today.Year - FechaDeNacimiento.Year;

            if (DateTime.Today.Month < FechaDeNacimiento.Month)
            {
                --Edad;                
            }
            else if (DateTime.Today.Month == FechaDeNacimiento.Month && DateTime.Today.Day < FechaDeNacimiento.Day)
            {
                --Edad;
            }

            return Edad;
        }


    
    }
}