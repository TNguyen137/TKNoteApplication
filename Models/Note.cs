using System;

namespace TKNoteApplication.Models
{
    public class Note
    {
        public long Id { get; set; }

        public string Subject { get; set; }

        public string Detail { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastModified { get; set; }

        public string ActiveStatus { get; set; }
    }
}
