using desafio.models;
using desafio.Repositorios;
using desafio.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace desafio.Controllers
{
    [Route("api/[controller]")]           //para buscar os usuarios
    [ApiController]
    public class UsuarioControler : ControllerBase
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioControler(IUsuarioRepositorio usuarioRepositorio) 
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            
            List<UsuarioModel> usuario =   await _usuarioRepositorio.BuscarTodosUsuarios(); 
            
            //         TESTE
            //List<UsuarioModel> usuario = new List<UsuarioModel>();
            //UsuarioModel usuarioModel= new UsuarioModel();
            //usuarioModel.Nome= "felipe"; 
            //usuario.Add(usuarioModel);
           
            return Ok(usuario);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarporID(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarporId(id);
           
            return Ok(usuario);
        }   
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }
            
    }
}