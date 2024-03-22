using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LanVar.Service.Service
{
    public class ExpiryCheckBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ExpiryCheckBackgroundService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var genericUserPackageRepository = scopedServices.GetRequiredService<IGenericRepository<User_Package>>();
                    var userService = scopedServices.GetRequiredService<IUserService>();
                    var mapper = scopedServices.GetRequiredService<IMapper>();
                    var genericPackageRepository = scopedServices.GetRequiredService<IGenericRepository<Package>>();

                    // Perform expiry check
                    await CheckAndUpdateExpiryStatus(genericUserPackageRepository, userService, mapper, genericPackageRepository);
                }

                // Delay for 1 minute
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }

        private async Task CheckAndUpdateExpiryStatus(
            IGenericRepository<User_Package> genericUserPackageRepository,
            IUserService userService,
            IMapper mapper,
            IGenericRepository<Package> genericPackageRepository)
        {
            try
            {
                // Retrieve user packages with end day reached
                var expiredUserPackages = await genericUserPackageRepository.GetWhereAsync(up => up.endDay.Date <= DateTime.Now.Date && up.status != PackageStatus.Expired);

                foreach (var userPackage in expiredUserPackages)
                {
                    // Update status to expired
                    userPackage.status = PackageStatus.Expired;
                    await genericUserPackageRepository.Update(userPackage);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred while checking and updating expiry status: {ex.Message}");
            }
        }
    }
}
