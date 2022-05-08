namespace GrpcShared.Dtos;
public record AddBookDto
{
    public string Name { get; set; } = null!;
    public string? Subject { get; set; }
    public string? ISBN { get; set; }
    public string? Genre { get; set; }
    public string? Description { get; set; }
    public string? Author { get; set; }
}

public record EditBookDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; }= null!;
    public string? Subject { get; set; }
    public string? ISBN { get; set; }
    public string? Genre { get; set; }
    public string? Description { get; set; }
    public string? Author { get; set; }
}

public record GetBookDtoInfo
{
    public string Id { get; set; } = null!;
    public string Name { get; set; }= null!;
    public string? Subject { get; set; }
    public string? ISBN { get; set; }
    public string? Genre { get; set; }
    public string? Description { get; set; }
    public GetAuthorInfoDto? Author { get; set; }
}


public record GetAuthorInfoDto
{
    public string Id { get; set; }
    public string Name { get; set; }
}




