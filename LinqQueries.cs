using System.Data.SqlTypes;
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

    public bool AllBooksHaveStatus()
    {
        return booksCollection.All(p=>p.Status != string.Empty);
    }

    public bool IfAnyBookWasPublishedIn2005()
    {
        return booksCollection.Any(p=>p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> BooksPython()
    {
        return booksCollection.Where(p=>p.Categories.Contains("Python"));
    }
    
    public IEnumerable<Book> BooksJavaForNameAscending()
    {
        return booksCollection.Where(p=>p.Categories.Contains("Java")).OrderBy(p=>p.Title);
    }
    
    public IEnumerable<Book> BookMore450PagesOrderDescending()
    {
        return booksCollection.Where(p=>p.PageCount>450).OrderByDescending(p=> p.PageCount);
    }

    public IEnumerable<Book> TopThreeBooksOrderByDate()
    {
        return booksCollection
        .Where(p => p.Categories.Contains("Java"))
        .OrderByDescending(p=>p.PublishedDate)
        .Take(3);
    }
    
    public IEnumerable<Book> ThirdAndfourthBooksAndBooksMore400Page()
    {
        return booksCollection
        .Where(p => p.PageCount>400)
        .Take(4)
        .Skip(2); //este omite los 2 primeros item de la lista.
    }

    public IEnumerable<Book> TopThreeBooksColection()
    {
        return booksCollection.Take(3)
                              .Select(p => new Book() { Title = p.Title, PageCount = p.PageCount });
    }
}