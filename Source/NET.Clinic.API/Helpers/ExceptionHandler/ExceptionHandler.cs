using MediatR;

namespace NET.Clinic.API.Helpers.ExceptionHandler
{
    public class ExceptionHandler<TRequest,TResponse> :IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message); 
            }
        }
    }
}

