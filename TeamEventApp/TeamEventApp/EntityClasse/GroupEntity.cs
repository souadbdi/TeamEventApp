using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamEvent.Models
{
    public class GroupEntity
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public ICollection<CommentEntity> CommentEntitys { get; set; }
		public ICollection<AppartienEntity> AppartienEntity { get; set; }
		public ICollection<CommentEntity> CommentEntity { get; set; }
		public ICollection<EventEntity> EventEntity { get; set; }
    }
}