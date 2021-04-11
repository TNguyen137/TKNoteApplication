﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKNoteApplication.Database;
using TKNoteApplication.Models;

namespace TKNoteApplication.Repositories.Implementations
{
    public class NoteRepo : INoteRepo
    {
        private NoteDbContext _context;

        public NoteRepo(NoteDbContext context)
        {
            _context = context;
        }

        public Note FindNoteById(long id)
        {
            var note = _context.Notes.Find(id);
            return note;
        }

        public IEnumerable<Note> GetAllNotes()
        {
            var notes = _context.Notes;
            return notes;
        }

        public void SaveNote(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        public void EditNote(Note note)
        {
            _context.Notes.Update(note);
            _context.SaveChanges();
        }

        public void DeleteNote(Note note)
        {
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }
    }
}