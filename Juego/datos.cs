
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Juego
{
    public class datos
    {
        public enum TipoDePersonaje
        {
            Niñx = 1,
            Psiquiatra,
            Munieco,
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
        private List<fruta> fruta;

        private int cantBatallas;

      


       

        public string Nombre1 { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public int Edad { get => edad; set => edad = value; }

        public string Tipo { get => tipo; set => tipo = value; }
       
        public float Salud { get => salud; set => salud = value; }
        public List<fruta> Fruta { get => fruta; set => fruta = value; }
        public int CantBatallas { get => cantBatallas; set => cantBatallas = value; }

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


         public datos(){
            
            Random rand = new Random();
            Salud=100;
            Nombre1= Enum.GetName(typeof(datos.Nombre), rand.Next(1, Enum.GetNames(typeof(datos.Nombre)).Length));
            FechaDeNacimiento =  new DateTime(rand.Next(1500, 2020), rand.Next(1, 12),rand.Next(1, 31));
            Edad= calcularEdad(FechaDeNacimiento);
            Tipo= Enum.GetName(typeof(datos.TipoDePersonaje), rand.Next(1, Enum.GetNames(typeof(datos.TipoDePersonaje)).Length));
            CantBatallas = 0;
            Fruta = Getfruta();
           

         }
          private static List<fruta> Getfruta(){

            var url = $"https://www.fruityvice.com/api/fruit/all";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";



            try {
                using (WebResponse response = request.GetResponse()) {
                    using (Stream strReader = response.GetResponseStream()) {
                        using (StreamReader objReader = new StreamReader(strReader)) {
                            string responseBody = objReader.ReadToEnd();

                            List<fruta>frutas = JsonSerializer.Deserialize<List<fruta>>(responseBody);
                            var rand = new Random();
                            int index = rand.Next(frutas.Count);
                            Console.WriteLine( "La fruta favorita es " + frutas[index].Name);
                           
                        }
                    }
                }
            } catch (WebException ex) {
                Console.WriteLine("error");
            }
            return null;
        }

}
}