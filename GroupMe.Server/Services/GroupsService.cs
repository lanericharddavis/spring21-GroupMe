using System;
using System.Collections.Generic;
using GroupMe.Models;
using GroupMe.Repositories;
using GroupMe.Server.Repositories;

namespace GroupMe.Services
{
  public class GroupsService
  {
    private readonly GroupsRepository _groupRepo;
    private readonly CommentsRepository _commentsRepo;

    public GroupsService(GroupsRepository groupRepo, CommentsRepository commentsRepo)
    {
      _groupRepo = groupRepo;
      _commentsRepo = commentsRepo;
    }

    public List<Group> GetGroups()
    {
      return _groupRepo.GetAll();
    }

    public Group GetById(int id)
    {
      Group group = _groupRepo.GetById(id);
      if (group == null)
      {
        throw new Exception("Invalid Id");
      }
      return group;
    }

    public List<Comment> GetAllGroupsComments(int id)
    {
      return _commentsRepo.GetAllGroupsComments(id);
    }

    //THIS CODE WORKS
    // public Group Update(Group update, Account userInfo)
    // {
    //   Group original = GetById(update.Id);
    //   if (original.CreatorId == userInfo.Id)
    //   {
    //     original.Name = update.Name.Length > 0 ? update.Name : original.Name;
    //     original.Description = update.Description.Length > 0 ? update.Description : original.Description;
    //     original.Img = update.Img.Length > 0 ? update.Img : update.Img;
    //     if (_groupRepo.Update(original))
    //     {
    //       return original;
    //     }
    //     throw new Exception("Something went Wrong, review code.");
    //   }
    //   throw new Exception("You Cannot Edit A Group You Did Not Create");
    // }

    public Group Update(Group update, Account userInfo)
    {
      Group original = GetById(update.Id);
      if (original.CreatorId == userInfo.Id)
      {
        original.Name = update.Name != null ? update.Name : original.Name;
        original.Description = update.Description != null ? update.Description : original.Description;
        original.Img = update.Img != null ? update.Img : update.Img;
        if (_groupRepo.Update(original) != null)
        {
          return original;
        }
        throw new Exception("Something went Wrong, review code.");
      }
      throw new Exception("You Cannot Edit A Group You Did Not Create");
    }

  }
}