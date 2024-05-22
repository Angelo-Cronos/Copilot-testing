using MediatR;
using ModularMonolith.Framework.Responses;
using ModularMonolith.Modules.Visits.Database.Repositories.Interfaces;

namespace ModularMonolith.Modules.Visits.Commands.Visits.SignOut;

public class SignOutCommandHandler : IRequestHandler<SignOutCommand, Response<bool>>
{
    private readonly IVisitRepository _visitRepository;

    public SignOutCommandHandler(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }
    public async Task<Response<bool>> Handle(SignOutCommand request, CancellationToken cancellationToken)
    {
        //TODO: Implement SignOutCommandHandler

        return Response<bool>.SuccessResponse();
    }
}