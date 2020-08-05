using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TestsWebAPI.Models;

namespace TestsWebAPI.Controllers
{
    public class TestsController : ApiController
    {
        // GET api/Tests
        [Route("api/tests")]
        public ICollection<Test> Get()
        {
            using (var testContext = new TestContext())
            {
                return testContext.Tests
                    .Include(t => t.Questions)
                    .Include(t => t.Tags)
                    .ToList();
            }
        }

        // GET api/Tests/id
        [HttpGet]
        public Test Get(int? id)
        {
            if (!id.HasValue)
                return null;

            using (var testContext = new TestContext())
            {
                return testContext.Tests
                    .Include(t => t.Questions)
                    .Include(t => t.Tags)
                    .FirstOrDefault(t => t.Id == id);
            }
        }

        // GET api/Tests/SearchName
        [HttpGet, Route("api/tests/SearchName/")]
        public ICollection<Test> SearchName(string name)
        {
            using (var testContext = new TestContext())
            {
                List<Test> tests = new List<Test>();

                if (!string.IsNullOrEmpty(name))
                {
                    tests = testContext.Tests
                        .Include(t => t.Questions)
                        .Include(t => t.Tags)
                        .Where(t => t.Name.Contains(name))
                        .ToList();
                }
                else
                {
                    tests = testContext.Tests
                        .Include(t => t.Questions)
                        .Include(t => t.Tags)
                        .ToList();
                }

                return tests;
            }
        }

        // GET api/Tests/SearchName
        [HttpPost, Route("api/tests/SearchTag/")]
        public ICollection<Test> SearchTag(Tag tag)
        {
            using (var testContext = new TestContext())
            {
                ICollection<Test> tests = new List<Test>();
                if (tag == null)
                {
                    tests = testContext.Tests
                        .ToList();
                }
                else
                {
                    tests = testContext.Tests
                        .Include(t => t.Questions)
                        .Include(t => t.Tags)
                        .Where(t => t.Tags
                                    .Any(tg => tg.Id == tag.Id))
                        .ToList();
                }
                return tests;
            }
        }

        // GET api/Tests/CheckQuestion
        [HttpGet, Route("api/tests/CheckQuestion/")]
        public bool CheckQuestion(int? testId, int? questionIndex, int? index)
        {
            if (!testId.HasValue || !questionIndex.HasValue || !index.HasValue)
                return false;

            using (var testContext = new TestContext())
            {
                bool result = false;

                var question = testContext.Tests
                    .Include(t => t.Questions)
                    .Include(t => t.Questions.Select(q => q.Answers))
                    .SingleOrDefault(t => t.Id == testId)
                        ?.Questions.FirstOrDefault(q => q.Index == questionIndex);  // Получаем вопрос по Id

                var answer = question?.Answers
                    .FirstOrDefault(a => a.Index == index);

                if (answer != null)
                {
                    if (answer.IsTrue)
                        result = true;
                }

                return result;
            }
        }

        // GET api/Tests/LoadQuestion
        [HttpGet, Route("api/tests/LoadQuestion/")]
        public Question LoadQuestion(int? testId, int? questionIndex)
        {
            if (!testId.HasValue || !questionIndex.HasValue)
                return null;

            using (var testContext = new TestContext())
            {
                var question = testContext.Tests
                    .Include(t => t.Questions)
                    .Include(t => t.Questions.Select(q => q.Answers))
                    .SingleOrDefault(t => t.Id == testId)
                        ?.Questions.FirstOrDefault(q => q.Index == questionIndex);  // Получаем вопрос по Id

                return question;
            }
        }

        // POST api/Tests
        public void Post([FromBody] Test newTest)
        {
            using (TestContext testContext = new TestContext())
            {
                testContext.Tests.Add(newTest);
                testContext.SaveChanges();
            }
        }

        // PUT api/Tests/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Tests/5
        public void Delete(int id)
        {
        }
    }
}
