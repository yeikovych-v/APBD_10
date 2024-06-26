﻿using APBD_10.Context;
using APBD_10.Dto;
using APBD_10.Models;
using Microsoft.VisualBasic;

namespace APBD_10.Service;

public class ApiService(ApiContext context)
{
    public IResult IssuePrescription(PrescriptionEntryDto dto)
    {
        if (InvalidDueDate(dto.Date, dto.DueDate))
        {
            return Results.BadRequest("Invalid Due Date.");
        }

        var patient = new Patient(dto.PatientDto);

        if (PatientNotExists(patient))
        {
            InsertPatient(patient);
        }

        var doctor = new Doctor(dto.PrescriptionEntryDoctorDto);

        if (DoctorNotExists(doctor))
        {
            return Results.BadRequest("Not Existing Doctor Can not Issue Medicament/(s).");
        }

        var meds = GetMedicamentListFromPrescriptionDto(dto.MedicamentDtos);

        if (AnyMedicamentNotExists(meds))
        {
            return Results.BadRequest("All Medicament Should Exists.");
        }

        if (meds.Count > 10)
        {
            return Results.BadRequest("Prescription can include a maximum of 10 medications.");
        }

        var prescription = new Prescription()
        {
            Date = dto.Date,
            DueDate = dto.DueDate,
            IdPatient = patient.IdPatient,
            IdDoctor = doctor.IdDoctor,
        };

        InsertPrescription(prescription);

        return Results.Ok(prescription);
    }

    public IResult ViewPatientData(int patientId)
    {
        var patient = SelectPatientById(patientId);

        if (patient == null)
        {
            return Results.BadRequest("Patient with give id was not found.");
        }


        var patientDto = new PatientDto(patient);

        var prescriptions = SelectAllPrescriptionsForPatient(patient);

        var prescriptionDtos = ParseToDtoList(prescriptions);
        
        var patientDisplay = new PatientDisplayDto()
        {
            PatientDto = patientDto,
            Prescriptions = prescriptionDtos
        };

        return Results.Ok(patientDisplay);
    }

    private List<PrescriptionDto> ParseToDtoList(List<Prescription> prescriptions)
    {
        var dtos = new List<PrescriptionDto>();

        foreach (var prescription in prescriptions)
        {
            dtos.Add(new PrescriptionDto(prescription));
        }
        
        return dtos;
    }

    private List<Prescription> SelectAllPrescriptionsForPatient(Patient patient)
    {
        return context.Prescriptions.Where(p => p.IdPatient == patient.IdPatient).ToList();
    }

    private Patient? SelectPatientById(int patientId)
    {
        return context.Patients.FirstOrDefault(p => p.IdPatient == patientId);
    }

    private void InsertPrescription(Prescription prescription)
    {
        context.Prescriptions.Add(prescription);
        context.SaveChanges();
    }

    private bool AnyMedicamentNotExists(List<Medicament> meds)
    {
        foreach (var med in meds)
        {
            if (!context.Medicaments.Contains(med)) return true;
        }

        return false;
    }

    private List<Medicament> GetMedicamentListFromPrescriptionDto(List<MedicamentDto> medDtos)
    {
        var meds = new List<Medicament>();

        foreach (var dto in medDtos)
        {
            meds.Add(new Medicament(dto));
        }

        return meds;
    }

    public void InsertPatient(Patient patient)
    {
        context.Patients.Add(patient);
        context.SaveChanges();
    }

    private bool PatientNotExists(Patient patient)
    {
        return !context.Patients.Contains(patient);
    }

    private bool InvalidDueDate(DateOnly date, DateOnly dueDate)
    {
        return dueDate >= date;
    }

    private bool DoctorNotExists(Doctor doc)
    {
        return !context.Doctors.Contains(doc);
    }
}