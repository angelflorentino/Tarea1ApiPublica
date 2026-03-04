
using Tarea1ApiPublica.Entities;
namespace Tarea1ApiPublica.AppServices
{
    public class CartasService
    {

        private readonly HttpClient _httpClient;
        private string _deckId;

        public CartasService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://deckofcardsapi.com/api/");
        }

        public async Task<string> GetBarajaAsync()
        {

            var response = await _httpClient.GetFromJsonAsync<DeckResponse>("deck/new/shuffle/?deck_count=1");
                
            if (response != null)
            {
                _deckId = response.deck_id;
                Console.WriteLine($"Id obtenido: {_deckId}");
                return _deckId;
            }
            Console.WriteLine($"Id obtenido: {_deckId}");
            return null;


        }

        public async Task<List<Carta>> GetCartaAsync(int cantidad)
        {

            await GetBarajaAsync();

            if (string.IsNullOrEmpty(_deckId)) return new List<Carta>();

            var response = await _httpClient.GetFromJsonAsync<CardResponse>($"deck/{_deckId}/draw/?count={cantidad}");


            if (response != null) return response?.Cartas ?? new List<Carta>();

            return new List<Carta>();

        }

    }
}
