using System;
using System.Collections.Generic;
using System.Text;

namespace Commanda.Models
{
    class CategoryResponse
    {
        public int id_categoria { get; set; }

        public string categoria { get; set; }

        public List<Product> Products { get; set; }
    }
}
