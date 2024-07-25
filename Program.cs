LinqQueries queries = new LinqQueries();    

//toda la coleccion
//PrintValues(queries.AllCollection());

//libros desp del 2000.
//PrintValues(queries.BooksAfter2000());

//libros que tienen mas de 250 pag y tienen la palabra in action
//PrintValues(queries.BooksWithMore250PagesWithWordsAction());

//todos los libros tienen status    
//Console.WriteLine($" Todos los libros tienen Status? - {queries.AllBooksHaveStatus()}");

//algun libro fue publicado en 2005?
//Console.WriteLine($" algun libro fue publicado en 2005? - {queries.IfAnyBookWasPublishedIn2005()}");

//libros que son de python
//PrintValues(queries.BooksPython());

//libros de java por nombres asccendentes.
//PrintValues(queries.BooksJavaForNameAscending());

//tres primero libros filtrados con select
//PrintValues(queries.TopThreeBooksColection());

// var libroMenorPag = queries.BookMinNumPage();
// Console.WriteLine($" {libroMenorPag.Title} - {libroMenorPag.PageCount}");

// void PrintValues(IEnumerable<Book> booksList)
// {
//     Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
//     foreach (var book in booksList)
//     {
//         Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
//     }
// }

// PrintGroup(queries.BooksAfter2000ForYear());

// operadores de group by
// void PrintGroup(IEnumerable<IGrouping<int, Book>> booksList)
// {
//     foreach (var group in booksList)
//     {
//         Console.WriteLine("");
//         Console.WriteLine($"Grupo: {group.Key}");        
//         Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        
//         foreach (var item in group)
//         {
//             Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
//         }
//     }
// }

//diccionario.
var dictionaryLookUp = queries.BooksByLetter();

PrintLookUp(dictionaryLookUp, 'A');

//operadores de look up
void PrintLookUp(ILookup<char, Book> booksList, char letter)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    
    foreach (var item in booksList[letter])
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}