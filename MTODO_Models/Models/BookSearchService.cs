using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MTODO_Models.Models
{
    public static class BookSearchService
    {
        public async static Task<IEnumerable<Book>> SearchBooksAsync(string searchTerm)
        {
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync($"https://www.googleapis.com/books/v1/volumes?q={searchTerm}");
            var result = JsonConvert.DeserializeObject<BookAPIResult>(json);
            return result.items;
        }
    }
}
