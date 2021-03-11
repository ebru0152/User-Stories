using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;
using User_Stories_part_4.Models;
using User_Stories_part_4.Services;

namespace User_Stories_part_4.Pages
{
    public class IndexModel : PageModel
    {
        public StoryboardService StoryboardService;
        public List<UserStory> UserStories { get; private set; }

        public IndexModel(StoryboardService storyboardService)
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

        public string OutputCard(UserStory u)
        {
            return $@"
            <div class=""card mb-5"">
            <div class=""card-header"">
            <p>{u.AssignedPerson} | {u.CurrentStatus}</p>
            <h5 class=""card-title"">({u.Id}) {u.Title}</h5>
            </div>
            <div class=""card-body"">
            <p class=""card-text p-2"">{u.Description}</p>
            </div>
            <div class=""card-footer"">
            <a class=""btn"" type=""button"" href=""/UserStoryDetail?id={u.Id}""><i class=""fa fa-info-circle""></i></a>
            <a class=""btn"" type=""button"" href=""/EditUserStory/{u.Id}""><i class=""fa fa-edit""></i></a>
            <a class=""btn"" type=""button"" href=""/DeleteUserStory/{u.Id}""><i class=""fa fa-trash""></i></a>
            </div>
            </div>";
        }
            
    }
}
