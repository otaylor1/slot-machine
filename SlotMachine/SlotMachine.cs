using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class SlotMachine
    {


        public int IconsPerSlot { get; set; }
        public int MinimumBet { get; set; }
        public int MaximumBet { get; set; }

        private int _numberOfSlots;
        public int NumberOfSlots
        {
            get
            {
                return _numberOfSlots;
            }
            set
            {
                _numberOfSlots = value;
                icons = new int[_numberOfSlots];
            }
        }
        private Random randomNumberGenerator;
        private int _currentBet;
        public int CurrentBet
        {
            get
            {
                return _currentBet;
            }
            set
            {
                _currentBet = value;

                if (_currentBet < MinimumBet)
                {
                    _currentBet = MinimumBet;
                }
                if (_currentBet > MaximumBet)
                {
                    _currentBet = MaximumBet;
                }
            }
        }

        /// <summary>
        /// An array of integers that is as long as the number of slots,
        /// with each element of the array representing a different slot
        /// </summary>
        private int[] icons;


        public SlotMachine()
        {
            NumberOfSlots = 3;
            IconsPerSlot = 5;
            MinimumBet = 1;
            MaximumBet = 100;

            randomNumberGenerator = new Random();
        }


        /// <summary>
        /// Randomizes the contents of the icons
        /// </summary>
        public void PullLever()
        {
            // TODO


            for (int i = 0; i < icons.Length; i++)
            {
                icons[i] = randomNumberGenerator.Next(IconsPerSlot) + 1;
            }

        }

        /// <summary>
        /// Return the results from the slots
        /// </summary>
        /// <returns>an int[] with each slot as an element of the array</returns>
        public int[] GetResults()
        {
            // TODO
            return icons;
        }

        /// <summary>
        /// Examine the contents of the slots and determine the appropriate payout
        /// based upon the CurrentBet.
        /// </summary>
        /// <returns>number of pennies to pay out</returns>
        public int GetPayout()
        {
            // TODO
            bool matches = false;
            int tempMatchingNumber = icons[0];

            for (int i = 1; i < icons.Length; i++)
            {
                if (icons[i] != tempMatchingNumber)
                {
                    break;
                }
                if (i == NumberOfSlots - 1)
                {
                    matches = true;
                }
            }
            if (matches)
            {
                return (CurrentBet * tempMatchingNumber * NumberOfSlots * 10);
            }
            else
            {
                return (0);
            }
        }
    }
}

