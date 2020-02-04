using System;
using System.Collections.Generic;


namespace backendproject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Burger { get; set; }

        public List<BongDetails> bongsDetails { get; set; }
    }
}

