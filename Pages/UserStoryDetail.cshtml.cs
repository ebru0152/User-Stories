using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using User_Stories_part_4.Models;
using User_Stories_part_4.Services;

namespace User_Stories_part_4.Pages
{
    public class UserStoryDetailModel : PageModel
    {
      [BindProperty]
        public UserStory UserStory { get; set; }

        public List<UserStory> UserStories { get; private set; }
        private StoryboardService StoryboardService;

        public  UserStoryDetailModel(StoryboardService storyboardService)
        {
            StoryboardService = storyboardService;
        }

        public void OnGet(int id)
        {
            UserStories = StoryboardService.userStoryService.GetUserStories();
            UserStory = StoryboardService.userStoryService.GetUserStory(id);
        }
    }
}
