public class Solution {
    public int LeastInterval(char[] tasks, int n)
    {
        return HeapAndGreedy(tasks, n);
    }

     private int HeapAndGreedy(char[] tasks, int n){
        var maxHeap = new PriorityQueue<char, int>();

        //calc frequency of each task
        var map = new Dictionary<char, int>();
        foreach(char task in tasks){
            map[task] = map.GetValueOrDefault(task, 0)+1;
        }   

        //max heapify all tasks
        foreach(var pair in map){
            maxHeap.Enqueue(pair.Key, -pair.Value);
        }

        int intervals = 0;
        var cooldownTasks = new List<char>();
        while(maxHeap.Count>0){
            int workTime = 0;
            for(int i=0; i<=n; i++){

                if(maxHeap.Count>0)
                {
                    char task = maxHeap.Dequeue();
                    cooldownTasks.Add(task);
                    
                    map[task]--; //decrement by one task

                    if(map[task]==0){
                        map.Remove(task);
                    }

                    workTime++;
                }
                else {
                    break; //no task to execute
                }
            }
            
            foreach(var cooldownTask in cooldownTasks){
                if(map.ContainsKey(cooldownTask)){
                    maxHeap.Enqueue(cooldownTask, -map[cooldownTask]);
                }
            }
            cooldownTasks.Clear();

            intervals += maxHeap.Count==0? workTime : n+1;
        }

        return intervals;
    }
}