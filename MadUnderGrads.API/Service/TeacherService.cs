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
    public interface ITeacherService
    {
        List<TeacherDataModel> GetAll();
        TeacherDataModel GetById(int id);
        bool Insert(TeacherDataModel model, string userId);
        bool Update(TeacherDataModel model, string userId);
        bool Delete(int teacherId, string userId);
        bool IsTeacherExists(int teacherId);
        IEnumerable<SchoolDataModel> GetSchools();
        IEnumerable<TeacherDataModel> GetBySchool(string schoolName);
    }

    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository teacherRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMappingUtility mappingUtility;

        public TeacherService(ITeacherRepository teacherRepository
            , IUnitOfWork unitOfWork
            , IMappingUtility mappingUtility)
        {
            this.teacherRepository = teacherRepository;
            this.unitOfWork = unitOfWork;
            this.mappingUtility = mappingUtility;
        }

        public bool Delete(int teacherId, string userId)
        {
            teacherRepository.DeleteById(teacherId);
            return unitOfWork.Commit() > 0;
        }

        public List<TeacherDataModel> GetAll()
        {
            return mappingUtility.Project<TeacherModel, TeacherDataModel>
                (teacherRepository.GetAll())
                .ToList();
        }

        public TeacherDataModel GetById(int id)
        {
            var data = teacherRepository.GetById(id);
            if (data == null)
                return null;
            return mappingUtility.Map<TeacherModel, TeacherDataModel>(data);
        }

        public IEnumerable<TeacherDataModel> GetBySchool(string schoolName)
        {
            return mappingUtility.Project<TeacherModel, TeacherDataModel>
                (teacherRepository.GetAll()
                .Where(w => w.SchoolName.Equals(schoolName)))
                .ToList();
        }

        public IEnumerable<SchoolDataModel> GetSchools()
        {
            return teacherRepository.GetAll()
                .Select(w => new SchoolDataModel
                {
                    SchoolName = w.SchoolName
                }).ToList();
        }

        public bool Insert(TeacherDataModel model, string userId)
        {
            var entity = mappingUtility.Map<TeacherDataModel, TeacherModel>(model);
            entity.CreatedBy = userId;
            entity.CreatedOn = DateTime.Now;
            teacherRepository.Insert(entity);
            return unitOfWork.Commit() > 0;
        }

        public bool IsTeacherExists(int teacherId)
        {
            return teacherRepository.IsTeacherExists(teacherId);
        }

        public bool Update(TeacherDataModel model, string userId)
        {
            var entity = teacherRepository.GetById(model.Id);
            if (entity == null)
                return false;
            mappingUtility.Map<TeacherDataModel, TeacherModel>(model, entity);
            return unitOfWork.Commit() > 0;
        }
    }
}