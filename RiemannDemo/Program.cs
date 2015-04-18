using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLog;

namespace RiemannDemo
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var log = LogManager.GetCurrentClassLogger();

            string line;
            while ((line = Console.ReadLine()) != "exit")
            {
                if (line == "1")
                {
                    GlobalDiagnosticsContext.Set("AppID", "TTLService");
                    log.Info("TTL Test (info)");
                }

                if (line == "11")
                {
                    GlobalDiagnosticsContext.Set("AppID", "TTLService");
                    log.Warn("TTL Test (Warn)");
                }

                if (line == "111")
                {
                    GlobalDiagnosticsContext.Set("AppID", "TTLService");
                    log.Error("TTL Test (Error)");
                }

                if (line == "1111")
                {
                    GlobalDiagnosticsContext.Set("AppID", "TTLService");
                    try
                    {
                        A();
                    }
                    catch(Exception e)
                    {
                        log.Fatal("TTL Test (Fatal)", e);
                    }
                }

                if (line == "2")
                {
                    GlobalDiagnosticsContext.Set("AppID", "MetricService");
                    log.Error("Metric Test");
                }

                if (line == "3")
                {
                    GlobalDiagnosticsContext.Set("AppID", "RollupThrottleService1");
                    log.Fatal("Rollup & Throttle test 3");
                }

                if (line == "4")
                {
                    GlobalDiagnosticsContext.Set("AppID", "RollupThrottleService2");
                    log.Fatal("Rollup & Throttle test 4");
                }

                if (line == "5")
                {
                    GlobalDiagnosticsContext.Set("AppID", "RollupThrottleService3");
                    log.Fatal("Rollup & Throttle test 5");
                }

            }
        }

        private static void A()
        {
            B();
        }

        private static void B()
        {
            C();
        }

        private static void C()
        {
            D();
        }

        private static void D()
        {
            throw new Exception("Some Exception"); 
        }
    }
}
