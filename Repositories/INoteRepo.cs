using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKNoteApplication.Models;

namespace TKNoteApplication.Repositories
{
    public interface INoteRepo
    {
        Note FindNoteById(long id);

        IEnumerable<Note> GetAllNotes();

        void SaveNote(Note note);

        void EditNote(Note note);

        void DeleteNote(Note note);

    }
}
