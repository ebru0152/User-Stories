using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace User_Stories_part_4.Models
{
    public class StoryBoardProject
    {
        [Required]
        public string ProjectName { get; set; }   // could have a list of users that are in the project and other stuff
        public DateTime CreationDate { get; set; }
        public List<UserStory> UserStories{get; set;}
        public int ID { get; set; }
        private static int nextId = 1;

        public StoryBoardProject(string projectName)
        {
            ID = nextId++;
            CreationDate = DateTime.Now;
            UserStories = new List<UserStory>();
            ProjectName = projectName;
        }
    }
}
