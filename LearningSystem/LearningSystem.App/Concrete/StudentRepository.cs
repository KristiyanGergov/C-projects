using LearningSystem.Domain.Abstract;
using System;
using System.Collections.Generic;
using LearningSystem.Domain.Entity;

namespace LearningSystem.App.Concrete
{
    public class StudentRepository : Repository, IStudentRepository
    {
        public IEnumerable<Student> Students => this.Context.Students;
    }
}