using ChipSecuritySystem;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DefaultSituationGivenPass()
        {

            List<ColorChip> colorChips = new List<ColorChip>();

            ColorChip first = new ColorChip(Color.Blue, Color.Yellow);
            ColorChip second = new ColorChip(Color.Yellow, Color.Red);
            ColorChip third = new ColorChip(Color.Orange, Color.Purple);
            ColorChip last = new ColorChip(Color.Red, Color.Green);

            colorChips.Add(first);
            colorChips.Add(last);
            colorChips.Add(second);
            colorChips.Add(third);

            SecApp secApp = new SecApp();
            List<ColorChip> result = secApp.GetValidChain(colorChips);


            Assert.AreEqual(result.Count(), 3);

            Assert.AreEqual(result.First(), first);
            Assert.AreEqual(result.ElementAt(1), second);
            Assert.AreEqual(result.Last(), last);



        }
        [TestMethod]
        public void DefaultSituationGivenDifferentOrderPass()
        {

            List<ColorChip> colorChips = new List<ColorChip>();

            ColorChip first = new ColorChip(Color.Blue, Color.Yellow);
            ColorChip second = new ColorChip(Color.Yellow, Color.Red);
            ColorChip third = new ColorChip(Color.Orange, Color.Purple);
            ColorChip last = new ColorChip(Color.Red, Color.Green);

            colorChips.Add(last);
            colorChips.Add(second);
            colorChips.Add(first);
            colorChips.Add(third);

            SecApp secApp = new SecApp();
            List<ColorChip> result = secApp.GetValidChain(colorChips);


            Assert.AreEqual(result.Count(), 3);

            Assert.AreEqual(result.First(), first);
            Assert.AreEqual(result.ElementAt(1), second);
            Assert.AreEqual(result.Last(), last);



        }
        [TestMethod]
        public void DefaultSituationNoLeftOversPass()
        {

            List<ColorChip> colorChips = new List<ColorChip>();

            ColorChip first = new ColorChip(Color.Blue, Color.Yellow);
            ColorChip second = new ColorChip(Color.Yellow, Color.Red);
            ColorChip last = new ColorChip(Color.Red, Color.Green);

            colorChips.Add(first);
            colorChips.Add(last);
            colorChips.Add(second);

            SecApp secApp = new SecApp();
            List<ColorChip> result = secApp.GetValidChain(colorChips);


            Assert.AreEqual(3, result.Count());

            Assert.AreEqual(result.First(), first);
            Assert.AreEqual(result.ElementAt(1), second);
            Assert.AreEqual(result.Last(), last);



        }

        [TestMethod]
        public void DupStartNodePass()
        {

            List<ColorChip> colorChips = new List<ColorChip>();

            ColorChip first = new ColorChip(Color.Blue, Color.Yellow);
            ColorChip second = new ColorChip(Color.Yellow, Color.Red);
            ColorChip third = new ColorChip(Color.Blue, Color.Yellow);
            ColorChip last = new ColorChip(Color.Red, Color.Green);

            colorChips.Add(first);
            colorChips.Add(new ColorChip(Color.Blue, Color.Green));
            colorChips.Add(new ColorChip(Color.Blue, Color.Yellow));
            colorChips.Add(last);
            colorChips.Add(second);
            colorChips.Add(new ColorChip(Color.Orange, Color.Purple));
            SecApp secApp = new SecApp();
            List<ColorChip> result = secApp.GetValidChain(colorChips);


            Assert.AreEqual(result.Count(), 3);

            Assert.AreEqual(result.First(), first);
            Assert.AreEqual(result.ElementAt(1), second);
            Assert.AreEqual(result.Last(), last);



        }
        [TestMethod]
        public void DupStartNodeDifferentOrderPass()
        {

            List<ColorChip> colorChips = new List<ColorChip>();

            ColorChip first = new ColorChip(Color.Blue, Color.Yellow);
            ColorChip second = new ColorChip(Color.Yellow, Color.Red);
            ColorChip third = new ColorChip(Color.Blue, Color.Red);
            ColorChip last = new ColorChip(Color.Red, Color.Green);

            colorChips.Add(third);
            colorChips.Add(first);
            colorChips.Add(last);
            colorChips.Add(second);
            colorChips.Add(new ColorChip(Color.Orange, Color.Purple));
            SecApp secApp = new SecApp();
            List<ColorChip> result = secApp.GetValidChain(colorChips);


            Assert.AreEqual(result.Count(), 3);

            Assert.AreEqual(result.First(), first);
            Assert.AreEqual(result.ElementAt(1), second);
            Assert.AreEqual(result.Last(), last);



        }
        [TestMethod]
        public void DupEndNode()
        {

            List<ColorChip> colorChips = new List<ColorChip>();

            ColorChip first = new ColorChip(Color.Blue, Color.Yellow);
            ColorChip second = new ColorChip(Color.Yellow, Color.Red);
            ColorChip third = new ColorChip(Color.Orange, Color.Purple);
            ColorChip last = new ColorChip(Color.Red, Color.Green);

            colorChips.Add(first);
            colorChips.Add(last);
            colorChips.Add(second);
            colorChips.Add(third);
            colorChips.Add(new ColorChip(Color.Red, Color.Green));

            SecApp secApp = new SecApp();
            List<ColorChip> result = secApp.GetValidChain(colorChips);


            Assert.AreEqual(result.Count(), 3);

            Assert.AreEqual(result.First(), first);
            Assert.AreEqual(result.ElementAt(1), second);
            Assert.AreEqual(result.Last(), last);



        }
        [TestMethod]
        public void DupMidNode()
        {

            List<ColorChip> colorChips = new List<ColorChip>();

            ColorChip first = new ColorChip(Color.Blue, Color.Yellow);
            ColorChip second = new ColorChip(Color.Yellow, Color.Red);
            ColorChip third = new ColorChip(Color.Orange, Color.Purple);
            ColorChip last = new ColorChip(Color.Red, Color.Green);

            colorChips.Add(first);
            colorChips.Add(last);
            colorChips.Add(second);
            colorChips.Add(third);
            colorChips.Add(new ColorChip(Color.Yellow, Color.Red));

            SecApp secApp = new SecApp();
            List<ColorChip> result = secApp.GetValidChain(colorChips);


            Assert.AreEqual(result.Count(), 3);

            Assert.AreEqual(result.First(), first);
            Assert.AreEqual(result.ElementAt(1), second);
            Assert.AreEqual(result.Last(), last);



        }


        [TestMethod]
        public void LongAndShortOptionPass()
        {

            List<ColorChip> colorChips = new List<ColorChip>();

            ColorChip first = new ColorChip(Color.Blue, Color.Yellow);
            ColorChip second = new ColorChip(Color.Yellow, Color.Red);
            ColorChip third = new ColorChip(Color.Blue, Color.Red);
            ColorChip last = new ColorChip(Color.Red, Color.Green);

            colorChips.Add(first);
            colorChips.Add(new ColorChip(Color.Blue, Color.Green));
            colorChips.Add(new ColorChip(Color.Blue, Color.Yellow));
            colorChips.Add(last);
            colorChips.Add(second);
            colorChips.Add(third);
            colorChips.Add(new ColorChip(Color.Orange, Color.Purple));
            SecApp secApp = new SecApp();
            List<ColorChip> result = secApp.GetValidChain(colorChips);


            Assert.AreEqual(result.Count(), 3);

            Assert.AreEqual(result.First(), first);
            Assert.AreEqual(result.ElementAt(1), second);
            Assert.AreEqual(result.Last(), last);



        }

        [TestMethod]
        public void NoValidCombinationPass()
        {

            List<ColorChip> colorChips = new List<ColorChip>();

            ColorChip first = new ColorChip(Color.Blue, Color.Yellow);
            //ColorChip second = new ColorChip(Color.Yellow, Color.Red);
            ColorChip last = new ColorChip(Color.Red, Color.Green);

            colorChips.Add(first);
            colorChips.Add(last);
            //colorChips.Add(second);
            colorChips.Add(new ColorChip(Color.Orange, Color.Purple));
            SecApp secApp = new SecApp();
            List<ColorChip> result = secApp.GetValidChain(colorChips);


            Assert.AreEqual(result.Count(), 0);


        }

    }
}