﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task8.Data.Entity.Generated;

namespace Task8.BL
{
    public class GroupReport : IEquatable<GroupReport>
    {
        private readonly string _courseNameHeader;
        private readonly string _groupNameHeader;
        private readonly List<Student> _students;

        public GroupReport(string courseNameHeader, string groupNameHeader, List<Student> students)
        {
            _courseNameHeader = courseNameHeader;
            _groupNameHeader = groupNameHeader;
            _students = students;
        }

        public IEnumerable<Student> Students => _students;

        public string GroupNameHeader => _groupNameHeader;

        public string CourseNameHeader => _courseNameHeader;

        public bool Equals(GroupReport other)
        {
            return string.Equals(GroupNameHeader, other.GroupNameHeader) && string.Equals(CourseNameHeader, other.CourseNameHeader) && Students.SequenceEqual(other.Students);
        }

        public override bool Equals(object obj)
        {
            if (obj is GroupReport)
            {
                return Equals(obj as GroupReport);
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_courseNameHeader, _groupNameHeader);
        }
    }
}
