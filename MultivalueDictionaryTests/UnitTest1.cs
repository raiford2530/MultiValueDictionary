using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mvd;
using System.Collections.Generic;
using System.Linq;

namespace MuiltiValueDictionaryTests
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void Add()
        {
            MultiValueDicationary<string, string> mvd = new MultiValueDicationary<string, string>();
            mvd.Add("fizz", "buzz");
            string expected1 = "fizz buzz";
            mvd.Add("fazz", "bizz");
            string expected2 = "fazz bizz";
            mvd.Add("fozz", "bazz");
            mvd.Add("fozz", "bozz");
            string expected3 = "fozz bazz bozz";

            Assert.AreEqual(expected1, ToAssertableString(mvd, "fizz"));
            Assert.AreEqual(expected2, ToAssertableString(mvd, "fazz"));
            Assert.AreEqual(expected3, ToAssertableString(mvd, "fozz"));

        }

        [TestMethod]
        public void Remove()
        {
            MultiValueDicationary<string, string> mvd = new MultiValueDicationary<string, string>();
            mvd.Add("fozz", "bazz");
            mvd.Add("fozz", "bozz");
            mvd.Remove("fozz", "bozz");
            string expected = "fozz bazz";

            Assert.AreEqual(expected, ToAssertableString(mvd, "fozz"));

        }


        [TestMethod]
        public void RemoveAll()
        {
            MultiValueDicationary<string, string> mvd = new MultiValueDicationary<string, string>();
            mvd.Add("fozz", "bazz");
            mvd.Add("fozz", "bozz");
            mvd.RemoveAll("fozz");
            string expected = "";

            Assert.AreEqual(expected, ToAssertableString(mvd, "fozz"));

        }

        [TestMethod]
        public void Members()
        {
            MultiValueDicationary<string, string> mvd = new MultiValueDicationary<string, string>();
            mvd.Add("fozz", "bazz");
            mvd.Add("fozz", "bozz");

            List<string> expected = new List<string> { "bazz", "bozz" };

            Assert.IsTrue(CompareLists(expected, mvd.Members("fozz").ToList()));

        }

        [TestMethod]
        public void Keys()
        {
            MultiValueDicationary<string, string> mvd = new MultiValueDicationary<string, string>();
            mvd.Add("fozz", "bazz");
            mvd.Add("fizz", "bozz");

            List<string> expected = new List<string> { "fozz", "fizz" };

            Assert.IsTrue(CompareLists(expected, mvd.Keys.ToList()));
        }

        [TestMethod]
        public void KeyExists()
        {
            MultiValueDicationary<string, string> mvd = new MultiValueDicationary<string, string>();
            mvd.Add("fozz", "bazz");
            mvd.Add("fizz", "bozz");


            Assert.IsTrue(mvd.KeyExists("fozz"));
        }

        [TestMethod]
        public void MemberExists()
        {
            MultiValueDicationary<string, string> mvd = new MultiValueDicationary<string, string>();
            mvd.Add("fozz", "bazz");
            mvd.Add("fizz", "bozz");


            Assert.IsTrue(mvd.MemberExists("fizz", "bozz"));
        }

        [TestMethod]
        public void MemberCount()
        {
            MultiValueDicationary<string, string> mvd = new MultiValueDicationary<string, string>();
            mvd.Add("fozz", "bazz");
            mvd.Add("fizz", "bozz");
            mvd.Add("fizz", "fazz");


            Assert.AreEqual(2, mvd.MemberCount("fizz"));
        }

        [TestMethod]
        public void Count()
        {
            MultiValueDicationary<string, string> mvd = new MultiValueDicationary<string, string>();
            mvd.Add("fozz", "bazz");
            mvd.Add("fizz", "bozz");
            mvd.Add("fizz", "fazz");


            Assert.AreEqual(2, mvd.Count);
        }

        [TestMethod]
        public void Clear()
        {
            MultiValueDicationary<string, string> mvd = new MultiValueDicationary<string, string>();
            mvd.Add("fozz", "bazz");
            mvd.Add("fizz", "bozz");
            mvd.Add("fizz", "fazz");

            mvd.Clear();

            Assert.AreEqual(0, mvd.Count);
        }



        public string ToAssertableString(MultiValueDicationary<string, string> mvd, string key)
        {
            if (!mvd.KeyExists(key) || !mvd[key].Any())
            {
                return "";
            }

            return $"{key} {string.Join(" ", mvd[key])}";
        }

        public bool CompareLists(List<string> list1, List<string> list2)
        {
            return list1.All(x => list2.Contains(x)) && list1.Count == list2.Count;
        }
    }
}
