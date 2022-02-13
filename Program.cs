/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK
*/

using System;
using System.Collections.Generic;
using System.Linq;///for List
using System.Collections;//for Stack
using System.Text;

namespace ISM6225_Assignment_2_Spring_2022
{

    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.Write("Most frequent word is : ");
            Console.WriteLine(commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 3, 3, 4, 4, 4, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.Write("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 4, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "bbbcccdddaaa";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int k = 0;
                int j = nums.Length - 1;
                int sol = -1;
                while (k <= j)
                {   // to search any binary element
                    // to get the centre element
                    int cen = (k + j) / 2;
                    //the centre value equals the given target element
                    if (nums[cen] == target) return cen;
                    //given target value is lesser than the centre value
                    if (nums[cen] > target)
                    {           
                        j = cen - 1;
                        sol = cen;
                    }
                    else
                    {
                        k = cen + 1;
                        sol = cen + 1;
                    }
                }

                return sol;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned.
        It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.
        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the 
        most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), 
        and that "hit" isn't the answer even though it occurs more because it is banned.
        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */
        public static string change_to_small(string s)
        {//function for converting word in lowercase
            return s.ToLower();
        }
        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                Console.WriteLine(paragraph);
                // Dictionary creation for mapping purpose
                Dictionary<string, int> ban = new Dictionary<string, int>(); 
                string tempvar = "";
                for (int k = 0; k < paragraph.Length; k++)
                {   //visit every character and checking 
                    //ignoring character for the elemenation purpose
                    if (paragraph[k] == ',') continue;                         
                    if (paragraph[k] == ' ' || paragraph[k] == '.')
                    {   //obtain the word in the temperory variable if condition is satisfied
                        string new_string = change_to_small(tempvar);   //this function changes every character to its lowercase version
                        if (ban.ContainsKey(new_string))
                        { //increments the value if it got the word
                            ban[new_string] = ban[new_string] + 1;        
                        }
                        else //if not satisfied inputs new value for mapping
                        {
                            ban[new_string] = 1;                           
                        }
                        tempvar = "";
                    }
                    else
                    {
                        tempvar = tempvar + paragraph[k];
                    }
                }
                for (int j = 0; j < banned.Length; j++)
                {   //iterating for removing the banned word
                    if (ban.ContainsKey(change_to_small(banned[j])))
                    {
                        ban[change_to_small(banned[j])] = 0;
                    }
                }
                var val = ban.Keys.ToList();
                int mfreq = 0;
                string ans = "";
                foreach (var key in val)
                {   //to get the frequently repeating word
                    if (ban[key] > mfreq)
                    {
                        mfreq = ban[key];
                        ans = key;
                    }
                }

                return ans;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {   //creating dictionary for mapping
                Dictionary<int, int> luckdig = new Dictionary<int, int>();
     
                foreach (var element in arr)
                {  //To map the element and its frequency, performing the array iterations
                    if (luckdig.ContainsKey(element))
                    {
                        luckdig[element] = luckdig[element] + 1;
                    }
                    else
                    {
                        luckdig[element] = 1;
                    }
                }
                var uni = luckdig.Keys.ToList();
                int sol = -1;
                foreach (var key in uni)
                {   //condition for lucky dig
                    if (luckdig[key] == key)
                    {
                        sol = (Math.Max(sol, key));
                    }
                }
                return sol;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your frie
        nd to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
        
          |
        "7810"
        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                int l = 0;
                int m = 0;
                bool[] simdig = new bool[secret.Length];
                Dictionary<char, int> dic = new Dictionary<char, int>();
                for (int k = 0; k < secret.Length; k++)
                {   //performing iteration on the string "secret"
                    if (secret[k] == guess[k])
                    {   // element matches incremental value A
                        l++;
                        simdig[k] = true;
                        
                    }
                    else
                    {
                        simdig[k] = false;  //assigning the false for going to loop again
                        if (dic.ContainsKey(secret[k]))
                        {                   
                            dic[secret[k]] = dic[secret[k]] + 1;
                        }
                        else
                        {
                            dic[secret[k]] = 1;   
                            //creation of map if not found
                        }
                    }
                }
                
                for (int j = 0; j < guess.Length; j++)
                {                   //iterations start
                    //elements that are assignes to true are ignored
                    if (simdig[j]) continue; 
                    if (dic.ContainsKey(guess[j]) && dic[guess[j]] > 0)
                    {
                        m++;
                        dic[guess[j]] = dic[guess[j]] - 1;
                    }
                }
                string ans = l + "A" + m + "B"; 
                return ans;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.
        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                int length = s.Length;
                List<int> result = new List<int>();
                int[] part = new int[26];
                for (int i = length - 1; i >= 0; i--)
                {
                    if (part[s[i] - 97] == 0)
                    {
                        part[s[i] - 97] = i;
                    }
                }

                int index = 0;
                while (index < length)
                {
                    int low = index;
                    int hi = part[s[index] - 97];
                    int diff = hi - low + 1;
                    for (int j = low; j <= hi; j++)
                    {
                        if (part[s[j] - 97] > hi)
                        {
                            hi = part[s[j] - 97];
                            diff = hi - low + 1;
                        }
                    }

                    result.Add(diff);
                    index = hi + 1;
                }


                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6
        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, 
        widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters 
        on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you 
        can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.
         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.
         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                int ln = 1;
                int pix = 0;
                for (int k = 0; k < s.Length; k++)
                {   // full character loop
                    //getting the index value to get ascii value and substring
                    int r = s[k] - 97; 
                    
                    if (pix + widths[r] <= 100)
                    {   //check if current line overflow
                        pix = pix + widths[r];   //if  not then fill current line pixel
                    }
                    else
                    {   //initialising pix to zero
                        pix = 0;
                        //addition of width to pix
                        pix = pix + widths[r];    
                        ln++;                                 
                    }
                }//to get the format of ans creating a new string
                List<int> ans = new List<int>();                
                ans.Add(ln);
                ans.Add(pix);
                return ans;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*
        
        Question 7:
        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true
        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true
        Example 3:
        Input: bulls_string  = "(]"
        Output: false
        */

        public static bool IsValid(string bulls_string10)
        {

            try
            {
                Stack<char> st = new Stack<char>();
                for (int k = 0; k < bulls_string10.Length; k++)
                {   //iteration starts
                    if (bulls_string10[k] == '(' || bulls_string10[k] == '{' || bulls_string10[k] == '[')
                    {  //push command to push into stack if opening occurs
                        st.Push(bulls_string10[k]);
                    }
                    if (bulls_string10[k] == ')' || bulls_string10[k] == '}' || bulls_string10[k] == ']')
                    {   //pop command to pop into stack if closing occurs
                        if (st.Count <= 0)
                        {
                            return false;
                        }
                        if (bulls_string10[k] == ')')
                        {
                            if (st.Peek() == '(')
                            {
                                st.Pop();
                            }
                            else
                            {

                                return false;
                            }
                        }
                        if (bulls_string10[k] == '}')
                        {
                            if (st.Peek() == '{')
                            {
                                st.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        if (bulls_string10[k] == ']')
                        {
                            if (st.Peek() == '[')
                            {
                                st.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }

                    }
                }

                return true;

            }
            catch (Exception)
            {
                throw;
            }


        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.
        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation 
            the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".
        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                
                string[] mor = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };

                HashSet<string> morset = new HashSet<string>();

                //iteration starts
                for (int k = 0; k < words.Length; k++)
                {
                    var sb = new StringBuilder();
                    foreach (var ch in words[k])
                    {
                        sb.Append(mor[ch - 'a']);
                    }
                    morset.Add(sb.ToString());
                }
                return morset.Count();
            }
            catch (Exception)
            {
                throw;
            }

        }




        /*
            
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally 
        adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time.
        Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).
        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.
        */
        public static int findpath(int[,] grid, int i, int j, bool[,] path)
        {

            int cl1 = grid.GetLength(0);
            int rw1 = grid.Length / grid.GetLength(0);
            if (i >= rw1 || j >= cl1 || i < 0 || j < 0) return 0;
            int soln1,soln2,soln3, soln4;
            if (path[i, j])
            {
                path[i, j] = false;
                // towards rightside //
                soln1 = Math.Max(grid[i, j], findpath(grid, i, j + 1, path));
                // towards downside //
                soln2 = Math.Max(grid[i, j], findpath(grid, i + 1, j, path));
                // towards topside //
                soln3 = Math.Max(grid[i, j], findpath(grid, i - 1, j, path));
                // towards leftside //
                soln4 = Math.Max(grid[i, j], findpath(grid, i, j - 1, path));
            }
            else
            {
                return 0;
            }

            return Math.Max(Math.Max(soln1, soln2), Math.Max(soln3, soln4));

        }
        public static int SwimInWater(int[,] grid)
        {
            try
            {
                bool[,] path = { { true, true, true, true, true }, { true, true, true, true, true }, { true, true, true, true, true }, { true, true, true, true, true }, { true, true, true, true, true } };
                return findpath(grid, 0, 0, path);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:
        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.
        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')
        */
        public static int dfs(string word1, string word2, Dictionary<string, int> memo)
        {
            if (word1 == word2) return 0;
            if (word1 == "") return word2.Length;
            if (word2 == "") return word1.Length;

            string key = word1 + "#" + word2;
            if (memo.ContainsKey(key)) return memo[key];

            string str1 = (word1.Length > 1) ? word1.Substring(1) : "";
            string str2 = (word2.Length > 1) ? word2.Substring(1) : "";

            if (word1[0] == word2[0])
            {
                int ops = dfs(str1, str2, memo);
                memo.Add(key, ops);
            }
            else
            {
                int insert = 1 + dfs(word2[0] + word1, word2, memo);
                int delete = 1 + dfs(str1, word2, memo);
                int replace = 1 + dfs(str1, str2, memo);
                int ops = Math.Min(insert, Math.Min(delete, replace));
                memo.Add(key, ops);
            }
            return memo[key];
        }
        public static int MinDistance(string word1, string word2)
        {
            try
            {
                return dfs(word1, word2, new Dictionary<string, int>());

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}


