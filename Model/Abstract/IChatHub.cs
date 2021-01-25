using System;

namespace Model.Abstract
{
    public interface IChatHub
    {
        void SendToChannel(string name, string message);

    }
}
