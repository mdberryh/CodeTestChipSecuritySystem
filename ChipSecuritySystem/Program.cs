using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    class Program
    {
        static void Main(string[] args)
        {

            List<ColorChip> colorChips = new List<ColorChip>();

            // let's create the example given...


            //[Blue, Yellow]
            //[Red, Green]
            //[Yellow, Red]
            //[Orange, Purple]

            colorChips.Add(new ColorChip(Color.Blue, Color.Yellow));
            colorChips.Add(new ColorChip(Color.Blue, Color.Green));
            colorChips.Add(new ColorChip(Color.Red, Color.Green));
            colorChips.Add(new ColorChip(Color.Yellow, Color.Red));
            colorChips.Add(new ColorChip(Color.Orange, Color.Purple));
            SecApp secApp = new SecApp();
            List<ColorChip> returnChipsPath = secApp.GetValidChain(colorChips);


            // NOTE: this is just a rough example to show something can run.
            //       there are more scenarios in the unit tests.
            if (returnChipsPath == null || returnChipsPath.Count == 0)
            {
                Console.WriteLine(Constants.ErrorMessage);
            }
            else
            {
                Console.WriteLine("Found the path: ");

                for ( int i =0; i< returnChipsPath.Count; i++)
                {
                    Console.Write(returnChipsPath.ElementAt(i).ToString());
                    Console.Write(" "); // just to separate it so each element so it looks nice.
                }
            }


        }


    }


    public class SecApp
    {

        /// <summary>
        /// Finds the list that uses the most chips and returns it.
        /// </summary>
        /// <param name="chips">the list of chips to use.</param>
        /// <returns>The chips needed to pass. If empty we have a failure and are unable to complete the path.</returns>
        public List<ColorChip> GetValidChain(List<ColorChip> chips)
        {

            List<ColorChip> colorChips = GetChain(chips, Color.Blue, Color.Green);

            bool haveValidChain = colorChips != null && colorChips.Count > 0 && colorChips.Last().EndColor == Color.Green;

            if (haveValidChain)
            {
                return colorChips;
            } else
            {
                return new List<ColorChip>();
            }

        }

        /// <summary>
        /// Using recurssion we can get every possible chain. The goal is to filter for the longest.
        /// </summary>
        /// <param name="chips">A list of all chips we have available</param>
        /// <param name="colorWeNeedToStart">The color we have to have to form a link.</param>
        /// <param name="colorWeNeedToEndAt">only used as a last filtering option</param>
        /// <returns>The list of elements in this chain.</returns>
        private List<ColorChip> GetChain(List<ColorChip> chips, Color colorWeNeedToStart, Color colorWeNeedToEndAt) {
            //simply build a list of all combinations...
            // I can then grab the ones that end in the right color and get the highest length.
            // for round 1 we need blue, so get all blue starting chips each blue we get is a possible path.
            // the remaining chips list are what we'll have to call this function with again.


            if (chips.Count == 0) return null;

            List<ColorChip> startChips = chips.Where(x => x.StartColor == colorWeNeedToStart).ToList();

            if (startChips.Count == 0)
            {
                // there are no more options we can use to continue this chain.
                return null;
            }

            List<List<ColorChip>> availableChains = new List<List<ColorChip>>();


            foreach (ColorChip ch in startChips)
            {

                List<ColorChip> currentList = new List<ColorChip>();

                currentList.Add(ch); // always add the current into out list then append the rest

                // the next options should contain all chips except the current one.
                // this allows us to take all possible paths.
                List<ColorChip> remainingChips = chips.Where(x => x != ch).ToList();
                if (!remainingChips.Any())
                {
                    // append what we have this is it...
                    return currentList;

                }


                List<ColorChip> subchain = GetChain(remainingChips, ch.EndColor, colorWeNeedToEndAt);

                if (subchain != null)
                {
                    currentList.AddRange(subchain);
                }
                
                availableChains.Add(currentList);
            }


            // Select the best route we have so far.
            if (availableChains.Count == 1) {
                // obviously we only found one path.
                return availableChains.First();
            }
            else
            {
                // we need to decide which path we want, so let's pick the longest...
                return availableChains.Where(x => x.Count == availableChains.Max(y=> y.Count) && x.Last().EndColor == colorWeNeedToEndAt).First();
            }
        
            
        
        } 
    }


}
