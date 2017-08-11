using CR_Client.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sodium;
using CR_Client.Library.Sodium;
using CR_Client.Library.CustomNaCl;
using CR_Client.Others;

namespace CR_Client.Packets.Messages.Client
{
    public class ClientLogin
    {
        public static List<byte> BuildPacket(long id,string token, int majorVersion, int minorVersion, int build, string resourceSha,string UDID,string openUdid,string macAddress,string device,string advertisingGuid,string osVersion,string isAndroid,string emptyString1,string androidID,string preferredDeviceLanguage,byte emptyByte1,byte preferredLanguage,string facebookAttributionId,byte advertisingEnabled,string appleIFV,int appStore,string kunlunSSO,string kunlunUID,string emptyString2,string emptyString3,byte emptyByte2)
        {
            List<byte> Packet = new List<byte>();
            Packet.AddLong(id);
            Packet.AddString(token);
            Packet.AddInt(majorVersion);
            Packet.AddInt(minorVersion);
            Packet.AddInt(build);
            Packet.AddString(resourceSha);
            Packet.AddString(UDID);
            Packet.AddString(openUdid);
            Packet.AddString(macAddress);
            Packet.AddString(device);
            Packet.AddString(advertisingGuid);
            Packet.AddString(osVersion);
            Packet.AddString(isAndroid);
            Packet.AddString(emptyString1);
            Packet.AddString(androidID);
            Packet.AddString(preferredDeviceLanguage);
            Packet.Add(emptyByte1);
            Packet.Add(preferredLanguage);
            Packet.AddString(facebookAttributionId);
            Packet.Add(advertisingEnabled);
            Packet.AddString(appleIFV);
            Packet.AddInt(appStore);
            Packet.AddString(kunlunSSO);
            Packet.AddString(kunlunUID);
            Packet.AddString(emptyString2);
            Packet.AddString(emptyString3);
            Packet.Add(emptyByte2);
            return Packet;
        }
    }
}
