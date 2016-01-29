using System;
using System.Collections.Generic;
using TeamEvent.Models;

namespace TeamEvent
{
	public class UserEntity
    {

		public int ID { get; set; }

		public string LastName { get; set; }

		public string FistName { get; set; }

		public string Pseudo { get; set; }

		public string Email { get; set; }

		public string PassWord { get; set; }

		public string Status { get; set; }

		public string Localisation { get; set; }

		public ICollection<AppartienEntity> AppartienEntity { get; set; }
		public ICollection<CommentEntity> CommentEntity { get; set; }
		public ICollection<EventUserStateEntity> EventUserStateEntity { get; set; }
		public ICollection<NotificationEntity> NotificationEntity { get; set; }


	}
}

