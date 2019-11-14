using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringParser.Test
{
    [TestClass]
    public class TemplateTest
    {
        [TestMethod]
        public void Template_IsMatch()
        {
            // var template = new Template("test-{test_name}");
            // template.Compile();

            // var match = template.IsMatch("test-one");

            var match = "test-two".IsMatch("test-{test_name}");
            
            Assert.IsTrue(match);
        }

        [TestMethod]
        public void Template_Parse()
        {
            //var template = new Template("test-{test_name}");
            //template.Compile();

            //var data = template.Parse("test-parse");

            var data = "test-two".Parse("test-{test_name}");

            Assert.IsNotNull(data);
            Assert.IsTrue(data.Count == 1);
            Assert.IsTrue(data.ContainsKey("test_name"));
            Assert.IsTrue(data["test_name"] == "two");
        }

        [TestMethod]
        public void Template_IsMatch_Exception()
        {
            // this code will throw an exception
            // because we did not call .Compile()
            // before calling .IsMatch
            var template = new Template("test-{name}");
            var isThrew = false;

            try
            {
                var match = template.IsMatch("test-match");
            }
            catch (Exception)
            {
                isThrew = true;
            }

            Assert.IsTrue(isThrew);
        }

        [TestMethod]
        public void Template_Parse_Exception()
        {
            // this code will throw an exception
            // because we did not call .Compile()
            // before calling .IsMatch
            var template = new Template("test-{name}");
            var isThrew = false;

            try
            {
                var data = template.Parse("test-parse");
            }
            catch (Exception)
            {
                isThrew = true;
            }

            Assert.IsTrue(isThrew);
        }
    }
}
