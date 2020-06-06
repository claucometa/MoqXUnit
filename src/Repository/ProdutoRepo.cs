using System;
using System.Collections.Generic;

namespace MoqXUnit
{
    public class ProdutoRepo : IProdutoRepo
    {
        public List<Produto> GetAll()
        {
            throw new Exception("");
        }
    }
}
