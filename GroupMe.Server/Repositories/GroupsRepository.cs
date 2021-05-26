using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using GroupMe.Interfaces;
using GroupMe.Models;

namespace GroupMe.Repositories
{
    public class GroupsRepository : IRepo<Group>
    {
        private readonly IDbConnection _db;

        public GroupsRepository(IDbConnection db)
        {
            _db = db;
        }

        public Group Create(Group data)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAll()
        {
            string sql = @"
                SELECT 
                    g.*,
                    a.*
                FROM groups g
                JOIN accounts a ON g.creatorId = a.id;
            ";

            // [{g:Group, p: profile}].map(({g,p}) => g.creator = p)
            return _db.Query<Group, Profile, Group>(sql, (g, p) =>
            {
                g.Creator = p;
                return g;
            }, splitOn: "id").ToList();
        }

        public Group GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Group Update(Group data)
        {
            throw new NotImplementedException();
        }
    }
}