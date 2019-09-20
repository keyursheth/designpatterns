using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatterns
{
    public class BridgePattern
    {
        public static void Main()
        {
            TV tv = new TV();
            Remote remote = new Remote(tv);

            remote.IncreaseVolume(40);
            remote.DecreaseVolume(20);

            Console.ReadLine();
        }
    }

    public interface IDevice
    {
        void SetVolume(int newVolume);
        void ChangeChanel(int channelNumber);
    }

    public class Remote
    {
        private IDevice _device;

        public Remote(IDevice device)
        {
            _device = device;
        }

        public void IncreaseVolume(int newVolume)
        {
            _device.SetVolume(newVolume);
        }

        public void DecreaseVolume(int newVolume)
        {
            _device.SetVolume(newVolume);
        }

        public void SetNewChannel(int newChannelNo)
        {
            _device.ChangeChanel(newChannelNo);
        }
    }

    public class TV : IDevice
    {
        public void ChangeChanel(int channelNumber)
        {
            Console.WriteLine("Channel Set to : " + channelNumber);
        }

        public void SetVolume(int newVolume)
        {
            Console.WriteLine("Volume Set to : " + newVolume);
        }
    }

}
