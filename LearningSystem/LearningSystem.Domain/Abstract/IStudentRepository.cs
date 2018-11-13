using LearningSystem.Domain.Entity;
using System.Collections.Generic;

namespace LearningSystem.Domain.Abstract
{
    public interface IStudentRepository
    {
        IEnumerable<Student> Students { get; }
    }
}
