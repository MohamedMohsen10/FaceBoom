﻿using MiniFacebook.Data;
using MiniFacebook.Models.Entities;
using MiniFacebook.Models.RepoInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniFacebook.Models.RepoClass
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext context;
        public UserRepo(ApplicationDbContext _context)
        {
            context = _context;
        }

        public User getUser(string Uid)
        {
            return context.Users.Where(U => U.Id == Uid).ToList()[0];
        }

        public void updateProfile(User user)
        {
            var u = context.Users.Find(user.Id);
            u.PhoneNumber = user.PhoneNumber;
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
            u.Bio = user.Bio;
            context.SaveChanges();
        }
    }
}
