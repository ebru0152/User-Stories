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
    public class MoveUserStoryModel : PageModel
    {
        public StoryboardService StoryboardService;
        [BindProperty]
        public UserStory UserStory { get; set; }

        public MoveUserStoryModel(StoryboardService storyboardService)
        {
            StoryboardService = storyboardService;
        }

        public IActionResult OnGet(int id)
        {
            StoryboardService.userStoryService.MoveUserStory(id);
            return RedirectToPage("Index");
        }
    }
}
