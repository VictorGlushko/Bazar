using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazar.Domain.Entities;


namespace Bazar
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetComments();

        Comment GetComment(int id);

        IEnumerable<Answer> GetAnswers(int commentId);

        void AddComment(Comment item);

        void DeleteComment(int id);


    }
}
