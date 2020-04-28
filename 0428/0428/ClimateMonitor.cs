using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428
{
    class ClimateMonitor
    {
        private ILogger logger;

        public ClimateMonitor(ILogger logger)
        {
            this.logger = logger;
        }

        public void start()
        {
            Random rand = new Random();
            while (true)
            {
                int temp = rand.Next(-40, 50);
                if (temp == 49)
                    break;

                //WriteLog : 약속된 메서드 명
                logger.WriteLog("현재 온도 : " + temp);
            }
        }
    }
}
