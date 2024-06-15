using _4._07._23_2_.Models;

namespace _4._07._23_2_.Abstract
{
    public interface IJobSeek
    {

        List<JobSeeker> GetAllJobSeek();

        JobSeeker GetJobSeekerByMail(string mail);

        JobSeeker CreateJobSeeker(JobSeeker jobSeeker);

        JobSeeker UpdateJobSeeker(JobSeeker jobSeeker);

        void DeleteJobSeeker(string mail);

        JobSeeker GetJobSeekerById(int id);
    }
}
