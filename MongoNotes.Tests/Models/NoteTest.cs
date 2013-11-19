using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoNotes.Models;

namespace MongoNotes.Tests.Models
{
    [TestClass]
    public class NoteTest
    {
        [TestMethod]
        public void CreateNoteTest()
        {
            DateTime now = DateTime.Now;
            Note n = new Note(){
                Text = "This is a test",
                Date = now
            };

            Assert.AreEqual("This is a test", n.Text);
            Assert.AreEqual(now, n.Date);
        }

        [TestMethod]
        public void DateAutomaticallyGeneratedTest()
        {
            Note n = new Note();
            Assert.AreNotEqual(DateTime.MinValue, n.Date);
        }
    }
}
