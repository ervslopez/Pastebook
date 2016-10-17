using PastebookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookService
{
    public static class CommentMapper
    {
        public static PB_COMMENT ToPB_COMMENT(Comment comment)
        {
            return new PB_COMMENT()
            {
                ID = comment.ID,
                POST_ID = comment.POST_ID,
                POSTER_ID = comment.POSTER_ID,
                CONTENT = comment.CONTENT,
                DATE_CREATED = comment.DATE_CREATED
            };
        }

        public static Comment ToComment(PB_COMMENT comment)
        {
            return new Comment()
            {
                ID = comment.ID,
                POST_ID = comment.POST_ID,
                POSTER_ID = comment.POSTER_ID,
                CONTENT = comment.CONTENT,
                DATE_CREATED = comment.DATE_CREATED
            };
        }
    }
}