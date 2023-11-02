using SIstemaDeTarefas.integracao.Response;

namespace SIstemaDeTarefas.integracao.interfaces
{
    public interface IViaCepIntegracao
    {
        Task<ViaCepResponse> ObterDadosViaCep(string cep);
    }
}
