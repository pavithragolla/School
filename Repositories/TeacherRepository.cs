using Dapper;
using School.DTOs;
using School.Models;

namespace School.Repositories;

public interface ITeacherRepository
{
     Task<Teacher> Create(Teacher Item);
     Task<bool> Update(Teacher Item);
      Task<Teacher> GetById(int Id);
    Task<List<Teacher>> GetList();
    Task<List<Teacher>>GetAllForStudents(int Id);
    Task<List<Teacher>>GetAllForSubject(int SubjectId);

}
public class TeacherRepository : BaseRepository, ITeacherRepository
{
    public TeacherRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<Teacher> Create(Teacher Item)
    {
       var query =$@"INSERT INTO public.teacher(
	 name, gender, mobile, subject_id)
	VALUES (@Name, @Gender, @Mobile, @Subject)";

    using (var connection = NewConnection)
        {
            var res = await connection.QuerySingleOrDefaultAsync<Teacher>(query, Item);
            return res;
        }
    }

    public async Task<List<Teacher>> GetAllForStudents(int Id)
    {
        var query = $@"SELECT t.*, s.name AS name FROM student_teacher st 
        LEFT JOIN teacher t ON t.id = st.teacher_id 
        LEFT JOIN subject s ON s.id = t.subject_id WHERE st.student_id = @Id";
        using (var con = NewConnection)

            return (await con.QueryAsync<Teacher>(query, new { Id })).AsList();
    
    }

    public async Task<List<Teacher>> GetAllForSubject(int SubjectId)
    {

        var query =$@"SELECT t.* ,s.name AS subject_name FROM teacher t
        LEFT JOIN subject s ON s.id = t.subject_id WHERE subject_id = @SubjectId";
		
      using (var con = NewConnection)

            return (await con.QueryAsync<Teacher>(query, new { SubjectId })).AsList();  
    }

    public async Task<Teacher> GetById(int Id)
    {
        var query =$@"SELECT * FROM teacher WHERE id = @Id";

         using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Teacher>(query, new { Id });
    }

    public async Task<List<Teacher>> GetList()
    {
         var query = $@"SELECT * FROM teacher";

          List<Teacher> res;
        using (var con = NewConnection)
            res = (await con.QueryAsync<Teacher>(query)).AsList();
        return res;
    }

    public async Task<bool> Update(Teacher Item)
    {
         var query = $@"UPDATE teacher SET  name=@Name, gender = @Gender, mobile = @Mobile, 
         subject_id = @SubjectId WHERE id = @Id ";
          using (var connection = NewConnection)
        {
            var Count = await connection.ExecuteAsync(query, Item);
            return Count == 1;
        }
    }
}