using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;

namespace LanVar.Service.Interface;

public interface IBillService
{
    Task<BillDTOResponse> CreateBill(BillDTORequest orderCode);
}