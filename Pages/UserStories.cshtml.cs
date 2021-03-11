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
    public class UserStoriesModel : PageModel
    {

        private StoryboardService StoryboardService;
        public List<UserStory> UserStories { get; private set; }

        public  UserStoriesModel(StoryboardService storyboardService)
        {
            StoryboardService = storyboardService;
        }

        public IActionResult OnGet()
        {
            UserStories = StoryboardService.userStoryService.GetUserStories();
            return Page();
        }

        public IActionResult OnPost(string titleSearch)
        {
            titleSearch ??= "";

            if (StoryboardService != null)
                UserStories = StoryboardService.userStoryService.GetUserStories()
                    .FindAll(x => x.Title.ToUpper().Contains(titleSearch.ToUpper()));

            return Page();
        }
    }
}
