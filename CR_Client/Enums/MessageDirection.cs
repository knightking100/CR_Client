using System;

namespace CR_Client
{
    [Flags]
    public enum MessageDirection : byte
    {
        Client = 2,
        Server = 3
    }
}