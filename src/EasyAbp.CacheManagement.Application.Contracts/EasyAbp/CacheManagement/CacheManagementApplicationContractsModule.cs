﻿using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Authorization;

namespace EasyAbp.CacheManagement
{
    [DependsOn(
        typeof(CacheManagementDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class CacheManagementApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<CacheManagementApplicationContractsModule>("EasyAbp.CacheManagement");
            });
        }
    }
}
