using Dapper;
using School.DTOs;
using School.Models;

namespace School.Repositories;


public interface IClassRepository
{
    Task<Class> Create(Class Item);
    Task<bool> Update(Class Item);
    Task<bool> Delete(Class Item);
    Task<Class> GetById(int Id);
    Task<List<ClassDTO>>GetAllForClass(int Id);
    
}

public class ClassRepository : BaseRepository, IClassRepository
{
    public ClassRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<Class> Create(Class Item)
    {
        var query = $@"INSERT INTO public.Class(capacity)
        VALUES (@Capacity)  RETURNING *";
        using (var connection = NewConnection)
        {
            var res = await connection.QuerySingleOrDefaultAsync<Class>(query, Item);
            return res;
        }
    }

    public async Task<bool> Delete(Class Item)
    {
          var query = $@"DELETE FROM class WHERE id=@Id";

        using (var con = NewConnection)
        {
            var result = await con.ExecuteAsync(query, Item);
            return result > 0;
        }
    }
//  Task<List<StudentDTO>>GetAllForStudents(int Id);
    
    public async Task<List<ClassDTO>> GetAllForClass(int Id)
    {
       var query = $@"SELECT * FROM student WHERE id = @Id";
        using (var con = NewConnection)

            return (await con.QueryAsync<ClassDTO>(query, new { Id })).AsList();
    }

    public async Task<Class> GetById(int Id)
    {
      var query = $@"SELECT * FROM Class
        WHERE id = @Id";

         using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Class>(query, new { Id });
    }


    public async Task<bool> Update(Class Item)
    {
         var query = $@"UPDATE Class SET capacity = @Capacity
        WHERE id = @Id ";
        using (var connection = NewConnection)
        {
            var Count = await connection.ExecuteAsync(query, Item);
            return Count == 1;
        }
    }
}