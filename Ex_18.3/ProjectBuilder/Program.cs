using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Build projects sequentially
            for (int i = 1; i <= 8; i++)
            {
                Project currProject = new Project(i);
            }
            // Build projects using tasks
            Task firstTask = Task.Run(() => { Project currProject = new Project(1); });
            Task secondTask = Task.Run(() => { Project currProject = new Project(2); });
            Task thirdTask = Task.Run(() => { Project currProject = new Project(3); });
            Task fourthTask = firstTask.ContinueWith(t => { Project currProject = new Project(4); });
            Task fifthTask = Task.Factory.ContinueWhenAll(new Task[] { firstTask, secondTask, thirdTask }, t => { Project currProject = new Project(5); });
            Task sixthTask = Task.Factory.ContinueWhenAll(new Task[] { thirdTask, fourthTask }, t => { Project currProject = new Project(6); });
            Task seventhTask = Task.Factory.ContinueWhenAll(new Task[] { fifthTask, sixthTask }, t => { Project currProject = new Project(7); });
            Task eightTask = fifthTask.ContinueWith(t => { Project currProject = new Project(8); });
            Task.WaitAll(seventhTask, eightTask);
        }
    }
}
