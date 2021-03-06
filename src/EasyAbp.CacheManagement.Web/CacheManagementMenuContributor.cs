﻿using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.CacheManagement.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using EasyAbp.CacheManagement.Localization;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.CacheManagement.Web
{
    public class CacheManagementMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenu(context);
            }
        }

        private async Task ConfigureMainMenu(MenuConfigurationContext context)
        {
            var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<CacheManagementResource>>();

            var authorizationService = context.ServiceProvider.GetRequiredService<IAuthorizationService>();

            var cacheManagementMenuItem = new ApplicationMenuItem("CacheManagement", l["Menu:CacheManagement"]);
            
            if (await authorizationService.IsGrantedAsync(CacheManagementPermissions.CacheItems.Default))
            {
                cacheManagementMenuItem.AddItem(
                    new ApplicationMenuItem("CacheItem", l["Menu:CacheItems"], "/CacheManagement/CacheItems/CacheItem")
                );
            }

            if (!cacheManagementMenuItem.Items.IsNullOrEmpty())
            {
                context.Menu.Items.Add(cacheManagementMenuItem);
            }
        }
    }
}
