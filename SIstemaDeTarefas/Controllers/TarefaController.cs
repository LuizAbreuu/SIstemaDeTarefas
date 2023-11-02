using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIstemaDeTarefas.Models;
using SIstemaDeTarefas.Repositorios;
using SIstemaDeTarefas.Repositorios.interfaces;

namespace SIstemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _TarefaRepositorio;
        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _TarefaRepositorio = tarefaRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> ListarTodas()
        {
            List<TarefaModel> tarefas =  await _TarefaRepositorio.BuscarTodasTarefas();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TarefaModel>>> BuscarPorId(int id)
        {
            TarefaModel tarefa = await _TarefaRepositorio.BuscarPorId(id);
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefa = await _TarefaRepositorio.Adicionar(tarefaModel);
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id = id;
            TarefaModel tarefa = await _TarefaRepositorio.Atualizar(tarefaModel, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            bool apagado = await _TarefaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
