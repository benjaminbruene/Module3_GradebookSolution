using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using GradebookApp;

namespace Gradebook.Tests
{
    public class GradebookTests
    {
        //Successfully add a valid grade
        [Fact]
        public void AddGrade_AddsValidGrade()
        {
            var book = new GradebookApp.Gradebook();
            book.AddGrade(90);
            Assert.Equal(1, book.GetCount());
        }

        //Reject an invalid grade
        [Fact]
        public void AddGrade_RejectsInvalidGrade()
        {
            var book = new GradebookApp.Gradebook();
            Assert.Throws<ArgumentOutOfRangeException>(() => book.AddGrade(150));
        }

        //Get the correct average 
        [Fact]
        public void GetAverage_ReturnsCorrectAverage()
        {
            var book = new GradebookApp.Gradebook();
            book.AddGrade(new List<double> { 80, 90, 100 });
            Assert.Equal(90, book.GetAverage(), 2);
        }

        //Validate highest and lowest 
        [Fact]
        public void GetHighestandLowest_WorksCorrectly()
        {
            var book = new GradebookApp.Gradebook();
            book.AddGrade(new List<double> { 70, 85, 95 });
            Assert.Equal(95, book.GetHighest());
            Assert.Equal(70, book.GetLowest());
        }


    }
}
