/*
Solution 1:
Time: O(log10​n) becuase we divide the number by 10 in each recursive call
Space: O(log10​n)
 
*/

class Solution 
{
    private string[] singleDigits = ["", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"];
    private string[] doubleDigits = ["", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"];
    
    public string NumberToWords(int num) 
    {
        if (num == 0) return "Zero";
        return ConvertToWords(num).Trim();
    }
    
    private string ConvertToWords(int num) 
    {
        if (num >= 1000000000) return ConvertToWords(num / 1000000000) + " Billion " + ConvertToWords(num % 1000000000);
        else if (num >= 1000000) return ConvertToWords(num / 1000000) + " Million " + ConvertToWords(num % 1000000);
        else if (num >= 1000) return ConvertToWords(num / 1000) + " Thousand " + ConvertToWords(num % 1000);
        else if (num >= 100) return (ConvertToWords(num / 100) + " Hundred " + ConvertToWords(num % 100)).Trim();
        else if (num >= 20) return (doubleDigits[num / 10] + " " + ConvertToWords(num % 10)).Trim();
        else return singleDigits[num];
    }
}

/*
Solution 2
*/
public class Solution {
public  string NumberToWords(int num) {
    if (num == 0) return "Zero";

    string[] ones = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
    string[] teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
    string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

    string words = "";
    int count = 0;

    while (num > 0) {
        if (num % 1000 != 0) {
            string segmentWords = ConvertSegmentToWords(num % 1000, ones, teens, tens);
            if (!string.IsNullOrEmpty(segmentWords)) {
                words = segmentWords + GetMagnitude(count) + " " + words;
            }
        }
        num /= 1000;
        count++;
    }

    return words.Trim();
}

private  string ConvertSegmentToWords(int num, string[] ones, string[] teens, string[] tens) {
    if (num == 0) return "";

    string words = "";

    if (num >= 100) {
        words += ones[num / 100] + " Hundred ";
        num %= 100;
    }

    if (num >= 20) {
        words += tens[num / 10] + " ";
        num %= 10;
    }

    if (num > 0 && num < 10) {
        words += ones[num] + " ";
    }
    else if (num >= 10 && num <= 19) {
        words += teens[num - 10] + " ";
    }

    return words.Trim();
}

private  string GetMagnitude(int count) {
    switch (count) {
        case 1:
            return " Thousand";
        case 2:
            return " Million";
        case 3:
            return " Billion";
        default:
            return "";
    }
}
}
