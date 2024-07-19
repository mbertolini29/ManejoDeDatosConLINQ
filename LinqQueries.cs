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

    public IEnumerable<Book> BooksAfter2000()
    {
        //extension method
        return booksCollection.Where(p => p.PublishedDate.Year > 2000);

        //query expresion
        //return from l in booksCollection where l.PublishedDate.Year > 2000 select l;
    }

    public IEnumerable<Book> BooksWithMore250PagesWithWordsAction()
    {
        return booksCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));       
        //return from l in booksCollection where l.PageCount > 250 && p.Title.Contains("in Action") select l; 
    }
}