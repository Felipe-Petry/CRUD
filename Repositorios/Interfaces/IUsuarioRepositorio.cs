using desafio.models;

namespace desafio.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio  //contratos de usuarios ex: buscar ou remover usuarios
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarporId(int id);
        Task<UsuarioModel> Adicionar(UsuarioModel usuario);
        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);
        Task<bool> Apagar(int id);
        
    }
}
