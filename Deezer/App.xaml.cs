﻿using System;
using Deezer.Commons;
using Deezer.Helpers;
using Deezer.Helpers.Interface;
using Deezer.Services;
using Deezer.Services.Interface;
using Deezer.ViewModels;
using Deezer.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Deezer
{
    public partial class App
    {
        public static string search { get; set; }

        public App(IPlatformInitializer initializer) : base(initializer)
        {
        }



        protected override async void OnInitialized()
        {
            try
            {
                await NavigationService.NavigateAsync($"{Constants.NavigationPage}/{Constants.HomePage}");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            try
            {
                RegisterServices(containerRegistry);
                RegisterHelpers(containerRegistry);

                //Register for navigation is always the last registration method
                RegisterForNavigation(containerRegistry);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void RegisterHelpers(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IHttpClientHelper, HttpClientHelper>();
            containerRegistry.RegisterSingleton<IDataTransferHelper, DataTransferHelper>();

        }

        private void RegisterServices(IContainerRegistry containerRegistry)
        {
            //Example  
            //containerRegistry.RegisterSingleton<ILoginService, LoginService>();
            containerRegistry.RegisterSingleton<IRequestService, RequestService>();


        }

        private void RegisterForNavigation(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>(Constants.NavigationPage);



            //Here we register the page and the viewmodel to link them.
            //More, we had a name at this couple to reuse them more efficently.
            containerRegistry.RegisterForNavigation<HomePage, HomeViewModel>(Constants.HomePage);
            containerRegistry.RegisterForNavigation<ResultPage, ResultViewModel>(Constants.ResultPage);
            containerRegistry.RegisterForNavigation<AlbumPage, AlbumViewModel>(Constants.AlbumPage);
            containerRegistry.RegisterForNavigation<ArtistPage, ArtistViewModel>(Constants.ArtistPage);
            containerRegistry.RegisterForNavigation<TrackPage, TrackViewModel>(Constants.TrackPage);





        }


        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}
