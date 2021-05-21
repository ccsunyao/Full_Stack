using System;

namespace Exercise2
{
    class Program
    {
        public static int solution()
        {
            int array_size;
            Console.WriteLine("Please enter the array size:");
            array_size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[array_size];
            int[] dup = new int[array_size];
            int i = 0;
            while(i < array_size) {
                Console.WriteLine("Please enter the " + (i+1) + "th array value:");
                /*if (Convert.ToInt32(Console.ReadLine()) > 10000 || Convert.ToInt32(Console.ReadLine()) < 0) {
                     Console.WriteLine("Please enter a value bewteen [0,10000]");
                    i = i;
                 } else
                 { 
                     arr[i] = Convert.ToInt32(Console.ReadLine());
                     dup[i] = -1;
                     i++;
                 } */
                arr[i] = Convert.ToInt32(Console.ReadLine());
                dup[i] = -1;
                i++;
            }

            int maxDup = 0;
            int maxNum = arr[0];
            for (int j = 0; j < array_size; j++) {
                int cnt = 1;
                for (int k=j+1; k< array_size; k++) { 
                    if(arr[j] == arr[k]) {
                        cnt++;
                        dup[k] = 0;
                    }
                }
                if (dup[j] != 0)
                {
                    dup[j] = cnt;
                }
                maxDup = (dup[j] > maxDup) ? j : maxDup;
            }
            return arr[maxDup];
        }
        static void Main(string[] args)
        {
            int res = solution();
            Console.WriteLine("the value(or one of the value) that occurs most often in array is " + res.ToString());
        }
    }
}
