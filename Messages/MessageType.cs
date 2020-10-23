using Messages;
using System;
using System.Collections.Generic;
using System.Linq;

public enum MessageType
{
    Unknown, SaveRequest, Response, ZipStatus
}

public static class MessageTypeExtensions
{
    private static readonly IEnumerable<MessageType> messageTypeValues =
        EnumExtensions.GetValues<MessageType>();

    public static MessageType ToMessageType(this string value)
    {
        return messageTypeValues
            .Where(m => m.ToString().Equals(value)).FirstOrDefault();
    }
}
