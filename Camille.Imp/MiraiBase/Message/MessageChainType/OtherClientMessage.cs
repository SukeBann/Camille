﻿using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.MessageChainType;

public record OtherClientMessage : MessageReceivedBase
{
    public override MiraiReceiveMsgType ReceiveMsgType { get; set; } = MiraiReceiveMsgType.OtherClientMessage;

    /// <summary>
    /// 发送者(其他客户端)
    /// </summary>
    [JsonProperty("sender")]
    public MiraiClient Sender { get; set; }
}