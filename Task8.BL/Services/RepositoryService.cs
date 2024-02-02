﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Task8.BL.Interfaces;
using Task8.Data.Data;
using Task8.Data.Entity.Generated;

namespace Task8.BL
{
    public class RepositoryService : IRepositoryService
    {
        private readonly Task6Context _context;

        public RepositoryService(Task6Context context)
        {
            _context = context;

            if (!_context.Database.CanConnect())
            {
                _context.Database.EnsureCreated();
                _context.Database.Migrate();
            }
        }

        public IEnumerable<Course> Courses => _context.Courses.Include(c => c.Groups).ThenInclude(t => t.Teacher).Include(g => g.Groups).ThenInclude(s => s.Students);

        public IEnumerable<Teacher> Teachers => _context.Teachers.Include(t => t.Groups);

        public void Add(Teacher teacher)
        {
            ArgumentNullException.ThrowIfNull(nameof(teacher));

            _context.Teachers.Add(teacher);
        }

        public void Add(Group group)
        {
            ArgumentNullException.ThrowIfNull(group, nameof(group));

            _context.Groups.Add(group);
        }

        public void Add(Student student)
        {
            ArgumentNullException.ThrowIfNull(student, nameof(student));

            _context.Students.Add(student);
        }

        public void Remove(Group group)
        {
            ArgumentNullException.ThrowIfNull(group, nameof(group));

            _context.Groups.Remove(group);
        }

        public void Remove(Student student)
        {
            ArgumentNullException.ThrowIfNull(student, nameof(student));

            _context.Students.Remove(student);
        }

        public void Remove(Teacher teacher)
        {
            ArgumentNullException.ThrowIfNull(teacher, nameof(teacher));

            _context.Teachers.Remove(teacher);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
