using EpamTask1;
using EpamTask1.Core.Interfaces.Catalog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using EpamTask1.Core;
using EpamTask1.Core.Classes;
using EpamTask1.Core.Interfaces;

namespace UnitTestEpamTask1
{
    [TestClass]
    public class LibraryTests
    {
        private MockRepository mockRepository;

        /* зачем ты сделал, чтобы все тесты падали??? Как проверить функционал?? Создай тестовые объекты, заполни их данными и напиши проверки
         * хотя бы для требований из 2ого задания
         * */

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
            var lib = new Library();
            lib.Add(new Patent { PubDate = new DateTime(1994, 01, 01) });
            lib.Add(new Book { Authors = new List<string> { "h", "u", "k" } });
            lib.Add(new Book { Isbn = "2" });
            lib.Add(new Book());
            lib.Add(new Book { Isbn = "1" });
            lib.Add(new Book { Name = "3" });
            lib.Add(new Book { Name = "4" });
            lib.Add(new Paper { Name = "4" });
            lib.Add(new Book { PubYear = 1994 });
            lib.Add(new Book { PubYear = 1995 });
            lib.Add(new Book { PubYear = 1999 });
            lib.Add(new Book { Authors = new List<string> { "Lol", "Kek" } });
            lib.Add(new Book { Authors = new List<string> { "Lol", "Kek", "Cheburek" } });
            lib.Add(new Book { PubName = "Kek" });
            lib.Add(new Book { PubName = "Kek 33" });
            lib.Add(new Book { PubName = "Kek" });
            lib.Add(new Book { PubName = "Kek 22" });
            lib.Add(new Book { PubName = "Kek" });
            lib.Add(new Book { PubName = "Kek 22" });
            lib.Add(new Book { PubName = "Kek 33" });
            lib.Add(new Book { PubName = "Kuk" });
            lib.Add(new Paper { PubYear = 1994 });
            lib.Add(new Patent { PubDate = new DateTime(1994, 01, 01) });
            return lib;
        }

        [TestMethod]
        public void Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateLibrary();
            ICatalogObject obj = new Book() { Name = "Test" };
            bool isForce = true;

            // Act
            unitUnderTest.Add(
                obj,
                isForce);

            // Assert
        }

        [TestMethod]
        public void GetAllObjects_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateLibrary();

            // Act
            var result = unitUnderTest.GetAllObjects();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Remove_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateLibrary();
            ICatalogObject obj = new Book();

            // Act
            unitUnderTest.Remove(
                obj);

            // Assert
        }

        [TestMethod]
        public void SearchByName_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateLibrary();
            string name = "Test";

            // Act
            var result = unitUnderTest.SearchByName(
                name);

            // Assert
            Assert.IsNotNull(result);
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
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SearchBooksByAuthors_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateLibrary();
            string name = "Lol";

            // Act
            var result = unitUnderTest.SearchBooksByAuthors(
                name);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetSortBooks_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateLibrary();
            string symb = "Kek";

            // Act
            var result = unitUnderTest.GetSortBooks(
                symb);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GroupByYear_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateLibrary();

            // Act
            var result = unitUnderTest.GroupByYear();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Search_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateLibrary();
            // Act
            var result = unitUnderTest.CustomSearch(m =>
            {
                if (m is Book tr)
                    return tr.Name.Equals("4");
                return false;
            });

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Sort_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateLibrary();
            // Act
            var result = unitUnderTest.CustomSort(m =>
            {
                if (m is Book tr)
                    return tr.PubYear;
                return 0;
            });
            //Assert
            Assert.IsNotNull(result);
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
        }
    }
}
