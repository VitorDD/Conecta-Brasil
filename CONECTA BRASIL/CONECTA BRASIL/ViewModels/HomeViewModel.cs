using CONECTA_BRASIL.Models;

namespace CONECTA_BRASIL.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Categoria> Categorias { get; set; }
        public IEnumerable<Publicacao> Publicacoes { get; set; }
    }
}