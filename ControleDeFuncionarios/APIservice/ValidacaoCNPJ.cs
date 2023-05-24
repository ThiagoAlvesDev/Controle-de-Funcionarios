using System.Text.Json;


namespace ControleDeFuncionarios.APIservice
{
    public class ValidacaoCNPJ
    {
        private readonly HttpClient _httpClient;

        public ValidacaoCNPJ(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ValidateCnpjAsync(string cnpj)
        {
            // Remover caracteres não numéricos do CNPJ
            //string cnpjCleaned = new string(cnpj.Where(char.IsDigit).ToArray());

            // Fazer a chamada à API da Receita Federal
            string url = $"https://receitaws.com.br/v1/cnpj/{cnpj}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ResponseCnpjApi>(json);

                // Verificar se o CNPJ existe
                return result?.Status == true;
            }

            // A chamada à API falhou
            return false;
        }
    }
}
