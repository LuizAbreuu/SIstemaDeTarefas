using Refit;
using SIstemaDeTarefas.integracao.Response;

namespace SIstemaDeTarefas.integracao.Refit
{
    public interface IViaCepintegracaoRefit
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> ObterDadosViaCep(string cep);
    }
}
