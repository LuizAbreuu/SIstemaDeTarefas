using Microsoft.EntityFrameworkCore;
using SIstemaDeTarefas.Data;
using SIstemaDeTarefas.Models;
using SIstemaDeTarefas.Repositorios.interfaces;

namespace SIstemaDeTarefas.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly SistemasTarefasDBContext _dbContext;
        public TarefaRepositorio(SistemasTarefasDBContext sistemasTarefasDBContext)
        {
            _dbContext = sistemasTarefasDBContext;
        }
        public async Task<TarefaModel> BuscarPorId(int id)
        {

            return await _dbContext.Tarefa.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<List<TarefaModel>> BuscarTodasTarefa()
        {
            return await _dbContext.Tarefa
                .Include (x => x.Usuario)
                .ToListAsync();
        }
        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _dbContext.Tarefa.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();

            return tarefa;
        }
        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            if (tarefaPorId == null) 
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco de dados.");
            }
            tarefaPorId.Nome = tarefa.Nome;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;

            _dbContext.Tarefa.Update(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return tarefaPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Tarefa.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            throw new NotImplementedException();
        }
    }
}
