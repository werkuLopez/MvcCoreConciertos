﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCoreConciertos.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
    }
}
