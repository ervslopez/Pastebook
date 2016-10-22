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
            return new PB_POST()
            {
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

        public static List<GetNewsfeed_Result> ToNewsfeed(List<GetAccountRelatedPosts_Result> post)
        {
            List<GetNewsfeed_Result> newsfeed = new List<GetNewsfeed_Result>();
            foreach (var result in post)
            {
                newsfeed.Add(new GetNewsfeed_Result()
                {
                    Comment_Count = result.Comment_Count,
                    CONTENT = result.CONTENT,
                    CREATED_DATE = result.CREATED_DATE,
                    ID = result.ID,
                    Like_Count = result.Like_Count,
                    POSTER_ID = result.POSTER_ID,
                    PROFILE_OWNER_ID = result.PROFILE_OWNER_ID
                });
            }
            return newsfeed;
        }

        public static List<GetAccountRelatedPosts_Result> ToAccountrRelatedPost(List<GetNewsfeed_Result> post)
        {
            List<GetAccountRelatedPosts_Result> newsfeed = new List<GetAccountRelatedPosts_Result>();
            foreach (var result in post)
            {
                newsfeed.Add(new GetAccountRelatedPosts_Result()
                {
                    Comment_Count = result.Comment_Count,
                    CONTENT = result.CONTENT,
                    CREATED_DATE = result.CREATED_DATE,
                    ID = result.ID,
                    Like_Count = result.Like_Count,
                    POSTER_ID = result.POSTER_ID,
                    PROFILE_OWNER_ID = result.PROFILE_OWNER_ID
                });
            }
            return newsfeed;
        }
    }
}