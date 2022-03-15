using System.Text.Json.Serialization;

namespace School.DTOs;

public record StudentDTO
{
    [JsonPropertyName("name")]
     public string Name { get; set; }
    [JsonPropertyName("date_of_birth")]
    public DateTimeOffset DOB { get; set; }
    [JsonPropertyName("address")]
    public string Address { get; set; }
    [JsonPropertyName("gender")]
    public string Gender { get; set; }
    [JsonPropertyName("mobile")]
    public long Mobile { get; set; }
    [JsonPropertyName("class_id")]
    public int ClassId { get; set; }

      public List<TeacherDTO> Teacher {get; internal set; }
      public List<SubjectDTO> Subject {get; internal set; }
}
public record StudentCreateDTO
{
    [JsonPropertyName("name")]
     public string Name { get; set; }
    [JsonPropertyName("date_of_birth")]
    public DateTimeOffset DOB { get; set; }
    [JsonPropertyName("address")]
    public string Address { get; set; }
    [JsonPropertyName("gender")]
    public string Gender { get; set; }
    [JsonPropertyName("mobile")]
    public long Mobile { get; set; }
    [JsonPropertyName("class_id")]
    public int ClassId { get; set; }

    public List<TeacherDTO> Teacher {get; internal set; }
}
public record StudentUpdateDTO
{
    [JsonPropertyName("date_of_birth")]
    public DateTimeOffset DOB { get; set; }
    [JsonPropertyName("address")]
    public string Address { get; set; }
   
    [JsonPropertyName("mobile")]
    public long Mobile { get; set; }
    
}