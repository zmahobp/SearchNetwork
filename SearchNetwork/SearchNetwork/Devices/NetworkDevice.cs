using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Diagnostics;
using DMV_API;


namespace SearchNetwork
{
    public class NetworkDevice
    {
        //constructor
        public NetworkDevice(IPAddress ipAddress, string macAddress, EStatus status)
        {
            this.ipAddress = ipAddress;
            hostName = ipAddress.ToString();
            this.macAddress = macAddress;
            this.status = status;
            deviceParameters = new Parametri_v2();
            parameterValue = "not available";
        }
        //private class members
        private IPAddress ipAddress;
        private string macAddress;
        private EStatus status;
        private string hostName;
        private Parametri_v2 deviceParameters;
        private string parameterValue;

        //enumeration
        public enum EStatus
        {
            NotConnected = -1,
            Connected_NotFound = 0,
            Connected_Found = 1,
            Error = 2
        }

        //delegates
        public delegate void indexChanged(NetworkDevice networkDevice);
        public event indexChanged IndexChanged;

        //public properties
        public Parametri_v2 DeviceParameters
        {
            get { return deviceParameters; }
        }
        public IPAddress IpAddress
        {
            get { return ipAddress; }
        }
        public string MacAddress
        {
            get { return macAddress; }
        }
        public EStatus Status
        {
            get
            {
                return this.status;
            }
        }
        public string HostName
        {
            get { return hostName; }
        }
        public string ParameterValue
        {
            get { return parameterValue; }
        }


        //methods
        public EStatus SearchFunction()
        {
            if (deviceParameters == null || Host.searchParamName == null)
                return EStatus.NotConnected;

            foreach (Parametar_v2 parameter in deviceParameters.ParamList)
            {
                if (parameter.Name != Host.searchParamName)
                    continue;

                if (Host.searchGroup == "" || Host.searchGroup == parameter.Group)
                {
                    parameterValue = parameter.ParamValue;
                    return EStatus.Connected_Found;
                }

            }

            return EStatus.Connected_NotFound;
        }
        public void device_ParametersProcessed(Parametri_v2 processedParams)
        {
            if (processedParams != null)
            {
                deviceParameters = processedParams;
                status = SearchFunction();
            }
            Host.currentDeviceIndex++;
            IndexChanged(this);
        }
        public void device_Error(string errorMessage, DMV_APIController.ErrorCode errorCode = DMV_APIController.ErrorCode.UNEXPECTED_ERROR)
        {
            Console.WriteLine(errorMessage + " " + errorCode.ToString());
            device_ParametersProcessed(null);
        }
        public override string ToString()
        {
            return this.HostName + " " + this.macAddress + " " + this.status + " " + this.parameterValue ?? "not available";
        }

    }
}