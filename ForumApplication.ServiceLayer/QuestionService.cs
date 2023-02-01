using AutoMapper;
using ForumaApplication.DataModel;
using ForumApplication.Repository;
using ForumApplication.ViewModel.QuestionViewModel;
using System;
using System.Collections.Generic;

namespace ForumApplication.ServiceLayer
{
    public interface IQuestionService
    {
        void InsertQuestion(NewQuestionsViewModel q);
        void UpdateQuestionDetails(EditQuestionsViewModel q);
        void UpdateQuestionVoteCount(int qid, int value);
        void UpdateQuestionAnswerCount(int qid, int value);
        void UpdateQuestionViewsCount(int qid);
        void DeleteQuestion(int q);
        List<QuestionsViewModel> GetQuestions();
        QuestionsViewModel GetQuestionByQuestionID(int qid);
    }
    public class QuestionService : IQuestionService
    {
        QuestionsRepository _qr;
        public QuestionService()
        {
            _qr = new QuestionsRepository();
        }
        public void DeleteQuestion(int q)
        {
            _qr.DeleteQuestion(q);
        }

        public QuestionsViewModel GetQuestionByQuestionID(int qid)
        {
            Questions q = _qr.GetQuestionByQuestionID(qid);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Questions, QuestionsViewModel>();
                cfg.IgnoreUnmapped();
            });
            var mapper = config.CreateMapper();
           QuestionsViewModel qvm =  mapper.Map<Questions, QuestionsViewModel>(q);
            return qvm;
            
        }

        public List<QuestionsViewModel> GetQuestions()
        {
            List<Questions> list = new List<Questions>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Questions, QuestionsViewModel>();
                cfg.IgnoreUnmapped();
            });
            var mapper = config.CreateMapper();
          List<QuestionsViewModel> qvm =   mapper.Map<List<Questions>,List<QuestionsViewModel>>(list); 
            return qvm;

        }

        public void InsertQuestion(NewQuestionsViewModel q)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NewQuestionsViewModel, Questions>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
          Questions qus =   mapper.Map<NewQuestionsViewModel, Questions>(q);
            _qr.InsertQuestion(qus);
        }

        public void UpdateQuestionAnswerCount(int qid, int value)
        {
             _qr.UpdateQuestionVoteCount(qid, value);
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<QuestionsViewModel, Questions>();
            //    cfg.IgnoreUnmapped();
            //});
            //var mapper = config.CreateMapper();
            //mapper.Map<QuestionsViewModel, Questions>();
           
        }

        public void UpdateQuestionDetails(EditQuestionsViewModel q)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EditQuestionsViewModel, Questions>();
                cfg.IgnoreUnmapped();
            });
            var mapper = config.CreateMapper();
          Questions  qus =  mapper.Map<EditQuestionsViewModel,Questions>(q);
            _qr.UpdateQuestionDetails(qus);
        }

        public void UpdateQuestionViewsCount(int qid)
        {
           
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<EditQuestionsViewModel, Questions>();
            //    cfg.IgnoreUnmapped();
            //});
            //var mapper = config.CreateMapper();
            //Questions qus = mapper.Map<EditQuestionsViewModel, Questions>();
            _qr.UpdateQuestionViewsCount(qid);  
        }

        public void UpdateQuestionVoteCount(int qid, int value)
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<EditQuestionsViewModel, Questions>();
            //    cfg.IgnoreUnmapped();
            //});
            //var mapper = config.CreateMapper();
            //Questions qus = mapper.Map<EditQuestionsViewModel, Questions>();
            _qr.UpdateQuestionVoteCount(qid, value);
        }
    }
}
