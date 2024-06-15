using _4._07._23_2_.Abstract;
using _4._07._23_2_.Models;
using Microsoft.EntityFrameworkCore;

namespace _4._07._23_2_.Concrete
{
    public class JobSeekerRepository : IJobSeek
    {
        
        DataContext dbcontext= new DataContext();
        public JobSeeker CreateJobSeeker(JobSeeker jobSeeker)
        {
           dbcontext.Seekers.Add(jobSeeker);
           dbcontext.SaveChanges();
            return jobSeeker;
        } 

        public List<JobSeeker> GetAllJobSeek()
        {
            return dbcontext.Seekers.ToList();
        }

        public JobSeeker GetJobSeekerByMail(string mail)
        {
            return dbcontext.Seekers.FirstOrDefault(x => x.mail == mail);
        }

        public JobSeeker UpdateJobSeeker(JobSeeker jobSeeker)
        {
            var updated = GetJobSeekerById(jobSeeker.Id);
            dbcontext.Seekers.Update(updated);
            dbcontext.SaveChanges();
            return jobSeeker;
        }

        public void DeleteJobSeeker(string mail)
        {
            var deletedJobSeeker = GetJobSeekerByMail(mail);
            dbcontext.Seekers.Remove(deletedJobSeeker);
            dbcontext.SaveChanges();
        }

        public JobSeeker GetJobSeekerById(int id)
        {
            return dbcontext.Seekers.FirstOrDefault(x => x.Id == id);
        }
    }
}
