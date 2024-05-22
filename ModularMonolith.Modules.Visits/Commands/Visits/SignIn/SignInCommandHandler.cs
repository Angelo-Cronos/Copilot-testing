using MediatR;
using ModularMonolith.Entities;
using ModularMonolith.Framework.Responses;
using ModularMonolith.Modules.Visits.Database.Repositories.Interfaces;

namespace ModularMonolith.Modules.Visits.Commands.Visits.SignIn;

public class SignInCommandHandler : IRequestHandler<SignInCommand, Response<bool>>
{
    private readonly IVisitorRepository _visitorRepository;
    private readonly IVisitRepository _visitRepository;

    public SignInCommandHandler(IVisitorRepository visitorRepository, IVisitRepository visitRepository)
    {
        _visitorRepository = visitorRepository;
        _visitRepository = visitRepository;
    }
    
    public async Task<Response<bool>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        
        //TODO: Implement SignInCommandHandler

        return Response<bool>.SuccessResponse();
        
    }
}