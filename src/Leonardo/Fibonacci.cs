using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leonardo;

public static class Fibonacci
{
    public static int Run(int number)
    {
        int a = 0;
        int b = 1;

        for (int i = 0; i < number - 1; i++)
        {
            int temp = b;
            b = a + b;
            a = temp;
        }
        
        return b;
    }    
    
    public static List<int> RunAsync(string[] args)    {          
        var tasks = new List<Task<int>>();
        foreach (var arg in args)
        {
            var result = Task.Run(() => Fibonacci.Run(Convert.ToInt32(arg)));
            tasks.Add(result);
        }

        Task.WaitAll(tasks.ToArray());
        return tasks.Select(t=>t.Result).ToList();
    }     
}