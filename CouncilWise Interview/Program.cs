using System;
using System.Collections.Generic;

namespace CouncilWise
{
    /*	
    Requirements:

    - Given a list of receipt items where TaxAmount is not populated, calculate the correct tax for each receipt item. If IncludesGST is true, the unit price contains tax already. (In this case you will need to divide by 11 to get the tax amount). 
        If includesGST is false, the unit price does not contain tax and you will need to calculate it (multiply by 0.1 for tax amount). 
    - Return a populated Receipt object which contains the receipt items including tax amounts with the correct totals.
        Note that all totals shown on the receipt should be tax inclusive, including the receipt item totals.
    - For bonus points, if the receipt item name is a palindrome, the receipt item unit price should be changed to free. 
        A palindrome is a string which reads the same way forwards and backwards
    - You may modify the Receipt ReceiptItem and Helper classes any way you like as well as add new classes, but you must call the ProcessReceiptItems() method and the Receipt.ToString() method in your test case and no other methods.
    - 
    - Add additional test cases to cover any edge cases you can think of

    Expected Output:

    Print a receipt to the console with the following format:

    Receipt:
	    Items:
	    <Name>
		    <Quantity>		<UnitPrice>		<Total inc. Tax>
	    <Name>			
		    <Quantity>		<UnitPrice>		<Total inc. Tax>
	    ... for all receipt items
    Total:	<Total inc. Tax>
    GST:	<TaxTotal>

    */

    public class Program
    {
        static void Main(string[] args)
        {
            RunTestCases();
        }

        /// <summary>
        /// Run through some possible scenarios for processing receipt items
        /// </summary>
        static void RunTestCases()
        {
            var items = new List<ReceiptItem>();
            items.Add(new ReceiptItem { Name = "Bouncy Ball", Quantity = 4, UnitPrice = 1.15m, IncludesTax = true });
            items.Add(new ReceiptItem { Name = "Doll's House", Quantity = 1, UnitPrice = 213.99m, IncludesTax = true });
            items.Add(new ReceiptItem { Name = "In-store assist hrs", Quantity = 2, UnitPrice = 25.30m, IncludesTax = false });
            var receiptResult = ProcessReceiptItems(items);
            Console.WriteLine(receiptResult.ToString());

            items = new List<ReceiptItem>();
            items.Add(new ReceiptItem { Name = "freebie eibeerf", Quantity = 4, UnitPrice = 1.15m, IncludesTax = true });
            items.Add(new ReceiptItem { Name = "not a freebie", Quantity = 4, UnitPrice = 1.15m, IncludesTax = true });
            items.Add(new ReceiptItem { Name = "racecar", Quantity = 4, UnitPrice = 1.15m, IncludesTax = true });
            receiptResult = ProcessReceiptItems(items);
            Console.WriteLine(receiptResult.ToString());

            // TODO: Add more test cases here to capture any edge cases you can think of 
        }

        /// <summary>
        /// Process a list of receipt items to ensure correct tax is allocated
        /// </summary>
        /// <param name="items"></param>
        /// <returns>processed receipt</returns>
        static Receipt ProcessReceiptItems(ICollection<ReceiptItem> items)
        {
            var receipt = new Receipt();

            foreach (ReceiptItem item in items)
            {
                //Console.WriteLine("{0}\t{1}\t{2}", item.Name.ToString(), item.Quantity.ToString(), item.UnitPrice.ToString());
                if(CheckIfPalindrome(item.Name))
                {
                    receipt.Total += 0;
                }
                else if(item.IncludesTax == true)
                {
                    receipt.Total += item.UnitPrice * 1.1m;
                    receipt.TaxTotal += item.UnitPrice * 0.1m;
                }
                else if (item.IncludesTax == false)
                {
                    receipt.Total += item.UnitPrice;
                }

                Console.WriteLine(/*Item details as per spec*/);
            }

            Console.WriteLine("Total:\t{0}\nGST:\t{1}", Helper.CurrencyRound(receipt.Total), Helper.CurrencyRound(receipt.TaxTotal));

            return receipt;
        }

        public static bool CheckIfPalindrome(string itemName)
        {
            string reversedItemName = string.Empty;

            for (int i = itemName.Length - 1; i >= 0; i--)
            {
                reversedItemName += itemName[i].ToString();
            }
            if (reversedItemName == itemName)
            {
                return true;
            }

            return false;
        }
    }
}
