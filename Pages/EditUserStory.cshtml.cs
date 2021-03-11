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
    public class EditUserStoryModel : PageModel
    {
        private StoryboardService StoryboardService;

        [BindProperty]
        public UserStory UserStory { get; set; }

        public EditUserStoryModel(StoryboardService storyboardService)
        {
            StoryboardService = storyboardService;
        }

        public IActionResult OnGet(int id)
        {
            UserStory = StoryboardService.userStoryService.GetUserStory(id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            StoryboardService.userStoryService.UpdateUserStory(UserStory);
            return RedirectToPage("Userstories");
        }  
    }
}
