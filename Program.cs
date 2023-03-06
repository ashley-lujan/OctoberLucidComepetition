namespace Lucid
{
    internal class Program
    {
        private static void ReadInput(List<Tuple<int, int, int>> reefs, List<Tuple<int, int, int>> rocks)
        {
            string? con_line = Console.ReadLine();
            while (con_line != null)
            {
                string[] current = con_line.Split(' ');
                if (current[0] == "reef")
                {
                    int x = Int32.Parse(current[1]);
                    int y = Int32.Parse(current[2]);
                    int radius = Int32.Parse(current[3]);
                    reefs.Add(new Tuple<int, int, int>(x, y, radius));
                }
                else
                {
                    int x = Int32.Parse(current[1]);
                    int y = Int32.Parse(current[2]);
                    int radius = Int32.Parse(current[3]);
                    rocks.Add(new Tuple<int, int, int>(x, y, radius));
                }
                con_line = Console.ReadLine();
            }

        }

        private static double CountAll(List<Tuple<int, int, int>> counting)
        {
            double total = 0;
            foreach (Tuple<int, int, int> item in counting)
            {
                double area = (double)Math.PI * item.Item3 * item.Item3;
                total += area;
            }
            return total;
        }

        static void Main(string[] args)
        {
            string d_and_n = Console.ReadLine();
            List<Tuple<int, int, int>> all_reefs = new List<Tuple<int, int, int>>();
            List<Tuple<int, int, int>> all_rocks = new List<Tuple<int, int, int>>();
            ReadInput(all_reefs, all_rocks);

            string[] dn = d_and_n.Split(' ');
            int distance = Int32.Parse(dn[0]);
            int number = Int32.Parse(dn[1]);

            double sample_space = (double)Math.PI * distance * distance;
            double reef_space = CountAll(all_reefs);
            double rock_space = CountAll(all_rocks);

            double prop_of_reef = (double)reef_space / sample_space;
            double prop_of_rock = (double)rock_space / sample_space;
            double prop_thrown = (double)(prop_of_reef + (Math.Pow(prop_of_rock, 3)) + (prop_of_rock * prop_of_reef) + (prop_of_rock * prop_of_rock * prop_of_reef));
            prop_thrown = Math.Round(prop_thrown, 3);
            prop_thrown = Double.Parse(prop_thrown.ToString("F3")); 
            //prop_thrown = Convert.ToDouble(prop_thrown.ToString("N3"));
            Console.WriteLine(prop_thrown);
        }
      
        static void Main(string[] args)
        {
            int num = Int32.Parse(Console.ReadLine());
            string code = Console.ReadLine();

            int a = 0;
            int b = 0;
            int ab = 0;
            int c = 0;

            char previous_char = 'Z'; 

            foreach (char item in code)
            {
                if(item == 'A')
                {
                    a++; 
                }
                else if(item == 'B' && previous_char == 'A')
                {
                    b++; 
                    ab++; 
                }
                else if(item == 'B')
                {
                    b++; 
                }
                else
                {
                    c++; 
                }
                previous_char = item; 
            }

            int score = a * 1 + b * 2 + ab + c * (ab);
            Console.WriteLine(score); 
        }
        
        static void Main(string[] args)
        {
            string first_line = Console.ReadLine();
            int num_of_fish = Int32.Parse(first_line.Split(' ')[0]);
            int events = Int32.Parse(first_line.Split(' ')[1]);

            for (int i = 0; i < events; i++)
            {
                string line = Console.ReadLine();
                string[] line_split = line.Split(' ');
                if (line_split[0] == "P")
                {
                    int y = Int32.Parse(line_split[1]);
                    num_of_fish = num_of_fish / y * y;
                }
                else
                {
                    int g = Int32.Parse(line_split[1]);
                    num_of_fish += g;
                }
            }
            Console.WriteLine(num_of_fish);

        }
        

        static void Main(string[] args)
        {
            int trues = 0; 
            for(int i = 0; i < 4; i++)
            {
                string line = Console.ReadLine();
                string[] words = line.Split(' ');
                string boolean = words[words.Count() - 1]; 
                if (boolean == "true")
                    trues++; 
            }
            if(trues >= 3)
            {
                Console.WriteLine("Wait for the storm to pass."); 
            }
            else
            {
                Console.WriteLine("Go fishing!"); 
            }
        } 

        static void Main(string[] args)
        {
            int h = 0;
            int k = 0;
            int o = 0;
            int p = 0;
            int q = 0;
            int t = 0;

            string input = Console.ReadLine(); 
            foreach (char item in input)
            {
                if (item == 'h')
                    h++; 
                else if (item == 'k')
                    k++;
                else if (item == 'o')
                    o++;
                else if (item == 'p')
                    p++;
                else if (item == 'q')
                    q++;
                else if (item == 't')
                    t++; 
            }

            p = p / 2;
            t = t - h; 
            Console.WriteLine($"halibut:{h} \nmackerel:{k}\nsalmon:{o} \nsnapper:{p}\nsquid:{q}\ntuna:{t}");
        }
        
        static void Main(string[] args)
        {
            int items = Int32.Parse(Console.ReadLine());
            string[] walls = Console.ReadLine().Split(' ');

            bool hits_limit = true; 

            for(int i = 0; i < walls.Length; i++)
            {
                int height = Int32.Parse(walls[i]);
                for (int left = 1; left < 4; left++)
                {
                    int left_height = 0; 
                    if (i - left > -1)
                        left_height = Int32.Parse(walls[i - left]);
                    if (Math.Abs(left_height - height) > 4)
                    {
                        hits_limit = false;
                        break; 
                    }
                }

                for (int right = 1; right < 4; right++)
                {
                    int right_height = 0; 
                    if(i + right < walls.Length)
                        right_height = Int32.Parse(walls[i + right]);
                    if (Math.Abs(right_height - height) > 4)
                    {
                        hits_limit = false;
                        break;
                    }
                }
            }

            Console.WriteLine(hits_limit); 
        }

        static void Main(string[] args)
        {
            //on hand
            string[] toolNames = Console.ReadLine().Split(',');
            //for i, how manystring[]
            string[] num_tools = Console.ReadLine().Split(',');
            int jobs = Int32.Parse(Console.ReadLine());

            Dictionary<string, int> tools = new Dictionary<string, int>();

            List<string> can_do_jobs = new List<string>(); 

            for(int i = 0; i < toolNames.Length; i++)
            {
                tools.Add(toolNames[i].Trim(), Int32.Parse(num_tools[i])); 
            }

            for(int i = 0; i < jobs; i++)
            {

                string jobName = Console.ReadLine();
                string[] requiredToolNames = Console.ReadLine().Split(',');
                string[] requiredNumTools = Console.ReadLine().Split(',');

                bool canAdd = true; 

                for(int j = 0; j < requiredToolNames.Length; j++)
                {
                    int compareTo = Int32.Parse(requiredNumTools[j]);
                    int actual;
                    if(!tools.TryGetValue(requiredToolNames[j].Trim(), out actual) || actual < compareTo)
                    {
                        canAdd = false; 
                        break; 
                    }
                }

                if(canAdd)
                    can_do_jobs.Add(jobName);
            }

            can_do_jobs.Sort();
            foreach (string job in can_do_jobs)
                Console.WriteLine(job); 
            
            
        }
        
        
        static void Main(string[] args)
        {
            string[] oxygen_tanks = Console.ReadLine().Split(' ');
            int oxygen_level = Int32.Parse(oxygen_tanks[0]);

            bool use_tanks = false; 

            for(int i = 1; i < oxygen_tanks.Length; i++)
            {
                oxygen_level--;
                if (oxygen_level < 0)
                    break; 
                
                int tank_offer = Int32.Parse(oxygen_tanks[i]);
                if (oxygen_level < tank_offer)
                    oxygen_level = tank_offer; 

            }

            use_tanks = oxygen_level >= 0; 
            Console.WriteLine(use_tanks ? 1 : 0); 
        }
        
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine()); 
            string[] input = Console.ReadLine().Split(new char[] { ',', '(', ')'});
            int? x = null;
            int? y = null; 

            foreach (string item in input)
            {
                if(!String.IsNullOrEmpty(item) || !String.IsNullOrWhiteSpace(item))
                {
                    if(x == null)
                    {
                        x = Int32.Parse(item); 
                    }
                    else
                    {
                        y = Int32.Parse(item); 
                    }
                }
            }

            int up = 0;
            int left = 0; 
            for(int i = 1; i < n; i++)
            {
                string[] direction = Console.ReadLine().Split(' ');
                int pace = Int32.Parse(direction[2]); 
                if (direction[1] == "north")
                {
                    up += pace; 
                }
                else if (direction[1] == "south")
                {
                    up -= pace; 
                }
                else if (direction[1] == "east")
                {
                    left += pace; 
                }
                else if (direction[1] == "west")
                {
                    left -= pace; 
                }
            }

            int ratio = 0; 
            if(x != 0)
            {
                ratio = (int)x / left; 
            }
            else {
                ratio = (int)(y / up); 
            }

            Console.WriteLine(ratio); 
        }

        ///Class exercise. Not a LUCIC comeptition question
        static int findMergeNode(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            HashSet<int> first_linked = new HashSet<int>();

            LinkedListNode<int> head1_current = head1.First;

            while(head1_current != null)
            {
                first_linked.Add(head1_current.Value);
                head1_current = head1_current.Next;
            }

            LinkedListNode<int> head2_current = head2.First; 
            while (head2_current != null)
            {
                if(first_linked.Contains(head2_current.data)) { return head2_current.data; }
                head2_current = head2_current.Next;
            }
            return 0; 


        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int tests = Convert.ToInt32(Console.ReadLine());

            for (int testsItr = 0; testsItr < tests; testsItr++)
            {
                int index = Convert.ToInt32(Console.ReadLine());

                SinglyLinkedList llist1 = new SinglyLinkedList();

                int llist1Count = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llist1Count; i++)
                {
                    int llist1Item = Convert.ToInt32(Console.ReadLine());
                    llist1.InsertNode(llist1Item);
                }

                SinglyLinkedList llist2 = new SinglyLinkedList();

                int llist2Count = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llist2Count; i++)
                {
                    int llist2Item = Convert.ToInt32(Console.ReadLine());
                    llist2.InsertNode(llist2Item);
                }

                SinglyLinkedListNode ptr1 = llist1.head;
                SinglyLinkedListNode ptr2 = llist2.head;

                for (int i = 0; i < llist1Count; i++)
                {
                    if (i < index)
                    {
                        ptr1 = ptr1.next;
                    }
                }

                for (int i = 0; i < llist2Count; i++)
                {
                    if (i != llist2Count - 1)
                    {
                        ptr2 = ptr2.next;
                    }
                }

                ptr2.next = ptr1;

                int result = findMergeNode(llist1.head, llist2.head);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
}