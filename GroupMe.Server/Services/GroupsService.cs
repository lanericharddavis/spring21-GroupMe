using System;
using System.Collections.Generic;
using GroupMe.Models;
using GroupMe.Repositories;

namespace GroupMe.Services
{
    public class GroupsService
    {
        private readonly GroupsRepository _groupRepo;

        public GroupsService(GroupsRepository groupRepo)
        {
            _groupRepo = groupRepo;
        }

        internal List<Group> GetGroups()
        {
            return _groupRepo.GetAll();
        }
    }
}