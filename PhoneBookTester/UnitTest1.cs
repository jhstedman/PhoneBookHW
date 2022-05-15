using NUnit.Framework;
using PhoneBook;

namespace PhoneBookTester
{
    public class Tests
    {
        [Test]
        public void TestStoreAndGet()
        {
            var store = new PhoneBookStorage("C:\\Users\\James\\Desktop\\PhoneBook.txt");
            var phoneBook = new PhoneBookClass(store);
            phoneBook.Store("James", "07468455995");
            Assert.AreEqual("07468455995", phoneBook.Get("James"));
        }

        [Test]
        public void TestGetFileExists()
        {
            var store = new PhoneBookStorage("C:\\Users\\James\\Desktop\\PhoneBook.txt");
            var phoneBook = new PhoneBookClass(store);
            Assert.AreEqual("07468455995", phoneBook.Get("James"));
        }

        [Test]
        public void TestGetFileExistsEmpty()
        {
            var store = new PhoneBookStorage("C:\\Users\\James\\Desktop\\PhoneBook.txt");
            var phoneBook = new PhoneBookClass(store);
            Assert.AreEqual("NaN", phoneBook.Get("James"));
        }

        [Test]
        public void TestRemoveByName()
        {
            var store = new PhoneBookStorage("C:\\Users\\James\\Desktop\\PhoneBook.txt");
            var phoneBook = new PhoneBookClass(store);
            phoneBook.Store("James", "07468455995");
            var oldNumber = phoneBook.RemoveByName("James");
            Assert.AreEqual("07468455995", oldNumber);
            Assert.AreEqual("NaN", phoneBook.Get("James"));
        }

        [Test]
        public void TestUpdate()
        {
            var store = new PhoneBookStorage("C:\\Users\\James\\Desktop\\PhoneBook.txt");
            var phoneBook = new PhoneBookClass(store);
            phoneBook.Store("James", "07468455995");
            var oldNumber = phoneBook.Update("James", "02083032611");
            Assert.AreEqual("07468455995", oldNumber);
            Assert.AreEqual("02083032611", phoneBook.Get("James"));
        }

        [Test]
        public void TestRemoveByNumber()
        {
            var store = new PhoneBookStorage("C:\\Users\\James\\Desktop\\PhoneBook.txt");
            var phoneBook = new PhoneBookClass(store);
            phoneBook.Store("James", "07468455995");
            Assert.AreEqual("07468455995", phoneBook.Get("James"));
            phoneBook.RemoveByNumber("07468455995");
            Assert.AreEqual("NaN", phoneBook.Get("James"));
        }

        [Test]
        public void TestStoreWithSameName()
        {
            var store = new PhoneBookStorage("C:\\Users\\James\\Desktop\\PhoneBook.txt");
            var phoneBook = new PhoneBookClass(store);
            phoneBook.Store("James", "07468455995");
            phoneBook.Store("James", "02083032611");
            Assert.AreEqual("02083032611", phoneBook.Get("James"));
        }
    }
}