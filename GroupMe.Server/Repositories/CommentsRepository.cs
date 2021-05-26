using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using Dapper;
using GroupMe.Models;

namespace GroupMe.Server.Repositories
{
  public class CommentsRepository
  {
    private readonly IDbConnection _db;
    public CommentsRepository(IDbConnection db)
    {
      _db = db;
    }

    public List<Comment> GetAllGroupsComments(int id)
    {
      string sql = @"
      SELECT
      c.*,
      g.*,
      a.name,
      a.picture
      FROM comments c
      JOIN accounts a ON c.creatorId = a.id;
      JOIN groups g ON c.groupId = g.id;
      WHERE groupId = @id;
      ";
      return _db.Query<Comment, Profile, Comment>(sql, (c, p) =>
      {
        c.Creator = p;
        return c;
      }, splitOn: "id").ToList();
    }
  }
}