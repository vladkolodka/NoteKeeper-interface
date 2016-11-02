using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteKeeper_interface.Resources
{
    public class Note
    {
        public string Enteries { get; }
        public string NoteName { get; }
        public string Date { get; }
        public string Text { get; }

        public Note(string ent, string note, string date, string text)
        {
            Enteries = ent;
            NoteName = note;
            Date = date;
            Text = text;
        }
    }

    public class NoteList:List<Note>
    {
        public NoteList()
        {
            this.Add(new Note("2 enteries", "Custom name", "10 OCT", "Some text"));
            this.Add(new Note("4 enteries", "New name", "10 OCT", "Some perolom"));
            this.Add(new Note("7 enteries", "Kolokol name", "15 OCT", "Some kochka"));
            this.Add(new Note("3 enteries", "Custom label", "20 OCT", "Pedro text"));
        }
    }
}
