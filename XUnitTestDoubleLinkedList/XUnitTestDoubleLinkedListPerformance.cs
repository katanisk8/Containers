using Containers.DoubleLinkedList;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestDoubleLinkedList
{
    public class XUnitTestDoubleLinkedListPerformance
    {
        [Fact]
        public void AddElementPerformance()
        {
            int size = 10000000;
            int find = 5000000;
            LinkedList<int> coreList = new LinkedList<int>();
            DoubleLinkedList<int> myList = new DoubleLinkedList<int>();

            long myListPerformance = MeasurePerformance(() =>
                                                            {
                                                                for (int i = 0; i < size; ++i)
                                                                {
                                                                    myList.AddLast(i);
                                                                }
                                                            });

            long corePerformance = MeasurePerformance(() =>
                                                           {

                                                               for (int i = 0; i < size; ++i)
                                                               {
                                                                   coreList.AddLast(i);
                                                               }
                                                           });


            System.Diagnostics.Trace.WriteLine(string.Format("Core list execution time: {0}ms\nMy list execution time: {1}ms", corePerformance, myListPerformance));

            myListPerformance = MeasurePerformance(() =>
                                                        {
                                                            var el = myList.FirstOrDefault(find, null);
                                                        });

            corePerformance = MeasurePerformance(() =>
                                                        {
                                                            var el = coreList.Find(find);
                                                        });

            System.Diagnostics.Trace.WriteLine(string.Format("Core list execution time: {0}ms\nMy list execution time: {1}ms", corePerformance, myListPerformance));

        }

        private long MeasurePerformance(Action operation)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                operation();
            }
            finally
            {
                watch.Stop();
            }

            return watch.ElapsedMilliseconds;
        }
    }
}
