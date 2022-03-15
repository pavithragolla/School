namespace School.DTOs;
public record ClassDTO
{
    public int Capacity { get; set; }

     public List<StudentDTO> Students {get; internal set; }
    //  public List<ClassDTO> Class {get; internal set; }
}
public record ClassCreateDTO
{
    public int Capacity { get; set; }
}
public record ClassUpdateDTO
{
    public int Capacity { get; set; }
}