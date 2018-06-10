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
        IEnumerable<TeacherReviewDataModel> GetByTeacherId(int teacherId);
        TeacherReviewDataModel GetById(int id);
        TeacherReviewDataModel Insert(TeacherReviewDataModel model, string userId);
        TeacherReviewDataModel Update(TeacherReviewDataModel model, string userId);
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

        public IEnumerable<TeacherReviewDataModel> GetByTeacherId(int teacherId)
        {
            return mappingUtility.Project<TeacherReviewModel, TeacherReviewDataModel>
                (teacherReviewRepository.GetByTeacherId(teacherId)).ToList();
        }

        public TeacherReviewDataModel GetById(int id)
        {
            var data = teacherReviewRepository.GetById(id);
            if (data == null)
                return null;
            return mappingUtility.Map<TeacherReviewModel, TeacherReviewDataModel>(data);
        }

        public TeacherReviewDataModel Insert(TeacherReviewDataModel model, string userId)
        {
            var entity = mappingUtility.Map<TeacherReviewDataModel, TeacherReviewModel>(model);
            entity.Reviewer = userId;
            entity.ReviewDate = DateTime.Now;
            teacherReviewRepository.Insert(entity);
            bool result =  unitOfWork.Commit() > 0;
            if (result)
                return GetById(entity.Id);
            return null;
        }

        public TeacherReviewDataModel Update(TeacherReviewDataModel model, string userId)
        {
            var data = teacherReviewRepository.GetById(model.Id);
            if (data == null)
                return null;
            mappingUtility.Map<TeacherReviewDataModel, TeacherReviewModel>(model, data);
            teacherReviewRepository.Update(data);
            var result =  unitOfWork.Commit() > 0;
            if (result)
                return GetById(model.Id);
            return null;
        }
    }
}