using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Asi.Itb.Dal;
using Asi.Itb.Bll.Entities;
using Asi.Itb.Dal.ItbDataSetTableAdapters;

namespace Asi.Itb.Bll
{
    /// <summary>
    /// Manager class for message related activities
    /// </summary>
    public class MessageManager
    {
        /// <summary>
        /// Get list of messages from database.
        /// </summary>
        /// <param name="unreadOnly">Whether to retrieve unread messages only.</param>
        /// <returns></returns>
        public List<Message> GetMessages(bool unreadOnly)
        {
            using (MessageTableAdapter adpt = new MessageTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;
                ItbDataSet.MessageDataTable dt = unreadOnly ? adpt.GetUnreadMessages() : adpt.GetAllMessages();

                List<Message> ret = new List<Message>();
                foreach (ItbDataSet.MessageRow row in dt.Rows)
                {
                    Message msg = new Message();
                    msg.Id = row.Id;
                    msg.Content = row.Content;
                    msg.Subject = row.Subject;
                    msg.MessageTime = row.MessageTime;
                    msg.IsRead = row.Read;
                    ret.Add(msg);
                }

                return ret;
            }
        }

        /// <summary>
        /// Save specified new message into database.
        /// </summary>
        /// <param name="msg"></param>
        public void SaveNewMessage(Message msg)
        {
            using (MessageTableAdapter adpt = new MessageTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;

                if (msg.Subject == null)
                {
                    msg.Subject = string.Empty;
                } 
                else if (msg.Subject.Length > 500)
                {
                    msg.Subject = msg.Subject.Substring(0, 500);
                }
                if (msg.Content == null)
                {
                    msg.Content = string.Empty;
                }
                else if (msg.Content.Length > 4000)
                {
                    msg.Content = msg.Content.Substring(0, 4000);
                }

                adpt.InsertNewMessage(msg.Subject, msg.Content, msg.IsRead, msg.MessageTime);
            }
        }

        /// <summary>
        /// Mark message with specified id as read.
        /// </summary>
        /// <param name="msgId"></param>
        public void MarkMessageRead(long msgId)
        {
            using (MessageTableAdapter adpt = new MessageTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;
                adpt.MarkMessageRead(msgId);
            }
        }

        /// <summary>
        /// Purge out old and already read messages from database.
        /// </summary>
        public void PurgeOldReadMessages()
        {
            using (MessageTableAdapter adpt = new MessageTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;
                adpt.DeleteReadMessages();
            }
        }

        /// <summary>
        /// Checks whether this is any unread messages in database.
        /// </summary>
        /// <returns></returns>
        public bool HasUnreadMessages()
        {
            using (MessageTableAdapter adpt = new MessageTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;
                int? count = adpt.GetUnreadMessageCount();

                if (count != null && count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Delete message with specified id.
        /// </summary>
        /// <param name="msgId"></param>
        public void DeleteMessage(long msgId)
        {
            using (MessageTableAdapter adpt = new MessageTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;
                adpt.DeleteMessageById(msgId);
            }
        }

        /// <summary>
        /// Delete all messages
        /// </summary>
        public void DeleteAllMessages()
        {
            using (MessageTableAdapter adpt = new MessageTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;
                adpt.DeleteAllMessages();
            }
        }
    }
}
