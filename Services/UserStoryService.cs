using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Stories_part_4.Models;
using User_Stories_part_4.MockData;

namespace User_Stories_part_4.Services
    {
        public class UserStoryService
        {
            private List<UserStory> userStories;
            private UserStoryService userStoryService { get; set; }

            public UserStoryService()
            {
                
            }

            public void AddUserStory(UserStory userStory)
            {
                userStories.Add(userStory);
            }

            public void AddUserStories(List<UserStory> userStories)
            {
                this.userStories.AddRange(userStories);
            }
         
            public void SetUserStoryList(List<UserStory> userStories)
            {
                this.userStories = userStories;
            }

            public void CreateUserStory(string title, string description, int businessValue, int priority, string storyPoints)
            {
                userStories.Add(new UserStory(title, description, businessValue, priority, storyPoints));
            }
            public List<UserStory> GetUserStories()
            {
                 return userStories;
            }

            public UserStory GetUserStory(int id)
            {
                //denne metode kan skrives langt kortere med lambda
                foreach (UserStory userStory in userStories)
                {
                    if (userStory.Id == id)
                        return userStory;
                }
                return null;
            }

            public UserStory DeleteUserStory(int userstoryId)
            {
                //denne metode kan skrives langt kortere med lambda
                UserStory userstoryToBeDeleted = null;
                foreach (UserStory us in userStories)
                {
                    if (us.Id == userstoryId)
                    {
                        userstoryToBeDeleted = us;
                        break;
                    }
                }
                if (userstoryToBeDeleted != null)
                {
                    userStories.Remove(userstoryToBeDeleted);
                }
                return userstoryToBeDeleted;
            }

            public void UpdateUserStory(UserStory u)
            {
                u.CreationDate = DateTime.Now;
                for (int i = 0; i < userStories.Count; i++)
                {
                    if(userStories[i].Id == u.Id) userStories[i] = u;
                }
            }

            public void MoveUserStory(int id)
            {
                UserStory userStory = GetUserStory(id);

                userStory.CurrentStatus++;
            }
        }
    }
