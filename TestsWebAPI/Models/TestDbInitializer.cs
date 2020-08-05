using System.Collections.Generic;
using System.Data.Entity;

namespace TestsWebAPI.Models
{
    public class TestDbInitializer : DropCreateDatabaseAlways<TestContext>
    {
        protected override void Seed(TestContext db)
        {
            // test1 

            Question t1Question1 = new Question
            {
                Index = 0,
                Text = "You a or b",
                Answers = new List<Answer> { new Answer { Index = 0, Text = "a", IsTrue = true }, new Answer { Index = 1, Text = "b", IsTrue = false } },
                AnswersCount = 2
            };

            Question t1Question2 = new Question
            {
                Index = 1,
                Text = "You 1 or 2 or 3",
                Answers = new List<Answer> { new Answer { Index = 0, Text = "1", IsTrue = true }, new Answer { Index = 1, Text = "2", IsTrue = false },
                    new Answer { Index = 2, Text = "3", IsTrue = false } },
                AnswersCount = 3
            };

            Tag tag1 = new Tag
            {
                Name = "Numbers"
            };

            Tag tag2 = new Tag
            {
                Name = "Char"
            };

            Test test1 = new Test
            {
                Name = "Test1",
                Description = "Description1",
                Questions = new List<Question> { t1Question1, t1Question2 },
                Tags = new List<Tag> { tag1, tag2 }
            };

            db.Tests.Add(test1);

            base.Seed(db);
        }
    }
}