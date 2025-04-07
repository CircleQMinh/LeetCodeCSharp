using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public class Alarm
    {
        private event Action OnAlarm;

        public Alarm(Action action)
        {
                OnAlarm = action;
        }

        public void Trigger()
        {
            Console.WriteLine("Alarm triggered!");
            OnAlarm?.Invoke();
        }
    }

}
