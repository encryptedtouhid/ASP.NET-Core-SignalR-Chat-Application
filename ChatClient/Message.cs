using System;
using System.Collections.Generic;
using System.Text;

namespace ChatClient
{
	
/// <summary>
	/// 
	/// </summary>
	public class Message
	{
		/// <summary>
		/// 
		/// </summary>
		public int MessageId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int UserChatId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int EventId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string recipientID { get; set; }
		public string senderID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string contents { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime CreatedDate { get; set; }

	}
}
