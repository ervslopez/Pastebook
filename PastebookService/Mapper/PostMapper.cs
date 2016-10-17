using PastebookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookService
{
    public static class PostMapper
    {
        public static PB_POST ToPB_POST(Post post)
        {
            return new PB_POST() {
                ID = post.ID,
                CONTENT = post.CONTENT,
                CREATED_DATE = post.CREATED_DATE,
                PROFILE_OWNER_ID = post.PROFILE_OWNER_ID,
                POSTER_ID = post.POSTER_ID
            };
        }

        public static Post ToPost(PB_POST post)
        {
            return new Post()
            {
                ID = post.ID,
                CONTENT = post.CONTENT,
                CREATED_DATE = post.CREATED_DATE,
                PROFILE_OWNER_ID = post.PROFILE_OWNER_ID,
                POSTER_ID = post.POSTER_ID
            };
        }
    }
}