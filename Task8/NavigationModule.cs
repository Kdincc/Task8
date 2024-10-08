﻿using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Task8.Views;

namespace Task8
{
    public class NavigationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var region = containerProvider.Resolve<IRegionManager>();

            region.RegisterViewWithRegion(RegionNames.ContentRegion.ToString(), nameof(Home));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Home>();
            containerRegistry.RegisterForNavigation<CourseEdit>();
            containerRegistry.RegisterForNavigation<GroupEdit>();
            containerRegistry.RegisterForNavigation<Teachers>();
        }
    }

    public enum RegionNames
    {
        ContentRegion,
        ToolBarRegion
    }
}
