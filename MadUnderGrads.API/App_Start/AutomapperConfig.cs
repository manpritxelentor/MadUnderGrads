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
                cfg.CreateMap<ProductApparelModel, AllProductDataModel>();
                cfg.CreateMap<ProductElectronicsModel, AllProductDataModel>();
                cfg.CreateMap<ProductFurnitureModel, AllProductDataModel>();
                cfg.CreateMap<ProductMisellanousModel, AllProductDataModel>();

                cfg.CreateMap<ProductModel, ProductTextBookDataModel>()
                    .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.ProductTextbooks.ISBN))
                    .ForMember(dest => dest.NotesIncluded, opt => opt.MapFrom(src => src.ProductTextbooks.NotesIncluded))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.ProductTextbooks.Title))
                    .ForMember(dest => dest.ProductTypeName, opt => opt.MapFrom(src => src.ProductType.Name))
                    .ForMember(dest => dest.UserDto, opt => opt.MapFrom(src => src.Creator))
                    ;
                cfg.CreateMap<ProductModel, ProductApparelDataModel>()
                    .ForMember(dest => dest.Material, opt => opt.MapFrom(src => src.ProductApparels.Material))
                    .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.ProductApparels.Size))
                    .ForMember(dest => dest.AvailableForMen, opt => opt.MapFrom(src => src.ProductApparels.AvailableForMen))
                    .ForMember(dest => dest.AvailableForWomen, opt => opt.MapFrom(src => src.ProductApparels.AvailableForWomen))
                    .ForMember(dest => dest.UserDto, opt => opt.MapFrom(src => src.Creator))
                    .ForMember(dest => dest.ProductTypeName, opt => opt.MapFrom(src => src.ProductType.Name))
                    ;
                cfg.CreateMap<ProductModel, ProductElectronicsDataModel>()
                    .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.ProductElectronics.Manufacturer))
                    .ForMember(dest => dest.UserDto, opt => opt.MapFrom(src => src.Creator))
                    .ForMember(dest => dest.ProductTypeName, opt => opt.MapFrom(src => src.ProductType.Name))
                    ;
                cfg.CreateMap<ProductModel, ProductFurnitureDataModel>()
                    .ForMember(dest => dest.UserDto, opt => opt.MapFrom(src => src.Creator))
                    .ForMember(dest => dest.ProductTypeName, opt => opt.MapFrom(src => src.ProductType.Name))
                    ;
                cfg.CreateMap<ProductModel, ProductMisellanousDataModel>()
                    .ForMember(dest => dest.UserDto, opt => opt.MapFrom(src => src.Creator))
                    .ForMember(dest => dest.ProductTypeName, opt => opt.MapFrom(src => src.ProductType.Name))
                    ;

                cfg.CreateMap<ApplicationUser, UserDataModel>();

                cfg.CreateMap<ProductTextBookDataModel, ProductTextbookModel>();
                cfg.CreateMap<ProductApparelDataModel, ProductApparelModel>();
                cfg.CreateMap<ProductElectronicsDataModel, ProductElectronicsModel>();
                cfg.CreateMap<ProductFurnitureDataModel, ProductFurnitureModel>();
                cfg.CreateMap<ProductMisellanousDataModel, ProductMisellanousModel>();

                cfg.CreateMap<ProductTextBookDataModel, ProductModel>()
                    .ForPath(dest => dest.ProductTextbooks.ISBN, opt => opt.MapFrom(src => src.ISBN))
                    .ForPath(dest => dest.ProductTextbooks.NotesIncluded, opt => opt.MapFrom(src => src.NotesIncluded))
                    .ForPath(dest => dest.ProductTextbooks.Title, opt => opt.MapFrom(src => src.Title));
                cfg.CreateMap<ProductElectronicsDataModel, ProductModel>()
                    .ForPath(dest => dest.ProductElectronics.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer));
                cfg.CreateMap<ProductApparelDataModel, ProductModel>()
                    .ForPath(dest => dest.ProductApparels.AvailableForMen, opt => opt.MapFrom(src => src.AvailableForMen))
                    .ForPath(dest => dest.ProductApparels.AvailableForWomen, opt => opt.MapFrom(src => src.AvailableForWomen))
                    .ForPath(dest => dest.ProductApparels.Material, opt => opt.MapFrom(src => src.Material))
                    .ForPath(dest => dest.ProductApparels.Size, opt => opt.MapFrom(src => src.Size))
                    ;
                cfg.CreateMap<ProductFurnitureDataModel, ProductModel>();
                cfg.CreateMap<ProductMisellanousDataModel, ProductModel>();


                cfg.CreateMap<TeacherDataModel, TeacherModel>();
                cfg.CreateMap<TeacherModel, TeacherDataModel>();

                cfg.CreateMap<CategoryModel, CategoryDataModel>();

                cfg.CreateMap<TeacherReviewDataModel, TeacherReviewModel>();
                cfg.CreateMap<TeacherReviewModel, TeacherReviewDataModel>()
                    .ForMember(dest => dest.ReviewerDto, opt => opt.MapFrom(src => src.ReviewerUser));

                cfg.CreateMap<PictureModel, PictureDataModel>();

                cfg.CreateMap<ProductTypeModel, ProductTypeDataModel>();
                cfg.CreateMap<ProductTypeDataModel, ProductTypeModel>();

                cfg.CreateMap<EventDataModel, EventModel>();
                cfg.CreateMap<EventModel, EventDataModel>()
                    .ForMember(dest=>dest.AttedingUserCount,opt=>opt.MapFrom(src=>src.EventUsers.Count()));
                
            });
        }
    }
}