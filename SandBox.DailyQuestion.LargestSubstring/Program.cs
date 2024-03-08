// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Data.SqlTypes;

Console.WriteLine("Hello, World!");

//Given a string s, return the length of the longest substring between two equal characters,
//excluding the two characters. If there is no such substring return -1.

//A substring is a contiguous sequence of characters within a string. 

//Example 1:

//Input: s = "aa"
//Output: 0
//Explanation: The optimal substring here is an empty substring between the two 'a's.

//Example 2:

//Input: s = "abca"
//Output: 2
//Explanation: The optimal substring here is "bc".

//Example 3:

//Input: s = "cbzxy"
//Output: -1
//Explanation: There are no characters that appear twice in s.
MaxLengthBetweenEqualCharacters("cabbac");
Char("cabbac", true);
static int MaxLengthBetweenEqualCharacters(string s)
{

    Dictionary<string, int> starts = new Dictionary<string, int>();
    Dictionary<string, int> ends = new Dictionary<string, int>();
    HashSet<string> chars = new HashSet<string>();

    for (int i = 0; i < s.Length; i++)
    {
        chars.Add(s[i].ToString());
    }

    for (int i = 0; i < s.Length; i++)
    {
        if (!starts.ContainsKey(s[i].ToString()))
        {
            starts.Add(s[i].ToString(), i);
            ends.Add(s[i].ToString(), i);
        }
        else
        {
            ends[s[i].ToString()] = i;
        }
    }

    int result = -1;
    foreach (var c in chars)
    {
        if (starts[c] == ends[c]) continue;

        if (Math.Abs(starts[c] - ends[c]) == 1 && result <= 0)
        {
            result = 0;
            continue;
        }

        int length = ends[c] - starts[c] - 1;
        if (length > result)
        {
            result = length;
        }
    }

    return result;
}

static int Char(string s, bool a)
{
    Dictionary<string, int> firstIndex = new Dictionary<string, int>();
    int ans = -1;

    for (int i = 0; i < s.Length; i++)
    {
        if (firstIndex.ContainsKey(s[i].ToString()))
        {
            ans = Math.Max(ans, i - firstIndex.GetValueOrDefault(s[i].ToString()) - 1);
        }
        else
        {
            firstIndex.Add(s[i].ToString(), i);
        }
    }

    return ans;
}