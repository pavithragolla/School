using Dapper;
using School.DTOs;
using School.Models;

namespace School.Repositories;


public interface IStudentRepository
{
    Task<Student> Create(Student Item);
    Task<bool> Update(Student Item);
    Task<Student> GetById(int Id);
    Task<List<Student>> GetList();
     Task<List<Student>>GetAllForTeachers(int Id);
     Task<List<Student>>GetAllForClass(int Id);

}

public class StudentRepository : BaseRepository, IStudentRepository
{
    public StudentRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<Student> Create(Student Item)
    {
        var query = $@"INSERT INTO public.student(
	 name, dob, address, gender, mobile,class_id)
	VALUES (@Name, @DOB, @Address, @Gender, @Mobile, @ClassId)  RETURNING *";
        using (var connection = NewConnection)
        {
            var res = await connection.QuerySingleOrDefaultAsync<Student>(query, Item);
            return res;
        }
    }

    public async Task<List<Student>> GetAllForClass(int Id)
    {
      var query = $@"SELECT * FROM student WHERE id = @Id";
        using (var con = NewConnection)

            return (await con.QueryAsync<Student>(query, new { Id })).AsList();
    }

    public async Task<List<Student>> GetAllForTeachers(int Id)
    {
         var query = $@"SELECT * FROM student_teacher st LEFT JOIN student s ON s.id = st.student_id WHERE st.teacher_id = @Id";
        using (var con = NewConnection)

            return (await con.QueryAsync<Student>(query, new { Id })).AsList();
    }

    public async Task<Student> GetById(int Id)
    {
      var query = $@"SELECT * FROM Student
        WHERE id = @Id";

         using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Student>(query, new { Id });
    }

    public async Task<List<Student>> GetList()
    {
        var query = $@"SELECT * FROM Student";

         List<Student> res;
        using (var con = NewConnection)
            res = (await con.QueryAsync<Student>(query)).AsList();
        return res;
    }

    public async Task<bool> Update(Student Item)
    {
         var query = $@"UPDATE Student SET dob=@DOB, address=@Address, mobile=@mobile 
        WHERE id = @Id ";
        using (var connection = NewConnection)
        {
            var Count = await connection.ExecuteAsync(query, Item);
            return Count == 1;
        }
    }
}