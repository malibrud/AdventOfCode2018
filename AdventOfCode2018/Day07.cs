using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    public class Day07
    {
        Dictionary<char, List<char>> steps;
        (char pre, char step)[] instructions;
        int N;
        public Day07(List<string> rawRecords)
        {
            N = rawRecords.Count;
            steps = new Dictionary<char, List<char>>();
            instructions = new(char pre, char step)[N];
            for (int i = 0; i < N; i++)
            {
                instructions[i] = parseRecord(rawRecords[i]);
            }
            var allSteps = getAllStepsSorted();
            for (int i = 0; i < allSteps.Count; i++)
            {
                steps[allSteps[i]] = new List<char>();
            }
            for (int i = 0; i < N; i++)
            {
                var step = instructions[i].step;
                var pre = instructions[i].pre;
                steps[step].Add(pre);
            }
        }

        public string computePart1()
        {
            var order = new StringBuilder(26);
            while (steps.Count > 0)
            {
                var step = getNextStep();
                if (step == 0) break;
                order.Append(step);
                clearStep(step);
            }
            return order.ToString();
        }

        public int computePart2(int nWorkers, int baseDuration)
        {
            var workers = new (char task, int time) [nWorkers];
            var t = 0;
            while (true)
            {
                var freeSteps = getNextSteps();
                assignWork(freeSteps);
                updateWorkers();
                checkForCompletedTasks();
                if (freeSteps.Count == 0 && allWorkersIdle()) break;
                t++;
            }
            return t;
            
            ////////////////////////////////////////////////
            void assignWork(List<char> freeSteps)
            {
                foreach (var fs in freeSteps)
                {
                    if (!isBeingWorked(fs))
                    {
                        assignTaskToWorker(fs);
                    }
                }
            }

            void assignTaskToWorker(char fs)
            {
                for (int i=0; i < workers.Length; i++)
                {
                    if (workers[i].task == 0)
                    {
                        workers[i].task = fs;
                        workers[i].time = baseDuration + fs - 'A' + 1;
                        break;
                    }
                }
            }

            void updateWorkers()
            {
                for (int i = 0; i < workers.Length; i++)
                {
                    if (workers[i].task == 0) continue;
                    workers[i].time--;
                }
            }

            bool allWorkersIdle()
            {
                for (int i = 0; i < workers.Length; i++)
                {
                    if (workers[i].task != 0) return false;
                }
                return true;
            }

            void checkForCompletedTasks()
            {
                for (int i = 0; i < workers.Length; i++)
                {
                    if (workers[i].task != 0 && workers[i].time == 0)
                    {
                        clearStep(workers[i].task);
                        workers[i].task = (char)0;
                    }
                }
            }
            bool isBeingWorked(char task)
            {
                foreach (var w in workers)
                {
                    if (w.task == task) return true;
                }
                return false;
            }
        }

        

        private (char pre, char step) parseRecord(string v)
        {
            var arr = v.Split();
            var pre = arr[1][0];
            var step = arr[7][0];
            return (pre, step);
        }

        List<char> getAllStepsSorted()
        {
            var allSteps = new List<char>();
            for (int i = 0; i < N; i++)
            {
                if (!allSteps.Contains(instructions[i].step)) allSteps.Add(instructions[i].step);
                if (!allSteps.Contains(instructions[i].pre)) allSteps.Add(instructions[i].pre);
            }
            allSteps.Sort();
            return allSteps;
        }

        char getNextStep()
        {
            foreach (var stepKV in steps)
            {
                var step = stepKV.Key;
                var pres = steps[step];
                if (steps[step].Count == 0) return step;
            }
            return '\x0000';
        }
        
        List<char> getNextSteps()
        {
            var freeSteps = new List<char>();
            foreach (var stepKV in steps)
            {
                var step = stepKV.Key;
                var pres = steps[step];
                if (steps[step].Count == 0) freeSteps.Add(step);
            }
            return freeSteps;
        }

        void clearStep(char step)
        {
            foreach (var stepKV in steps)
            {
                var pres = stepKV.Value;
                if (pres.Contains(step)) pres.Remove(step);
            }
            steps.Remove(step);
        }
    }

    public class Node
    {


    }
}
