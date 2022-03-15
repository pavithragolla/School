using School.DTOs;

namespace School.Models;

public record Class
{
    public int Capacity { get; set; }

    public ClassDTO asDto => new ClassDTO
    {
        Capacity = Capacity,
    };
}