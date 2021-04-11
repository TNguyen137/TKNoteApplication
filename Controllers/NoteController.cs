using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TKNoteApplication.Models;
using TKNoteApplication.Repositories;

namespace TKNoteApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private const string ID = "{id}";
        private readonly INoteRepo _noteRepository;

        public NoteController(INoteRepo noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [HttpGet(ID)]
        public ActionResult<Note> GetNote(long id)
        {
            var note = _noteRepository.FindNoteById(id);
            return note;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Note>> GetNotes()
        {
            var notes = _noteRepository.GetAllNotes().ToList();
            return notes;
        }

        [HttpPost]
        public ActionResult<Note> PostNote(Note note)
        {
            var currDate = DateTime.Now;
            note.CreateDate = currDate;
            note.LastModified = currDate;
            _noteRepository.SaveNote(note);
            return note;
        }

        [HttpPut]
        public ActionResult<Note> PutNote(Note note)
        {
            note.LastModified = DateTime.Now;
            _noteRepository.EditNote(note);
            return note;
        }

        [HttpDelete(ID)]
        public ActionResult<Note> DeleteNote(long id)
        {
            var note = _noteRepository.FindNoteById(id);
            _noteRepository.DeleteNote(note);
            return note;
        }
    }
}
