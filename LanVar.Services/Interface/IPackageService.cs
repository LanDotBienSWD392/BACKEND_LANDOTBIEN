using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using Microsoft.AspNetCore.Http;

namespace LanVar.Service.Interface;

public interface IPackageService
{
    Task<Package> AddPackage(Package package);
    Task<IEnumerable<Package>> GetAllPackage(); 
    Task<Package> GetPackageById(long id);
    Task<Package> UpdatedPackage(long id, Package updatedPackage);
    Task<bool> DeletePackage(long id);
    Task<string> CreatePaymentUrl(PaymentInformationModel model, HttpContext context);
    PaymentResponseModel PaymentExecute(IQueryCollection collections);
}