using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.DTO.DTO.response;

public class PackageDTOResponse
{
    public long id { get; set; }

    public string packageName { get; set; }

    public string package_Description { get; set; }

    public DateTime startDay { get; set; }

    public DateTime endDay { get; set; }

    public bool status { get; set; }
}
