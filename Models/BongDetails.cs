using System;
using System.Text.Json.Serialization;


namespace backendproject.Models
{
    public class BongDetails
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int IngridientId { get; set; }

        [JsonIgnore]
        public Ingridient Ingridient { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
    }
}