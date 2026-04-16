namespace GestorMotosAPI.Models
{
    public class Moto
    {
        // El 'Id' es como el RUT de la moto, único para cada una.
        public int Id { get; set; }

        // 'string' es texto (como 'str' en Python)
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;

        // 'int' es un número entero (año y kilometraje no tienen decimales)
        public int Año { get; set; }
        public int Kilometraje { get; set; }
    }
}