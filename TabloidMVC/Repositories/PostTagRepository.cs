using Microsoft.Extensions.Configuration;
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

        public List<Tags> GetPostTags(int postId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT pt.id AS postTagId, pt.PostId, pt.TagId, t.[Name] 
                                          FROM PostTag pt
                                     LEFT JOIN Tag t ON TagId = t.id
                                         WHERE PostId = @id";
                    cmd.Parameters.AddWithValue("@id", postId);

                    var reader = cmd.ExecuteReader();

                    List<Tags> PostTags = new List<Tags>();

                    while (reader.Read())
                    {
                        Tags tag = new Tags()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("TagId")),
                            Name = reader.GetString(reader.GetOrdinal("Name"))
                        };
                        PostTags.Add(tag);
                    }

                    reader.Close();
                    return PostTags;
                }
            }
        }

        // postId = 1
        // tagIds = [2, 3]
        public void AddPostTag(int postId, List<int> tagIds)
        {
            string sqlQuery = "";
            foreach (int tagId in tagIds)
            {
                sqlQuery += $"INSERT INTO PostTag (PostId, TagId) VALUES ({postId}, {tagId}) ";
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


        public void DeletePostTag(int postId, List<int> tagIdsToRemove)
        {
            //throw new NotImplementedException();
            string sqlQuery = "";
            foreach (int tagId in tagIdsToRemove)
            {
                sqlQuery += $"DELETE FROM PostTag WHERE PostId = {postId} AND TagId = {tagId} ";
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
    }
}
