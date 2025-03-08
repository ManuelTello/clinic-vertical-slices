using Carter;
using MediatR;

namespace NET.Clinic.API.Features.Appointment.CreateAppointment
{
    public class CreateAppointmentController : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/v1/appointments/create", async (CreateAppointmentCommand command, IMediator mediator) =>
            {
                try
                {
                    var response = await mediator.Send(command);
                    return Results.Ok();
                }
                catch (ApplicationException exception)
                {
                    return Results.StatusCode(StatusCodes.Status500InternalServerError);
                }
            });
        }
    }
}