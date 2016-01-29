using System;

namespace TeamEvent
{
	public class NotificationEntity
    {
		public int ID { get; set; }
		public DateTime Date { get; set; }
		public string Freq { get; set; }
		public string Note { get; set; }
		public string Views { get; set; }
		public int EventID { get; set; }
		public int UserID { get; set; }
		
	}
}

