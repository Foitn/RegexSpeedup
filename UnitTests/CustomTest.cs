using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegexSpeedup;
using RegexSpeedupFoitn;

namespace UnitTests
{
    [TestClass]
    public class ForRemoveWhiteSpaceTest : RemoveWhiteSpaceBaseTest
    {
        protected override string RemoveAdditionalWhiteSpace(string input)
        {
            return RegexSpeedupFoitn.RemoveAdditionalWhiteSpace.ReplaceWhiteSpacesFor(input);
        }
    }
    [TestClass]
    public class LinqRemoveWhiteSpaceTest : RemoveWhiteSpaceBaseTest
    {
        protected override string RemoveAdditionalWhiteSpace(string input)
        {
            return RegexSpeedupFoitn.RemoveAdditionalWhiteSpace.ReplaceWhiteSpacesLINQ(input);
        }
    }
    [TestClass]
    public class CppRemoveWhiteSpaceTest : RemoveWhiteSpaceBaseTest
    {
        protected override string RemoveAdditionalWhiteSpace(string input)
        {
            return RegexSpeedupFoitn.RemoveAdditionalWhiteSpace.ReplaceWhiteSpacesCpp(input);
        }
    }
}