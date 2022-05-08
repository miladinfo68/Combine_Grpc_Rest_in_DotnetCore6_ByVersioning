namespace GrpcShared.Dtos;

public record AddAuthorDto
{
    public string Name { get; set; } = null!;
    // public List<string>? Books { get; set; }
}

public record EditAuthorDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    // public List<string>? Books { get; set; }
}


//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

public record GetAuthorDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public IEnumerable<GetBookDto>? Books { get; set; }

}

public record GetBookDto
{
    public string Id { get; set; }
    public string Name { get; set; }
}


