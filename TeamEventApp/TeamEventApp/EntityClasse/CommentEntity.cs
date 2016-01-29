using System;
using System.Collections.Generic;
using System.Linq;


namespace TeamEvent.Models
{
    public class CommentEntity
    {
        public int ID { get; set; }
        public string Message { get; set; }
		public DateTime Date { get; set; }
        public int GroupID { get; set; }
      
		public int UserID { get; set; }
	
		public int EventID { get; set; }

    }
}