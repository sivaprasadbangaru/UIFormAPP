using ForumApplication.ViewModel.AnswerViewModel;
using ForumApplication.ViewModel.CategoriesViewModel;
using ForumApplication.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.ViewModel.QuestionViewModel
{
    public class QuestionsViewModel
    {
        public int QuestionID { get; set; }
        public string QuestionName { get; set; }
        public DateTime QuestionDateAndTime { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public int ViewsCount { get; set; }
        public int AnswersCount { get; set; }
        public int VotesCount { get; set; }

        public UsersViewModel Users { get; set; }
        public CategoryViewModel Category { get; set; }
        public virtual List<AnswersViewModel> Answers { get; set; }
    }
}
