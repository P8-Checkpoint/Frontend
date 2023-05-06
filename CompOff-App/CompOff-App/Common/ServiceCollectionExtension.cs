using CompOff_App.Pages;
using CompOff_App.Pages.Tabs;
using CompOff_App.Services;
using CompOff_App.Services.Impl;
using CompOff_App.Viewmodels;
using CompOff_App.Viewmodels.Tabs;
using CompOff_App.Wrappers;
using CompOff_App.Wrappers.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Common
{
    internal static class ServiceCollectionExtension
    {
        public static MauiAppBuilder AddPages(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<LandingPage>();
            builder.Services.AddTransient<JobPage>();

            //Tabs
            builder.Services.AddTransient<OverviewPage>();
            builder.Services.AddSingleton<JobListPage>();
            builder.Services.AddTransient<NewJobPage>();
            return builder;
        }
        public static MauiAppBuilder AddWrappers(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<INavigationWrapper, ShellNavigator>();
            return builder;
        }
        public static MauiAppBuilder AddServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IDataService, DataService>();
            return builder;
        }

        public static MauiAppBuilder AddViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<LandingPageViewModel>();
            builder.Services.AddTransient<JobPageViewModel>();

            //Tabs
            builder.Services.AddSingleton<OverviewPageViewModel>();
            builder.Services.AddSingleton<JobListPageViewModel>();
            builder.Services.AddTransient<NewJobPageViewModel>();
            return builder;
        }
    }
}
