using System.Collections.Generic;

namespace MoqXUnit
{
    public interface IProdutoRepo
    {
        List<Produto> GetAll();
    }
}