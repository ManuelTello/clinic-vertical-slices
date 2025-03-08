using MediatR;

namespace NET.Clinic.API.Features.Appointment.CreateAppointment
{
    public record CreateAppointmentCommand(string Name, DateTime AppointmentDate, int Identification) : IRequest<Unit>;
}