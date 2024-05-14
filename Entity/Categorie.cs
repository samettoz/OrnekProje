using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Categorie : IEntity
    {
        public int Id { get; set; }
        public string CategorieName { get; set; }
    }
}
