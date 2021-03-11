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
    public class DeleteUserStoryModel : PageModel
    {
        [BindProperty]
        public UserStory UserStory { get; set; }

        private StoryboardService StoryboardService;

        public  DeleteUserStoryModel(StoryboardService storyboardService)
        {
            StoryboardService = storyboardService;
        }

        public void OnGet(int id)
        {
            UserStory = StoryboardService.userStoryService.GetUserStory(id);
        }

        public IActionResult OnPost()
        {
            UserStory deletedUserStory = StoryboardService.userStoryService.DeleteUserStory(UserStory.Id);
            // why are we storing this variable when just after this line we are redirecting to another page, and then making no one 
            // have a ref to the variable and it get's destroyed, just remove it from the list and then it automaticly gets destoryed
            return RedirectToPage("UserStories");
        }
    }
}
