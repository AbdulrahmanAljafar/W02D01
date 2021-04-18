using System;

namespace ConsoleApp4
{

    class MatchOutput
    {
        public bool isMatched;
        public int matchedNum;
        public string msg;
        public int maxDepth;
    }
    class Program
    {

        class searchable
        {
            string value;
            
            public searchable (string value)
            {
                this.value = value;
            }

            public int numofchars()
            {
                return value.Length;
            }

            public int numofwords()
            {
                int count = 1;
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == ' ' || value[i] == '\n' || value[i] == '\t')
                    {
                        count++;
                    }
                }
                return count;
            }

            public int numofXword(string word)
            {
                int count1 = 0;
                
                string[] words = value.Split(' ');
                foreach ( var a in words)
                {
                    if(a == word)
                    {
                        count1++;
                    }
                }
                
                return count1;
            }

            public int numofXchar(char c)
            {
                int count1 = 0;

                for(int i = 0; i < value.Length; i++)
                {
                    if(value[i] == c)
                    {
                        count1++;
                    }
                }

                return count1;
            }

            public int lastIndex(char c)
            {
               
                int lastindex = 0;

                for (int i = 0; i < value.Length; i++)
                {
                   
                    if (value[i] == c)
                    {
                        lastindex = i;
                    }
                }

                return lastindex;
            }


            public string mostrepet()
            {
                int count = 0;
                int max = 0;
                string mostrep = "";

                string[] words = value.Split(' ');
                  for (int i = 0; i < words.Length; i++)
                  {
                    for (int j = 0; j < words.Length; j++) // dog dog cat cat cat
                    {
                        if (words[i] == (words[j]))
                        {
                            count++;

                        }
   
                }

                    if (count > max)
                    {

                        mostrep = words[i];
                        max = count;

                    }
                    count = 0;


                }
                return mostrep;

            }


            public void swap()
            {
                int count = 0;
                int max = 0;
                

                string[] words = value.Split(' ');
                string[] swapword = new string[words.Length];

                for (int i = 0; i < words.Length; i+=2)
                {
                    if(i+1 == words.Length)
                    {
                        break;
                    }
                    swapword[i] = words[i + 1];
                    swapword[i + 1] = words[i];


                }

                for (int j = 0; j < swapword.Length; j++)
                {
                    Console.Write(swapword[j] +" ");


                }


            }

        }

        static MatchOutput match_(string source)
        {

            MatchOutput output = new MatchOutput();

            int unclosed = 0;
            int count = 0;
            int depth = 0;
            foreach (var ch in source)
            {
                if (ch == '{') unclosed++;
                else if (ch == '}')
                {
                    unclosed--;
                    count++;
                }
                if (unclosed < 0)
                {
                    count--;
                    output.isMatched = false;
                    output.matchedNum = count;
                    output.msg = "there's an extra }";
                    return output;
                }
                if (unclosed > depth)
                {
                    depth++;
                }

            }
            if (unclosed == 0)
            {
                output.isMatched = true;
                output.msg = "All is matched number";

            }
            else
            {
                output.isMatched = false;
                output.msg = "Not matched number";
            }
            output.matchedNum = count;
            output.maxDepth = depth;
            return output;




        }
        static bool match(string source,char start = '{',char end = '}')
        {
            bool match1 = true;
            int count = 0;
            for (int i = 0; i < source.Length; i++)
            {


            if (source[i] == start)
                {
                    count++;

                }

            else if (source[i] == end)
                {
                    count--;
                }


            if( count < 0)
                {
                    return false;
                }

            }
            if(count == 0)
            {
                match1 = true;
            }
            else
            {
                match1 = false;
            }
            return match1;
        }
        static void Main(string[] args)
        {

            //Console.WriteLine(match("{}{}"));
            //MatchOutput result = match_("{{{}}}{}{}");
           // Console.WriteLine("the string curly brackets is: {0} with {1} brackets, {2} with max depth of {3} ", result.isMatched ? "matched" : "not matched", result.matchedNum, result.msg, result.maxDepth);

            searchable word = new searchable("dog cat test test1  test3");
           Console.WriteLine(word.numofchars());
            Console.WriteLine("=============================");
            Console.WriteLine(word.numofwords());
            Console.WriteLine("=============================");
           Console.WriteLine(word.numofXword("to"));
            Console.WriteLine("=============================");
            Console.WriteLine(word.numofXchar('e'));
            Console.WriteLine("=============================");
            Console.WriteLine(word.lastIndex('c'));
            Console.WriteLine("=============================");
            Console.WriteLine(word.mostrepet());
            Console.WriteLine("=============================");
            word.swap();

        }
    }
}
