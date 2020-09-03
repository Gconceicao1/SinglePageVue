using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Data
{
    public interface IRepository
    {
         //GERAL

         void Add<T>(T entity) where T:class;
         void Update<T>(T entity) where T:class;
         void Delete<T>(T entity) where T:class;
         Task<bool> SaveChangesAsync();

         
        //Aluno
        Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor);
         
         Task<Aluno[]> GetAlunoByProfessorId(int ProfessorId, bool includeProfessor);
         
         Task<Aluno> GetAlunoAsyncById (int AlunoId, bool includeProfessor);
         
         //PROFESSOR
        Task<Professor[]> GetAllProfessorAsync(bool includeAluno);
         
         
         Task<Professor> GetAProfessorAsyncById (int ProfessorId, bool includeAluno);

    }
}