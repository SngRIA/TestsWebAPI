using System.Collections.Generic;
using System.Data.Entity;

namespace TestsWebAPI.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Question> Questions { get; set; }
        public int CountQuestions { get; set; }
        public ICollection<Tag> Tags { get; set; }

        public Test()
        {
            Questions = new List<Question>();
            Tags = new List<Tag>();
        }
    }

    public class Question
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string Text { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public int AnswersCount { get; set; }
        public Question()
        {
            Answers = new List<Answer>();
        }
    }
    public class Answer
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string Text { get; set; }
        public bool IsTrue { get; set; }
    }
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Test> Tests { get; set; }
        public Tag()
        {
            Tests = new List<Test>();
        }
    }
}