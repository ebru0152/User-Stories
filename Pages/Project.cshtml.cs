using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using User_Stories_part_4.Services;
using User_Stories_part_4.Models;

namespace User_Stories_part_4.Pages
{
    [BindProperties]
    public class ProjectModel : PageModel
    {       
        private StoryboardService StoryboardService{get;set;}

        public int ID { get; set; }
        public string Title { get; set; }

        public ProjectModel(StoryboardService storyboardService)
        {
            StoryboardService = storyboardService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            StoryboardService.AssignProject(StoryboardService.GetProject(ID));
            return RedirectToPage("/UserStories");
        }

        public IActionResult OnPostCreate()
        {
            StoryboardService.CreateProject(Title);
            return RedirectToPage("/UserStories");
        }
    }
}
