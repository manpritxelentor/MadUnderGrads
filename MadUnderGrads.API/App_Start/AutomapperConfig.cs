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
                //cfg.CreateMap<ProductTextbookModel, ProductTextBookDataModel>()
                //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))
                //    .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Product.CategoryId))
                //    .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Product.Condition))
                //    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Product.Description))
                //    .ForMember(dest => dest.IsNegotiable, opt => opt.MapFrom(src => src.Product.IsNegotiable))
                //    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
                //    .ForMember(dest => dest.IsSold, opt => opt.MapFrom(src => src.Product.IsSold))
                //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Product.Email))
                //    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Product.PhoneNumber))
                //    .ForMember(dest => dest.UserDto, opt => opt.MapFrom(src => src.Product.Creator))
                //    ;

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
            });
        }
    }
}