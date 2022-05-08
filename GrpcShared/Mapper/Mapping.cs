using GrpcShared.Dtos;
using GrpcShared.Model;

namespace GrpcShared.Mapper;
public static class Mapping
{
    public static Book ToAddBook(this AddBookDto bookDto)
    {
        return new Book
        {
            Name = bookDto.Name,
            Subject = bookDto?.Subject,
            Genre = bookDto?.Genre,
            ISBN = bookDto?.ISBN,
            Description = bookDto?.Description,
            AuthorId = bookDto?.Author
        };
    }

    public static Book ToEditBook(this EditBookDto bookDto)
    {
        return new Book
        {
            Id = bookDto.Id,
            Name = bookDto.Name,
            Subject = bookDto?.Subject,
            Genre = bookDto?.Genre,
            ISBN = bookDto?.ISBN,
            Description = bookDto?.Description,
            AuthorId = bookDto?.Author
        };
    }



    public static Author ToAddAuthor(this AddAuthorDto authorDto)
    {
        return new Author
        {
            Name = authorDto.Name,
        };
    }

    public static Author ToEditAuthor(this EditAuthorDto authorDto)
    {
        return new Author
        {
            Id = authorDto.Id,
            Name = authorDto.Name,
        };
    }

}