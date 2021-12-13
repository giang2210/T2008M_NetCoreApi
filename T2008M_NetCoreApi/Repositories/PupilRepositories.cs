using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T2008M_NetCoreApi.Models;

namespace T2008M_NetCoreApi.Repositories
{
    public class PupilRepositories : PPupilRepositories, IDisposable
    {
        private DatabaseContext context;      

        public PupilRepositories(DatabaseContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Pupil>> GetStudentsAsync()
        {
            return await context.Students.ToListAsync();
        }
        public async Task<Pupil> GetStudentByIdAsync(int id)
        {
            return await context.Students.FindAsync(id);
        }

        public async Task AddStudentAsync(Pupil student)
        {
            await context.Students.AddAsync(student);
            await SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            Pupil ctg = await context.Students.FindAsync(id);
            if (ctg != null)
            {
                context.Students.Remove(ctg);
            }
            await SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(Pupil student)
        {
            var studentInDb = await context.Students.FindAsync(student.Id);
            studentInDb.FirstName = student.FirstName;
            studentInDb.LastName = student.LastName;
            studentInDb.PhoneNumber = student.PhoneNumber;
            studentInDb.Email = student.Email;
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
