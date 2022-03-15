
using Dapper;
using School.DTOs;
using School.Models;

namespace School.Repositories;


public interface ISubjectRepository
{
    Task<Subject> Create(Subject Item);
    Task<Subject> GetById(int Id);
    Task<List<Subject>> GetList();

    Task<List<Subject>> GetAllForStudent(int Id);
    Task<List<Subject>> GetAllForTeacher(int TeacherId);
}

public class SubjectRepository : BaseRepository, ISubjectRepository
{
    public SubjectRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<Subject> Create(Subject Item)
    {
        var query = $@"INSERT INTO subject (name) VALUES(@Name)";
        using (var connection = NewConnection)
        {
            var res = await connection.QuerySingleOrDefaultAsync<Subject>(query, Item);
            return res;
        }
    }

    public async Task<List<Subject>> GetAllForStudent(int Id)
    {
        var query = $@"SELECT * FROM student_subject ss LEFT JOIN subject 
         s ON s.id = ss.subject_id WHERE ss.student_id = @Id";
        using (var con = NewConnection)

            return (await con.QueryAsync<Subject>(query, new { Id })).AsList();
    }

    public async Task<List<Subject>> GetAllForTeacher(int TeacherId)
    {
        var query = $@"SELECT * FROM teacher WHERE id = @TeacherId";
        using (var con = NewConnection)
            return (await con.QueryAsync<Subject>(query, new { TeacherId })).AsList();
    }

    public async Task<Subject> GetById(int Id)
    {
        var query = $@"SELECT * FROM subject
        WHERE id = @Id";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Subject>(query, new { Id });
    }

    public async Task<List<Subject>> GetList()
    {
        var query = $@"SELECT * FROM subject";

        List<Subject> res;
        using (var con = NewConnection)
            res = (await con.QueryAsync<Subject>(query)).AsList();
        return res;
    }
}