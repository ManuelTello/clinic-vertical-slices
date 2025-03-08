using MediatR;
using NET.Clinic.API.Contexts;

namespace NET.Clinic.API.Features.Appointment.CreateAppointment
{
    public class CreateAppointmentCommandHandler(ApplicationContext context) : IRequestHandler<CreateAppointmentCommand, Unit>
    {
        private readonly ApplicationContext _applicationContext = context;

        public async Task<Unit> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = new Entities.Appointment()
            {
                Identification = request.Identification,
                Name = request.Name,
                AppointmentDate = request.AppointmentDate,
            };

            await this._applicationContext.Appointments.AddAsync(appointment, cancellationToken);
            await this._applicationContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}