using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using User_Stories_part_4.Models;
using User_Stories_part_4.MockData;

namespace User_Stories_part_4.Services
{
    public class StoryboardService
    {
        public static UserStoryService userStoryService;
        public static string ProjectTitle {get => MyStoryBoardProject.ProjectName; }
        public static List<StoryBoardProject> storyBoardProjects;
        public static StoryBoardProject MyStoryBoardProject;

        
        public StoryboardService()
        {  
            storyBoardProjects = MockStoryBoardProject.GetProjects();
            storyBoardProjects[0].UserStories.AddRange(MockStoryBoardProject.userStories); // assign the userstories to the first project...
            userStoryService = new UserStoryService();
            if(MyStoryBoardProject == null)  AssignProject(storyBoardProjects[0]);
        }
        public void CreateProject(string title)
        {
            StoryBoardProject tempStoryBoard = new StoryBoardProject(title);
            storyBoardProjects.Add(tempStoryBoard);
            AssignProject(tempStoryBoard);   
        }

        public StoryBoardProject GetProject()
        {
            return MyStoryBoardProject;
        }

        public StoryBoardProject GetProject(int id)
        {
            foreach (var item in storyBoardProjects)
            {
                if(item.ID == id) return item;
            }
            return null;
        }

        public List<StoryBoardProject> GetProjects()
        {
            return storyBoardProjects;
        }

        public void AssignProject(StoryBoardProject storyBoardProject)
        {
            MyStoryBoardProject = storyBoardProject;          
            userStoryService.SetUserStoryList(MyStoryBoardProject.UserStories);
        }
    }
}
