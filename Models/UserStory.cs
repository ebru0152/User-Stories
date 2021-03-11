using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using User_Stories_part_4.Services;

namespace User_Stories_part_4.Models
{
    public class UserStory
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        private static int nextId = 1;
        [Required]
        public int BusinessValue { get; set; }

        public DateTime CreationDate { get; set; }
        [Required]
        public int Priority { get; set; }
        [Required]
        public string StoryPoints { get; set; }
        public string AssignedPerson { get; set; }

        public enum Status
        {
            ToDo,
            Doing,
            CompletlyDone
        }
        public Status CurrentStatus  { get; set; }

        public static List<string> GetStatusList()
        {
            return Enum.GetNames(typeof(Status)).ToList();
        }

        public UserStory(string title, string description, int businessValue, int priority, string storyPoints, string assignedPerson = "None")
        {
            CurrentStatus = Status.ToDo;
            Id = nextId++;
            Title = title;
            Description = description;
            BusinessValue = businessValue;
            CreationDate = DateTime.Now;
            Priority = priority;
            StoryPoints = storyPoints;
            AssignedPerson = assignedPerson;
        }

        public UserStory()
        {
        }
    }
}
