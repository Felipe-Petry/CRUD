using desafio.Data;                           //async, precisa aguardar requiquisicao 
using desafio.models;
using desafio.Repositorios.Interfaces;           // MÉTODOS
using Microsoft.EntityFrameworkCore;

namespace desafio.Repositorios;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly SistemasTarefasDBContex _dbContext;

    public object usuarioPorId { get; private set; }

    public UsuarioRepositorio(SistemasTarefasDBContex sistemasTarefasDBContex)
    {
        _dbContext = sistemasTarefasDBContex;   
    }
    public async Task <UsuarioModel> BuscarporId(int id)

    {
        return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<List<UsuarioModel>> BuscarTodosUsuarios() 
    {
        return await _dbContext.Usuarios.ToListAsync();
    }
    public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
    {
       await _dbContext.Usuarios.AddAsync(usuario);
       await _dbContext .SaveChangesAsync();
        return usuario;

    }
    public async Task<UsuarioModel> Atualizar (UsuarioModel usuario, int id)
    {
        UsuarioModel UsuarioPorId = await BuscarporId(id);
        if (UsuarioPorId == null)
        {
            throw new Exception($"usuario para o Id:{id} não foi encontrado");
        }

       UsuarioPorId.Nome = usuario .Nome;
        UsuarioPorId.Email = usuario.Email;

        _dbContext.Usuarios.Update(UsuarioPorId);    
        await _dbContext .SaveChangesAsync();  
        return UsuarioPorId;
    }
    
    public async Task<bool> Apagar(int id)
    {
        UsuarioModel UsuarioPorId = await BuscarporId(id);
        if ( UsuarioPorId == null)   
        {
            throw new Exception($"usuario para o Id:{id} não foi encontrado");            
        }

        
        _dbContext.Usuarios.Remove(UsuarioPorId);
        _dbContext.SaveChangesAsync();
        return true;

    }
}
