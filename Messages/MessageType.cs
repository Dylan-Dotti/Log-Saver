using System;
using System.Collections.Generic;
using System.Linq;

public enum MessageType
{
    Unknown, SaveRequest, Response
}

public static class MessageTypeExtensions
{
    private static IEnumerable<MessageType> messageTypeValues =
        Enum.GetValues(typeof(MessageType)).Cast<MessageType>();

    public static MessageType ToMessageType(this string value)
    {
        return messageTypeValues
            .Where(m => m.ToString().Equals(value)).FirstOrDefault();
    }
}
