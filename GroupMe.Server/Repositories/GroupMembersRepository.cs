using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using GroupMe.Interfaces;
using GroupMe.Models;

namespace GroupMe.Repositories
{
    public class GroupMembersRepository
    {
        private readonly IDbConnection _db;

        public GroupMembersRepository(IDbConnection db)
        {
            _db = db;
        }

        public GroupMember Create(GroupMember gm)
        {
            string sql = @"
            INSERT INTO 
                group_members(accountId, groupId)
            VALUES(@AccountId, @GroupId);
            SELECT LAST_INSERT_ID();
            ";
            gm.Id = _db.ExecuteScalar<int>(sql, gm);
            return gm;
        }

        internal List<GroupMemberViewModel> GetMembers(int groupId)
        {
            throw new NotImplementedException();
        }
    }
}