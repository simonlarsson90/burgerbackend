using System;
using System.Text.Json.Serialization;


namespace backendproject.Models
{
  public class Bong
  {
      public int Id { get; set; }
      public DateTime created { get; set; }

      public BongDetails BongDetails {get; set; }
  }
}