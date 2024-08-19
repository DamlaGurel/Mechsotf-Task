using Autofac;
using AutoMapper;
using MeetingOrganizer.Application.AutoMapper;
using MeetingOrganizer.Domain.Repositories;
using MeetingOrganizer.Infrastructure.Repositories;
using MeetingOrganizer.Models.Services;
using Module = Autofac.Module;



namespace MeetingOrganizer.Application.IoC
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MeetingService>().As<IMeetingService>().InstancePerLifetimeScope();
            builder.RegisterType<MeetingRepository>().As<IMeetingRepository>().InstancePerLifetimeScope();

            builder.Register(context => new MapperConfiguration(config =>
            {
                config.AddProfile<Mapping>();
            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);

            }).As<IMapper>()
              .InstancePerLifetimeScope();
            base.Load(builder);

        }
    }
}


