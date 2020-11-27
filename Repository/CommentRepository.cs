using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Web;
using Bazar.Data;
using Bazar.Domain.Entities;

namespace Bazar
{
  /*  public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Comment> GetComments()
        {
            return _context.Comments.Include(c=>c.Answers).ToList();
        }


        public IEnumerable<Answer> GetAnswers(int commentId)
        {
            return _context.Answers.Where(a=>a.CommentId == commentId);
        }

        public Comment GetComment(int id)
        {
            return _context.Comments.Include(c=>c.Answers).FirstOrDefault(c => c.CommentId == id);
        }

        public void AddComment(Comment item)
        {
            _context.Comments.Add(item);
        }

        public void DeleteComment(int id)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.CommentId == id);
            _context.Comments.Remove(comment);
        }
    }*/
}