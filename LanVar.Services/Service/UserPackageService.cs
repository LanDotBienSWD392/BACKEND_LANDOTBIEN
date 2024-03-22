using System.Timers;
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.DTO.DTO.request;
using LanVar.Service.Interface;
using System.Timers;
using Timer = System.Timers.Timer;

namespace LanVar.Service.Service;

public class UserPackageService : IUserPackageService
{
    private readonly IGenericRepository<User_Package> _genericUserPackageRepository;
    private readonly IGenericRepository<Package> _genericPackageRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly Timer _expiryCheckTimer;
    public UserPackageService(IGenericRepository<User_Package> genericUserPackageRepository,
        IUserService userService, IMapper mapper, IGenericRepository<Package> genericPackageRepository
        
        )
    {
        _genericUserPackageRepository = genericUserPackageRepository;
        _userService = userService;
        _mapper = mapper;
        _genericPackageRepository = genericPackageRepository;
        //_expiryCheckTimer = new Timer(TimeSpan.FromDays(1).TotalMilliseconds); // Trigger every day
        

    }
    

    public async Task<User_Package> AddUserPackage(UserPackageDTORequest userPermission)
    {
         
        var userPackage = _mapper.Map<User_Package>(userPermission);
        Package package = await _genericPackageRepository.GetByIdAsync(userPermission.packageId);
        string id = _userService.GetUserID();
        userPackage.status = PackageStatus.Pending;
        userPackage.package_id = userPermission.packageId;
        userPackage.price = package.price;
        userPackage.user_id = long.Parse(id);
        userPackage.startDay = DateTime.Now;
        userPackage.endDay = DateTime.Now.AddDays(30);
        
        return await _genericUserPackageRepository.Add(userPackage);
    }
}