using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using DMV_API;

namespace SearchNetwork
{
    class Host
    {
        //constructor
        public Host()
        {
            hostName = Dns.GetHostName();
            hostIpAddresses = Dns.GetHostAddresses(hostName);
            devicesOnNetwork = new List<NetworkDevice>();
            controllers = new List<DMV_APIController>();
            currentDeviceIndex = 0;
            searchGroup = "";
            searchParamName = null;
            Utils.UDP_resend_num = 1;
            Utils.UDP_timeout = 5000;
        }
        //delegates
        public delegate void SearchEnded();
        public event SearchEnded EndSearch;

        public delegate void deviceResultReady(NetworkDevice resultDevice);
        public event deviceResultReady ResultReady;

        //private members
        private string hostName;
        private readonly IPAddress[] hostIpAddresses;
        private List<NetworkDevice> devicesOnNetwork;
        private List<DMV_APIController> controllers;

        //public static members
        public static int currentDeviceIndex;
        public static string searchParamName;
        public static string searchGroup;

        //public properties
        public List<IPAddress> HostIpAddresses
        {
            get
            {
                List<IPAddress> addresses = new List<IPAddress>();
                if (hostIpAddresses == null)
                    return addresses;

                foreach (IPAddress address in hostIpAddresses)
                {
                    if (!(address.IsIPv6LinkLocal || address.IsIPv6Multicast || address.IsIPv6SiteLocal || address.IsIPv6Teredo))
                    {
                        addresses.Add(address);
                    }
                }
                return addresses;
            }
        }
        public List<NetworkDevice> DevicesOnNetwork
        {
            get
            {
                return devicesOnNetwork;
            }
        }
        public string HostName
        {
            get { return hostName; }
        }
        
        //methods
        private void Broadcast()
        {
            devicesOnNetwork = new List<NetworkDevice>();

            int port = 1898;
            UdpClient client = new UdpClient();
            client.EnableBroadcast = true;
            client.Client.ReceiveTimeout = 3000;

            byte[] data = new byte[20];
            client.Send(data, data.Length, IPAddress.Broadcast.ToString(), port);

            var from = new IPEndPoint(IPAddress.Any, 0);

            var sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < 2000)
            {
                try
                {
                    Byte[] receiveBytes = client.Receive(ref from);

                    //check header value
                    if (!(receiveBytes[0] == 0 && receiveBytes[1] == 3))
                    {
                        Console.WriteLine("Recieved message did not have correct header [00 03].");
                        continue;
                    }

                    //get MAC address from recieved bytes
                    string macAddress = "MAC:" + BitConverter.ToString(receiveBytes, 2, 6);

                    //get IP address from recieved bytes
                    byte[] ipBytes = new byte[4];
                    Buffer.BlockCopy(receiveBytes, 8, ipBytes, 0, 4);
                    IPAddress iPAddress = new IPAddress(ipBytes);

                    //Add device to the list
                    NetworkDevice device = new NetworkDevice(iPAddress, macAddress, NetworkDevice.EStatus.NotConnected);
                    devicesOnNetwork.Add(device);
                    Console.WriteLine(iPAddress.ToString().PadRight(16) + macAddress + "---" + sw.ElapsedMilliseconds);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            sw.Stop();

            devicesOnNetwork.Sort((x, y) => -x.HostName.CompareTo(y.HostName));
        }
        public int Search(string parameterName, string group)
        {
            currentDeviceIndex = 0;
            controllers = new List<DMV_APIController>();
            searchParamName = parameterName;
            searchGroup = group;

            Broadcast();

            requestParameters();

            return devicesOnNetwork.Count;
        }
        private void requestParameters()
        {
            devicesOnNetwork[currentDeviceIndex].IndexChanged += indexChanged;

            DMV_APIController controller = new DMV_APIController(devicesOnNetwork[currentDeviceIndex].HostName, 51812);

            controller.Error += devicesOnNetwork[currentDeviceIndex].device_Error;

            controller.ParametersProcessed += devicesOnNetwork[currentDeviceIndex].device_ParametersProcessed;


            this.controllers.Add(controller);

            controller.requestParametersAll();

        }
        private void indexChanged(NetworkDevice networkDevice)
        {
            ResultReady(networkDevice);
            if (currentDeviceIndex >= devicesOnNetwork.Count)
            {
                EndSearch();
                return;
            }  
            requestParameters();
        }
    }
}
