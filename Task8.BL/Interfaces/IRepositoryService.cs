﻿using System.Collections.Generic;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Interfaces
{
    public interface IRepositoryService
    {
        public IEnumerable<Course> Courses { get; }

        public IEnumerable<Teacher> Teachers { get; }

        public void Add(Teacher teacher);

        public void Add(Group teacher);

        public void Add(Student student);

        public void Remove(Teacher teacher);

        public void Remove(Group group);

        public void Remove(Student student);

        public void LoadPressets();

        public void SaveChanges();
    }
}
