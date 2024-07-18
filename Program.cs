LinqQueries queries = new LinqQueries();    

PrintValues(queries.AllCollection());

void PrintValues(IEnumerable<Book> booksList)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var book in booksList)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
    }
}