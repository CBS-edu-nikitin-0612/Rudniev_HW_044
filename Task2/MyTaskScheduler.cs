using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    class MyTaskScheduler : TaskScheduler
    {
        Queue<Task> queue = new Queue<Task>();
        AutoResetEvent resetEvent = new AutoResetEvent(false);
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return queue;
        }

        protected override void QueueTask(Task task)
        {
            //queue.Enqueue(task);

            WaitOrTimerCallback callback = (object state, bool timedOut) => base.TryExecuteTask(task);

            // Асинхронный вызов задачи с задержкой в 2 секунды.
            #region Аргументы
            /*     1. auto - от кого ждать сингнал.
                   2. callback - что выполнять.
                   3. null - 1-й аргумент Callback метода.
                   4. 2000 - интервал между вызовами Callback метода.
                   5. true - вызвать Callback метод один раз. false - вызывать Callback метод с интервалом.  */
            #endregion
            ThreadPool.RegisterWaitForSingleObject(resetEvent, callback, null, 2000, false);
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return false;
        }
    }
}
