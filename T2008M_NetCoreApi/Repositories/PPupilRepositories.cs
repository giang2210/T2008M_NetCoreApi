using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T2008M_NetCoreApi.Models;

namespace T2008M_NetCoreApi.Repositories
{
    public interface PPupilRepositories
    {
        Task<IEnumerable<Pupil>> GetStudentsAsync();
        Task<Pupil> GetStudentByIdAsync(int id);
        Task AddStudentAsync(Pupil student);
        Task DeleteStudentAsync(int id);
        Task UpdateStudentAsync(Pupil student);
        Task SaveChangesAsync();
        
    }
}
