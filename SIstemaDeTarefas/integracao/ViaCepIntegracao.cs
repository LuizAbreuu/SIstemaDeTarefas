using SIstemaDeTarefas.integracao.interfaces;
using SIstemaDeTarefas.integracao.Refit;
using SIstemaDeTarefas.integracao.Response;

namespace SIstemaDeTarefas.integracao
{
    public class ViaCepIntegracao : IViaCepIntegracao
    {
        private readonly IViaCepintegracaoRefit _viaCepintegracaoRefit;

        public ViaCepIntegracao(IViaCepintegracaoRefit viaCepintegracaoRefit)
        {
            _viaCepintegracaoRefit = viaCepintegracaoRefit;
        }
        public async Task<ViaCepResponse> ObterDadosViaCep(string cep)
        {
            var responseData = await _viaCepintegracaoRefit.ObterDadosViaCep(cep);

            if (responseData != null && responseData.IsSuccessStatusCode) 
            {
                return responseData.Content;
            }

            return null;
        }
    }
}
