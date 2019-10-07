/*
The Universal Product Code (UPC-A) is a bar code used in many parts of the world. The bars encode a 12-digit number used to identify a product for sale, for example:

042100005264

The 12th digit (4 in this case) is a redundant check digit, used to catch errors. Using some simple calculations, a scanner can determine, given the first 11 digits, what the check digit must be for a valid code. (Check digits have previously appeared in this subreddit: see Intermediate 30 and Easy 197.) UPC's check digit is calculated as follows (taken from Wikipedia):

    Sum the digits at odd-numbered positions (1st, 3rd, 5th, ..., 11th). If you use 0-based indexing, this is the even-numbered positions (0th, 2nd, 4th, ... 10th).

    Multiply the result from step 1 by 3.

    Take the sum of digits at even-numbered positions (2nd, 4th, 6th, ..., 10th) in the original number, and add this sum to the result from step 2.

    Find the result from step 3 modulo 10 (i.e. the remainder, when divided by 10) and call it M.

    If M is 0, then the check digit is 0; otherwise the check digit is 10 - M.
*/

public class UPCValidator{
  
  public int checkDigit(long UPC){
    int oddSum = 0, evenSum = 0, digit, step;
    long tempUPC = UPC;

    for (int i = 11; i >= 0; i--){
      if ( i % 2 == 0){
        evenSum += (int)(tempUPC % 10);
      } else {
        oddSum += (int) (tempUPC % 10);
      }
      tempUPC /= 10;
    }
  
    step = ((3*oddSum) + evenSum);
    if (step % 10 == 0){
      digit = 0;
    } else {
      digit = 10 - (step % 10);
    }
    return digit;
  }

   public static void Main (string[] args) {
    UPCValidator upcValidator = new UPCValidator();
    System.Console.WriteLine("Please enter the first 11 digits of an UPC number to validate:");
    string input = System.Console.ReadLine();
    long UPCNumber = System.Convert.ToInt64(input);
    int checkDigit = upcValidator.checkDigit(UPCNumber);
    System.Console.WriteLine("The full UPC number is " + UPCNumber+checkDigit +".");
  }

}