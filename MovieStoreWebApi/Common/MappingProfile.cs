using AutoMapper;
using CategoryStoreWebApi.Application.CategoryOperations.Queries;
using DirectorStoreWebApi.Application.DirectorOperations.Queries;
using MovieStoreWebApi.ActorOperations.GetActorDetail;
using MovieStoreWebApi.Application.ActorOperations.Queries;
using MovieStoreWebApi.Application.CustomerOperations.Queries;
using MovieStoreWebApi.Application.MovieOperations.Queries;
using MovieStoreWebApi.Application.OrderOperations.Queries;
using MovieStoreWebApi.CategoryOperations.GetCategoryDetail;
using MovieStoreWebApi.CustomerOperations.GetCustomerDetail;
using MovieStoreWebApi.DirectorOperations.GetDirectorDetail;
using MovieStoreWebApi.Entities;
using MovieStoreWebApi.MovieOperations.GetMovieDetail;
using MovieStoreWebApi.OrderOperations.GetOrderDetail;
using static MovieStoreWebApi.ActorOperations.CreateActor.CreateActorCommand;
using static MovieStoreWebApi.CategoryOperations.CreateCategory.CreateCategoryCommand;
using static MovieStoreWebApi.CustomerOperations.CreateCustomer.CreateCustomerCommand;
using static MovieStoreWebApi.DirectorOperations.CreateDirector.CreateDirectorCommand;
using static MovieStoreWebApi.MovieOperations.CreateMovie.CreateMovieCommand;
using static MovieStoreWebApi.OrderOperations.CreateOrder.CreateOrderCommand;

namespace MovieStoreWebApi.Common
{
    public class MappingProfile : Profile
   {
       public MappingProfile()
       {
            CreateMap<CreateCustomerModel,Customer>();
            CreateMap<Customer,CustomerDetailViewModel>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(m => m.CustomerCategories.Select(s => s.Category.CategoryName)));
            CreateMap<Customer,CustomersViewModel>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(m => m.CustomerCategories.Select(s => s.Category.CategoryName)));
            CreateMap<CreateMovieModel,Movie>();
            CreateMap<Movie,MovieDetailViewModel>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(m => m.Category.CategoryName))
            .ForMember(dest => dest.Actors, opt => opt.MapFrom(m => m.MovieActors.Select(s => s.Actor.FirstName + " " + s.Actor.LastName)))
            .ForMember(dest=> dest.Director, opt=> opt.MapFrom(m=> m.MovieDirectors.Select(s => s.Director.FirstName + " " + s.Director.LastName)));
            CreateMap<Movie,MovieViewModel>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(m => m.Category.CategoryName))
            .ForMember(dest => dest.Actors, opt => opt.MapFrom(m => m.MovieActors.Select(s => s.Actor.FirstName + " " + s.Actor.LastName)))
            .ForMember(dest=> dest.Director, opt=> opt.MapFrom(m=> m.MovieDirectors.Select(s => s.Director.FirstName + " " + s.Director.LastName)));
            CreateMap<CreateActorModel,Actor>();
            CreateMap<Actor,ActorDetailViewModel>();
            CreateMap<Actor,ActorViewModel>()
            .ForMember(dest => dest.Movies, opt => opt.MapFrom(m => m.MovieActors.Select(s => s.Movie.Title)));
            CreateMap<CreateDirectorModel,Director>();
            CreateMap<Director,DirectorDetailViewModel>();
            CreateMap<Director,DirectorViewModel>();
            CreateMap<CreateCategoryModel,Category>();
            CreateMap<Category,CategoryDetailViewModel>();
            CreateMap<Category,CategoryViewModel>();
            CreateMap<CreateOrderModel,Order>();
            CreateMap<Customer,OrderDetailViewModel>()
            .ForMember(dest => dest.FirstNameLastname, opt => opt.MapFrom(m => m.FirstName + " " + m.LastName))
            .ForMember(dest => dest.Movies, opt => opt.MapFrom(m => m.Order.Select(s => s.Movie.Title)))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(m => m.Order.Select(s => s.Movie.Price)))
            .ForMember(dest => dest.PurchasedDate, opt => opt.MapFrom(m => m.Order.Select(s => s.purchasedTime)));
            CreateMap<Customer,OrderViewModel>()
            .ForMember(dest => dest.FirstNameLastname , opt => opt.MapFrom(m => m.FirstName + " " + m.LastName))
            .ForMember(dest => dest.Movies, opt => opt.MapFrom(m => m.Order.Select(s => s.Movie.Title)))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(m => m.Order.Select(s => s.Movie.Price)))
            .ForMember(dest => dest.PurchasedDate, opt => opt.MapFrom(m => m.Order.Select(s => s.purchasedTime)));
           
             
       }
   }
}