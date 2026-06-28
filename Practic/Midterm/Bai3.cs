using System;
using System.Collections.Generic;
using System.Linq;

public class Book
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public decimal Price { get; set; }
}

public interface IBooksRepository
{
    IList<Book> GetAll();
    Book? GetById(long id);
    Book Add(Book book);
    IReadOnlyList<Book> GetBooksCheaperThan(decimal maxPrice);
    IReadOnlyList<Book> GetTopExpensiveBooks(int n);
}

public class BooksRepository : IBooksRepository
{
    private readonly List<Book> _books = new();

    public BooksRepository()
    {
        _books.AddRange(new[]
        {
            new Book { Id = 1, Title = "Lap trinh C#", Price = 45m },
            new Book { Id = 2, Title = "Co so du lieu", Price = 72m },
            new Book { Id = 3, Title = "Cau truc du lieu", Price = 58m },
            new Book { Id = 4, Title = "Nhap mon AI", Price = 120m }
        });
    }

    public IList<Book> GetAll()
        => _books;

    public Book? GetById(long id)
        => _books.FirstOrDefault(b => b.Id == id);

    public Book Add(Book book)
    {
        _books.Add(book);
        return book;
    }

    public IReadOnlyList<Book> GetBooksCheaperThan(decimal maxPrice)
    {
        return _books.Where(b => b.Price < maxPrice).ToList();
    }

    public IReadOnlyList<Book> GetTopExpensiveBooks(int n)
    {
        if (n <= 0)
        {
            return Array.Empty<Book>();
        }

        return _books
            .OrderByDescending(b => b.Price)
            .ThenBy(b => b.Id)
            .Take(n)
            .ToList();
    }
}
