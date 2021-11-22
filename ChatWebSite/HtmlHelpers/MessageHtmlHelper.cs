using ChatWebSite.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChatWebSite.HtmlHelpers
{
    public static class MessageHtmlHelper
    {
        public static HtmlString CreateMessageRaw(this IHtmlHelper html)
        {
            string result = string.Empty;

            result += "<div class='message MESSAGE_TYPE'>";
            result += "<div class='message__wrapper'>";
            result += "<div>MESSAGE_USER_USERNAME</div>";
            result += "<div>MESSAGE_CONTENT</div>";
            result += "<span class='text-muted'>MESSAGE_USER_LOGIN </span>";
            result += "<span class='text-muted'>MESSAGE_TIMESTAMP</span>";
            result += "</div>";
            result += "</div>";

            return new HtmlString(result);
        }

        public static HtmlString CreateMessage(this IHtmlHelper html, Message message, string userId)
        {
            string result = string.Empty;

            result += "<div class='message MESSAGE_TYPE'>";
            result += "<div class='message__wrapper'>";
            result += $"<div>{message.User.UserName}</div>";
            result += $"<div>{message.Content}</div>";
            result += $"<span class='text-muted'>{message.User.Login} </span>";
            result += $"<span class='text-muted'>{message.Timestamp}</span>";
            result += "</div>";
            result += "</div>";

            string messageType = (userId == message.UserId) ?
                "message_user-message" :
                "message_member-message";

            result = result.Replace("MESSAGE_TYPE", messageType);

            return new HtmlString(result);
        }
    }
}
