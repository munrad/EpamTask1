using EpamTask1;
using EpamTask1.Core.Interfaces.Catalog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using EpamTask1.Core.Classes;

namespace UnitTestEpamTask1
{
    [TestClass]
    public class LibraryTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        private Library CreateLibrary()
        {
            return new Library();
        }

        [TestMethod]
        public void Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateLibrary();
            ICatalogObject obj = new Book();
            bool isForce = true;

            // Act
            unitUnderTest.Add(
                obj,
                isForce);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void GetAllObjects_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateLibrary();

            // Act
            var result = unitUnderTest.GetAllObjects();

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void Remove_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateLibrary();
            ICatalogObject obj = new Paper();

            // Act
            unitUnderTest.Remove(
                obj);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void SearchByName_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateLibrary();
            string name = "TestName";

            // Act
            var result = unitUnderTest.SearchByName(
                name);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void SortByYear_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateLibrary();
            bool isReverse = true;

            // Act
            var result = unitUnderTest.SortByYear(
                isReverse);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void SearchBooksByAuthors_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateLibrary();
            string name = "TestAuthor";

            // Act
            var result = unitUnderTest.SearchBooksByAuthors(
                name);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void GetSortBooks_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateLibrary();
            string symb = "Test";

            // Act
            var result = unitUnderTest.GetSortBooks(
                symb);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void GroupByYear_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateLibrary();

            // Act
            var result = unitUnderTest.GroupByYear();

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void Save_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateLibrary();
            string objectName = "test.txt";

            // Act
            unitUnderTest.Save(
                objectName);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void Load_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateLibrary();
            string objectName = "test.txt";
            bool isForce = true;

            // Act
            unitUnderTest.Load(
                objectName,
                isForce);

            // Assert
            Assert.Fail();
        }
    }
}
