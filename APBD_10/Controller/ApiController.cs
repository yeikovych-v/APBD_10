using APBD_10.Context;
using Microsoft.AspNetCore.Mvc;

namespace APBD_10.Controller;

[ApiController]
public class ApiController(ApiContext context)
{

    [HttpPost]
    [Route("api/prescription")]
    public IResult CreatePrescription()
    {
        return Results.Ok(context.Patients.ToList());
    }

}