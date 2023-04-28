using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RLibrary.Application.Models;
using RLibrary.Application.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RLibrary.Application.Services.DTO.Book;

namespace RLibrary.Application.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddMappings(
            this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BookProfile).Assembly);
            return services;
        }


        internal class BookProfile : Profile
        {
            public BookProfile()
            {

                CreateMap<Models.Book, BookDetailsDTO>(MemberList.None)
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => $"{src.Price.Amount} {src.Price.Currency}"))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Quanitity, opt => opt.MapFrom(src => src.Quanitity));
                        

                CreateMap<CreateBookDTO, Models.Book>(MemberList.None)
                    .ForMember(dest => dest.Quanitity, opt => opt.MapFrom(src => src.Quanitity))
                    .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.GenreId))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                     .ForMember(dest => dest.Price, opt => opt.MapFrom(src => new Price
                     (
                          src.PriceAmount,
                          src.PriceCurrency
                     )));

                CreateMap<UpdateBookDTO, Models.Book>(MemberList.None)
                    .ForMember(dest => dest.Quanitity, opt => opt.MapFrom(src => src.Quanitity))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));


                CreateMap<Models.Book, BookShortDTO>(MemberList.None)
                   .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.Price, opt => opt.MapFrom(src => $"{src.Price.Amount} {src.Price.Currency}"))
                   .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));

            }


            internal class GenreProfile : Profile
            {
                public GenreProfile()
                {
                    CreateMap<Genre, GenreShortDTO>(MemberList.None)
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
                }
            }
        }
    }
}
