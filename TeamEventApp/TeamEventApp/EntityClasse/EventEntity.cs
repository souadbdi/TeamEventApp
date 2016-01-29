using System;
using TeamEvent.Models;
using System.Collections.Generic;

namespace TeamEvent
{
	public class EventEntity
    {
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime StarteDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Adresse { get; set; }
		public int GroupID { get; set; }
		public List<CommentEntity> CommentEntity { get; set; }
		public List<EventUserStateEntity> EventUserStateEntity { get; set; }
		public List<NotificationEntity> NotificationEntity { get; set; }
	}
}

