﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Models
{
    public class GroupEditModel : IGroupEditModel
    {
        private readonly IRepositoryService _repositoryService;
        private Group _currentGroup = new();

        public GroupEditModel(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        public IEnumerable<Student> Students => _currentGroup.Students;
         
        public void CreateStudent(string name, string lastName)
        {
            throw new NotImplementedException();
        }

        public void InitGroup(Group group)
        {
            if (group !=  null) 
            {
                _currentGroup = group;
            }
        }

        public void RemoveStudent(Student group)
        {
            throw new NotImplementedException();
        }

        public void SaveChangesFor(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
