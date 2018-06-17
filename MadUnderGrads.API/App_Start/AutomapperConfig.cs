using MadUnderGrads.API.DataModels;
using MadUnderGrads.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.App_Start
{
    public class AutomapperConfig
    {
        public static void Register()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                // Search and My products model
                cfg.CreateMap<ProductModel, AllProductDataModel>()
                    .ForMember(dest => dest.CategoryCode, opt => opt.MapFrom(src => src.Category.Code))
                    .ForMember(dest => dest.UserDto, opt => opt.MapFrom(src => src.Creator))
                    ;

                cfg.CreateMap<ProductTextbookModel, AllProductDataModel>();

                cfg.CreateMap<ProductModel, ProductTextBookDataModel>()
                    .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.ProductTextbooks.ISBN))
                    .ForMember(dest => dest.NotesIncluded, opt => opt.MapFrom(src => src.ProductTextbooks.NotesIncluded))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.ProductTextbooks.Title))
                    .ForMember(dest => dest.UserDto, opt => opt.MapFrom(src => src.Creator))
                    ;

                cfg.CreateMap<ApplicationUser, UserDataModel>();

                cfg.CreateMap<ProductTextBookDataModel, ProductTextbookModel>();
                cfg.CreateMap<ProductTextBookDataModel, ProductModel>()
                    .ForPath(dest => dest.ProductTextbooks.ISBN, opt => opt.MapFrom(src => src.ISBN))
                    .ForPath(dest => dest.ProductTextbooks.NotesIncluded, opt => opt.MapFrom(src => src.NotesIncluded))
                    .ForPath(dest => dest.ProductTextbooks.Title, opt => opt.MapFrom(src => src.Title));

                cfg.CreateMap<TeacherDataModel, TeacherModel>();
                cfg.CreateMap<TeacherModel, TeacherDataModel>();

                cfg.CreateMap<CategoryModel, CategoryDataModel>();

                cfg.CreateMap<TeacherReviewDataModel, TeacherReviewModel>();
                cfg.CreateMap<TeacherReviewModel, TeacherReviewDataModel>()
                    .ForMember(dest => dest.ReviewerDto, opt => opt.MapFrom(src => src.ReviewerUser));

                cfg.CreateMap<PictureModel, PictureDataModel>();
            });
        }
    }
}