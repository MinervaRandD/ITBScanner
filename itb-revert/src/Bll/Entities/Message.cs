using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Asi.Itb.Bll.Entities
{
    /// <summary>
    /// Represents messages from server
    /// </summary>
    public class Message
    {
        /// <summary>
        /// DB id of the message record.
        /// </summary>
        public long Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets subject of the message
        /// </summary>
        public string Subject
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets content of the message
        /// </summary>
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets time when the message was created
        /// </summary>
        public DateTime MessageTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether the message has been read by the user.
        /// </summary>
        public bool IsRead
        {
            get;
            set;
        }
    }
}
