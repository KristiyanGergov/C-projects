using LearningSystem.Domain.Entity;
using System.Collections.Generic;

namespace LearningSystem.Domain.Abstract
{
    public interface ICourseRepository
    {
        IEnumerable<Course> Courses { get; }
        void SignUp(Student student, int CourseId);
        Student GetStudent(int id);
        void Delete(int id);
        void Add(Course course);
    }
}
