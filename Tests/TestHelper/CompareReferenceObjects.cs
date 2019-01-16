using KellermanSoftware.CompareNetObjects;

namespace TestHelper
{
    public static class CompareReferenceObjects
    {
        private static readonly CompareLogic CompareLogic = new CompareLogic();

        public static bool Compare<T>(T expected, T actual)
        {
            var comparisonResult = CompareLogic.Compare(expected, actual);

            return comparisonResult.AreEqual;
        }

        public static void Assert<T>(T expected, T actual)
        {
            var comparisonResult = CompareLogic.Compare(expected, actual);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(comparisonResult.AreEqual,comparisonResult.DifferencesString, comparisonResult.Differences);
        }
    }
}
