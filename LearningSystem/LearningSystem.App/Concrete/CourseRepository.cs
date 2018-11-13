using LearningSystem.Domain.Abstract;
using LearningSystem.Domain.Entity;
using System.Collections.Generic;

namespace LearningSystem.App.Concrete
{
    public class CourseRepository : Repository, ICourseRepository
    {
        public IEnumerable<Course> Courses => this.Context.Courses;
        public void SignUp(Student student, int CourseId)
        {
            if (this.Context.Courses.Find(CourseId) != null)
            {
                Student st = this.Context.Students.Find(student.Id);
                st.Courses.Add(this.Context.Courses.Find(CourseId));
                this.Context.SaveChanges();
            }
        }
        public Student GetStudent(int id)
        {
            return this.Context.Students.Find(id);
        }
        public void Delete(int id)
        {
            Course course = this.Context.Courses.Find(id);
            this.Context.Courses.Remove(course);
            this.Context.SaveChanges();
        }
        public void Add(Course course)
        {
            if (course.Id == 0)
            {
                Context.Courses.Add(course);
            }
            else
            {
                Course dbEntry = this.Context.Courses.Find(course.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = course.Name;
                    dbEntry.StartDate = course.StartDate;
                    dbEntry.EndDate = course.EndDate;
                }
            }
            Context.SaveChanges();
        }
    }
}