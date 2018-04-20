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
                cfg.CreateMap<ProductTextbookModel, ProductTextBookDataModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))
                    .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Product.CategoryId))
                    .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Product.Condition))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Product.Description))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Product.Email))
                    .ForMember(dest => dest.IsNegotiable, opt => opt.MapFrom(src => src.Product.IsNegotiable))
                    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Product.PhoneNumber))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
                    ;

                cfg.CreateMap<ProductTextBookDataModel, ProductTextbookModel>();
                cfg.CreateMap<ProductTextBookDataModel, ProductModel>();

                cfg.CreateMap<TeacherDataModel, TeacherModel>();
                cfg.CreateMap<TeacherModel, TeacherDataModel>();

                cfg.CreateMap<TeacherReviewDataModel, TeacherReviewModel>();
                cfg.CreateMap<TeacherReviewModel, TeacherReviewDataModel>();
            });
        }
    }
}