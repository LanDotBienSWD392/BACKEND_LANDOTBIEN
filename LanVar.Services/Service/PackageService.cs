using System.Net;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Tools.Tools;

namespace LanVar.Services.Service;

public class PackageService : IPackageService
{
    private readonly IGenericRepository<Package> _packageRepository;
    private readonly IGenericRepository<User_Package> _userPackageRepository;
    private readonly IConfiguration _configuration;
    public PackageService(IGenericRepository<Package> packageRepository, IConfiguration configuration,
        IGenericRepository<User_Package> userPackageRepository)
    {
        _packageRepository = packageRepository;
        _configuration = configuration;
        _userPackageRepository = userPackageRepository;
    }

    public async Task<Package> AddPackage(Package package)
    {
        string id = package.packageName.ToString();
        if (string.IsNullOrEmpty(id))
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.BadRequest.ToString(),"Package name invalid");
            
        }
        IEnumerable<Package> duplicatePackage =
            await _packageRepository.GetByFilterAsync(x => x.packageName.Equals(id));

        if (duplicatePackage.Any())
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.BadRequest.ToString(),"Package name exist");
        }

        return await _packageRepository.Add(package);
    }

    public async Task<IEnumerable<Package>> GetAllPackage()
    {
        return await _packageRepository.GetAllAsync();
    }

    public async Task<Package> UpdatedPackage(long id, Package updatedPackage)
    {
        var existingRole = await _packageRepository.GetById(id);
        if (existingRole == null)
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.NotFound.ToString(), "Package not found");
        }

        // Update the properties of the existing role
        
        existingRole.package_Description = updatedPackage.package_Description;
        existingRole.packageName = updatedPackage.packageName;
        
        existingRole.status = updatedPackage.status;
            

        // Save the changes
        return await _packageRepository.Update(existingRole);
    }

    public async Task<bool> DeletePackage(long id)
    {
        // Check if the role with the given id exists
        var existingPackage = await _packageRepository.GetById(id);
        if (existingPackage == null)
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.NotFound.ToString(), "Package not found");
        }

        await _packageRepository.Delete(id);
        return true;
    }

    public async Task<string> CreatePaymentUrl(PaymentInformationModel model, HttpContext context)
    {
        User_Package package = await _userPackageRepository.GetByIdAsync(long.Parse(model.OrderId));
        var tick = DateTime.Now.Ticks.ToString();
        var vnpay = new VnPayLibrary();
        vnpay.AddRequestData("vnp_Version", _configuration["VnPay:Version"]);
        vnpay.AddRequestData("vnp_Command", _configuration["VnPay:Command"]);
        vnpay.AddRequestData("vnp_TmnCode", _configuration["VnPay:TmnCode"]);
        vnpay.AddRequestData("vnp_Amount", (package.price * 100).ToString()); //Số tiền thanh toán. Số tiền không mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND (một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY là: 10000000
        
        vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
        vnpay.AddRequestData("vnp_CurrCode", _configuration["VnPay:CurrCode"]);
        vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(context));
        vnpay.AddRequestData("vnp_Locale",_configuration["VnPay:Locale"]);
        vnpay.AddRequestData("vnp_OrderInfo", package.id.ToString());
        vnpay.AddRequestData("vnp_OrderType", "other"); //default value: other
        vnpay.AddRequestData("vnp_ReturnUrl", _configuration["VnPay:PaymentUserBackReturnUrl"]);
        vnpay.AddRequestData("vnp_TxnRef", tick);
        var paymentUrl = vnpay.CreateRequestUrl(_configuration["VnPay:BaseUrl"],
            _configuration["VnPay:HashSecret"]
        );
        
        return paymentUrl;
    }

    public PaymentResponseModel PaymentExecute(IQueryCollection collections)
    {
        var vnpay = new VnPayLibrary();
        foreach (var (key, value) in collections)
        {
            if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
            {
                vnpay.AddResponseData(key, value.ToString());
            }
        }

        var vnp_orderId = vnpay.GetResponseData("vnp_OrderInfo");
        var vnp_TransactionId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
        var vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
        var vnp_SecureHash = collections.FirstOrDefault(p => p.Key == "vnp_SecureHash").Value;
        var vnp_OrderInfo = vnpay.GetResponseData("vnp_OrderInfo");
        bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, _configuration["VnPay:HashSecret"]);
        if (!checkSignature)
        {
            return new PaymentResponseModel
            {
                Success = false
            };
        }

        return new PaymentResponseModel
        {
            Success = true,
            PaymentMethod = "VnPay",
            OrderDescription = vnp_OrderInfo,
            OrderId = vnp_orderId,
            TransactionId = vnp_TransactionId.ToString(),
            Token = vnp_SecureHash,
            VnPayResponseCode = vnp_ResponseCode
        };


    }
    

    public async Task<Package> GetPackageById(long id)
    {
        return await _packageRepository.GetById(id);
    }

}