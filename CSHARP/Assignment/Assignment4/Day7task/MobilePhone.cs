using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7task
{
    class MobilePhone
    {
        public delegate void RingEventHandler();
        public event RingEventHandler OnRing;
        public void ReceiveCall()
        {
            Console.WriteLine("Call Incoming");
            OnRing.Invoke();
        }
    }

    public class RingtonePlayer
    {
        public void PlayRingtone()
        {
            Console.WriteLine("Playing ringtone...");
        }
    }


    public class ScreenDisplay
    {
        public void ShowCallerInfo()
        {
            Console.WriteLine("Displaying caller information...");
        }
    }


    public class Vibration
    {
        public void Vibrate()
        {
            Console.WriteLine("Phone is vibrating...");
        }
    }

    class task2
    {
        static void Main()
        {
            MobilePhone mobilephone = new MobilePhone();
            RingtonePlayer ringtoneplayer = new RingtonePlayer();
            ScreenDisplay screenDisplay = new ScreenDisplay();
            Vibration vibration = new Vibration();

            mobilephone.OnRing += ringtoneplayer.PlayRingtone;
            mobilephone.OnRing += screenDisplay.ShowCallerInfo;
            mobilephone.OnRing += vibration.Vibrate;

            mobilephone.ReceiveCall();

            Console.Read();
        }
    }


}





