using MadUnderGrads.API.DataModels;
using MadUnderGrads.API.Models;
using MadUnderGrads.API.Repository;
using MadUnderGrads.API.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Service
{
    public interface ITeacherReviewService
    {
        List<TeacherReviewDataModel> GetAll();
        TeacherReviewDataModel GetById(int id);
        bool Insert(TeacherReviewDataModel model, string userId);
        bool Update(TeacherReviewDataModel model, string userId);
        bool Delete(int id);
    }

    public class TeacherReviewService : ITeacherReviewService
    {
        private readonly ITeacherReviewRepository teacherReviewRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMappingUtility mappingUtility;

        public TeacherReviewService(ITeacherReviewRepository teacherReviewRepository
            , IUnitOfWork unitOfWork
            , IMappingUtility mappingUtility)
        {
            this.teacherReviewRepository = teacherReviewRepository;
            this.unitOfWork = unitOfWork;
            this.mappingUtility = mappingUtility;
        }

        public bool Delete(int id)
        {
            teacherReviewRepository.DeleteById(id);
            return unitOfWork.Commit() > 0;
        }

        public List<TeacherReviewDataModel> GetAll()
        {
            return mappingUtility.Project<TeacherReviewModel, TeacherReviewDataModel>
                (teacherReviewRepository.GetAll()).ToList();
        }

        public TeacherReviewDataModel GetById(int id)
        {
            var data = teacherReviewRepository.GetById(id);
            if (data == null)
                return null;
            return mappingUtility.Map<TeacherReviewModel, TeacherReviewDataModel>(data);
        }

        public bool Insert(TeacherReviewDataModel model, string userId)
        {
            var entity  = mappingUtility.Map<TeacherReviewDataModel, TeacherReviewModel>(model);
            entity.Reviewer = userId;
            entity.ReviewDate = DateTime.Now;
            teacherReviewRepository.Insert(entity);
            return unitOfWork.Commit() > 0;
        }

        public bool Update(TeacherReviewDataModel model, string userId)
        {
            var data = teacherReviewRepository.GetById(model.Id);
            if (data == null)
                return false;
            mappingUtility.Map<TeacherReviewDataModel, TeacherReviewModel>(model, data);
            teacherReviewRepository.Update(data);
            return unitOfWork.Commit() > 0;
        }
    }
}