﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Commanda.Models
{
    class Product
    {
        public int id_producto { get; set; }
        public string descripcion { get; set; }
        public float precio { get; set; }
        public int id_categoria { get; set; }
    }
}
