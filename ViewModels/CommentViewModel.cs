using System;
using System.Collections.Generic;
using Bazar.Domain.Entities;


namespace Bazar.ViewModel
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Message  { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }
}
