using APBD_10.Context;
using APBD_10.Dto;
using APBD_10.Service;
using Microsoft.AspNetCore.Mvc;

namespace APBD_10.Controller;

[ApiController]
public class ApiController(ApiService service)
{

    [HttpPost]
    [Route("api/prescription")]
    public IResult CreatePrescription(OneFileDto.PrescriptionEntryDto dto)
    {
        return service.IssuePrescription(dto);
    }

    [HttpGet]
    [Route("api/patient/{id:int}")]
    public IResult DisplayPatientData(int id)
    {
        return service.ViewPatientData(id);
    }
}