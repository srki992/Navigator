using Autofac;
using Navigator.Commands;
using Navigator.Models;
using Navigator.ViewModels;
using Navigator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Navigator.StartUp
{
    public class Bootstrap
    {
        private ContainerBuilder builder;
        private Autofac.IContainer container;
        private static Bootstrap instance;
        public Bootstrap()
        {
            builder = new ContainerBuilder();

            builder.RegisterType<RelayCommand>().As<ICommand>();


            builder.RegisterType<KandidatiViewModel>().As<IKandidatiViewModel>();
            builder.RegisterType<KandidatiService>().As<IKandidatiService>();
            builder.RegisterType<HomeWindow>().AsSelf();

            builder.RegisterType<InsertViewModel>().As<IInsertViewModel>();
            builder.RegisterType<InsertWindow>().AsSelf();

            builder.RegisterType<UpdateViewModel>().As<IUpdateViewModel>();
            builder.RegisterType<UpdateWindow>().AsSelf();

            builder.RegisterType<DeleteViewModel>().As<IDeleteViewModel>();
            builder.RegisterType<DeleteWindow>().AsSelf();
        }
        public static Bootstrap Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Bootstrap();
                }
                return instance;
            }
        }

        public Autofac.IContainer Bootstraper()
        {
            return builder.Build();
        }

        public Autofac.IContainer Container
        {
            get
            {
                return container;
            }
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public void Build()
        {
            container = builder.Build();
        }
    }
}
