﻿using KludgeBox.Events;
using Newtonsoft.Json;

namespace KludgeBox.Net.Packets;

public abstract partial class AbstractPacket : HandleableEvent
{
    [JsonIgnore]
    public PacketSender Sender { get; set; }

    [JsonIgnore] public virtual bool IsReliable { get; } = true;
}