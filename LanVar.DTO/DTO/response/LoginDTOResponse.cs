namespace LanVar.DTO.DTO.response;

public class LoginDTOResponse
{
    public required string userName { get; set; }
    public required string phone { get; set; }
    public DateTime dob { get; set; }
    public string gender { get; set; }
}