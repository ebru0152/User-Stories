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
    
    public class CreateUserStoryModel : PageModel
    {
        [BindProperty]
        public UserStory UserStoryToCreate { get; set; }

        private StoryboardService StoryboardService;
        public List<UserStory> UserStories { get; private set; }

        public CreateUserStoryModel(StoryboardService storyboardService)
        {
            StoryboardService = storyboardService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            StoryboardService.userStoryService.CreateUserStory(UserStoryToCreate.Title,UserStoryToCreate.Description,UserStoryToCreate.BusinessValue,UserStoryToCreate.Priority,UserStoryToCreate.StoryPoints);
            return RedirectToPage("/UserStories");
        }
    }
}
