using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Stories_part_4.Models;

namespace User_Stories_part_4.MockData
{
    public class MockStoryBoardProject
    {
        public static List<UserStory> userStories = new List<UserStory>()
        {
            new UserStory("Create Story", "As P.O I want to create a new Story So ...", 400,  1, "Medium"),
            new UserStory("Edit Story", "As P.O I want to edit a Story So ...", 600,  2, "Medium"),
            new UserStory("Move Story", "As team member I want to move a Story So ...", 4700, 13, "Medium"),
            new UserStory("Delete Story", "As team member I want to delete a Story So ...", 300, 14, "Medium")
        };

        public static List<UserStory> GetMockUserStories()
        {
            return userStories;
        }

        public static List<StoryBoardProject> Projects = new List<StoryBoardProject>()
        {
            new StoryBoardProject("Story board uno")
        };

        public static List<StoryBoardProject> GetProjects()
        {
            return Projects;
        }

        public MockStoryBoardProject()
        {
        }
    }
}
