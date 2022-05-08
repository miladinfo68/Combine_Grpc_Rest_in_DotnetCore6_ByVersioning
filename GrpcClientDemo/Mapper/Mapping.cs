using GrpcShared;
using GrpcShared.Dtos;

namespace GrpcClientDemo.Mapper;
public static class Mapping
{
    public static AddBookRequest ToAddBookRequest(this AddBookDto bookDto)
    {
        return new AddBookRequest
        {
            Name = bookDto.Name,
            Subject = bookDto?.Subject,
            Genre = bookDto?.Genre,
            Isbn = bookDto?.ISBN,
            Description = bookDto?.Description,
            AuthorId = bookDto?.Author
        };
    }

    public static EditBookRequest ToEditBookRequest(this EditBookDto bookDto)
    {
        return new EditBookRequest
        {
            Id = bookDto.Id,
            Name = bookDto.Name,
            Subject = bookDto?.Subject,
            Genre = bookDto?.Genre,
            Isbn = bookDto?.ISBN,
            Description = bookDto?.Description,
            AuthorId = bookDto?.Author
        };
    }



    public static AddAuthorRequest ToAddAuthorRequest(this AddAuthorDto author)
    {
        return new AddAuthorRequest
        {
            Name = author.Name
        };
    }


    public static EditAuthorRequest ToEditAuthorRequest(this EditAuthorDto author)
    {
        return new EditAuthorRequest
        {
            Id= author.Id,
            Name = author.Name
        };
    }



}