using CompOff_App.Pages.Tabs;
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

            //Tabs
            builder.Services.AddTransient<OverviewPage>();
            builder.Services.AddSingleton<JobListPage>();
            builder.Services.AddSingleton<NewJobPage>();
            return builder;
        }
        public static MauiAppBuilder AddWrappers(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<INavigationWrapper, ShellNavigator>();
            return builder;
        }
        public static MauiAppBuilder AddServices(this MauiAppBuilder builder)
        {
            return builder;
        }

        public static MauiAppBuilder AddViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<LandingPageViewModel>();

            //Tabs
            builder.Services.AddTransient<OverviewPageViewModel>();
            builder.Services.AddSingleton<JobListPageViewModel>();
            builder.Services.AddSingleton<NewJobPageViewModel>();
            return builder;
        }
    }
}
