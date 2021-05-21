﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabloidMVC.Models;

namespace TabloidMVC.Repositories
{
    public class PostTagRepository : BaseRepository, IPostTagRepository
    {
        public PostTagRepository(IConfiguration config) : base(config) { }

        // postId = 1
        // tagIds = [2, 3]
        public void AddPostTag(int postId, List<int> tagIds)
        {
            //throw new NotImplementedException();
            string sqlQuery = "";
            foreach (int tagId in tagIds)
            {
                sqlQuery += @$"INSERT INTO PostTag (PostId, TagId)
                                VALUES ({postId}, {tagId})";
            }

            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sqlQuery;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //public void AddPostTag(int postId, List<int> tagIds)
        //{
        //    string sqlQuery = "";
        //    foreach (int tagId in tagIds)
        //    {
        //        sqlQuery += @$"INSERT INTO PostTag (PostId, TagId)
        //                        VALUES ({postId}, {tagId})";
        //    }

        //    using (var conn = Connection)
        //    {
        //        conn.Open();
        //        using (var cmd = conn.CreateCommand())
        //        {
        //            foreach (int tagId in tagIds)
        //            {
        //                cmd.CommandText += @$"INSERT INTO PostTag (PostId, TagId)
        //                        VALUES (@postId, @tagId)";
        //                cmd.Parameters.AddWithValue("@postId", postId);
        //                cmd.Parameters.AddWithValue("@tagId", tagId);

        //            }
                    

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}

        public void DeletePostTag(int postTagId)
        {
            throw new NotImplementedException();
        }
    }
}
