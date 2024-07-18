using System.Net.Http.Headers;
using System.Reflection;

public class LinqQueries
{
    private List<Book> booksCollection = new List<Book>();
    
    public LinqQueries ()
    {
        using(StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd(); //lee el archivo total
            this.booksCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        }
    }

    public IEnumerable<Book> AllCollection()
    {
        return booksCollection;
    }
}