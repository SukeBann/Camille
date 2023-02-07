﻿using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camille.Imp.MiraiBase.Message;

/// <summary>
/// 基础消息类型的父类
/// </summary>
public record BasicMessageBase: IMiraiBasicMessage
{
    /// <inheritdoc/>
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public virtual MiraiMsgType MiraiMsgType { get; init; }
}