﻿namespace Task.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public IEnumerable<StudentCourse> Students { get; set; }
    }
}
