LinqQueries queries = new LinqQueries();    

//toda la coleccion
//PrintValues(queries.AllCollection());

//libros desp del 2000.
//PrintValues(queries.BooksAfter2000());

//libros que tienen mas de 250 pag y tienen la palabra in action
PrintValues(queries.BooksWithMore250PagesWithWordsAction());

void PrintValues(IEnumerable<Book> booksList)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var book in booksList)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
    }
}