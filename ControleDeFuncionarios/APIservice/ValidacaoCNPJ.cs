using Newtonsoft.Json;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Net.Http;

namespace ControleDeFuncionarios.APIservice
{
    public class Root
    {
        [JsonProperty("situacao")]
        public string Situacao { get; set; }

    }
    public class ValidacaoCNPJ
    {
        private readonly HttpClient _httpClient;

        public ValidacaoCNPJ()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> ObterSituacaoCnpj(string cnpj)
        {
            // Fazer a chamada à API ReceitaWS para obter a situação do CNPJ
            string cnpjNumerico = Regex.Replace(cnpj, "[^0-9]", "");
            string url = $"https://www.receitaws.com.br/v1/cnpj/{cnpjNumerico}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(content);
                return data?.Situacao;
            }

            throw new Exception("Erro ao obter a situação do CNPJ.");
        }
    }
}

