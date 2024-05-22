﻿using MediatR;
using ModularMonolith.Framework.Responses;
using ModularMonolith.Modules.Visits.Dtos;

namespace ModularMonolith.Modules.Visits.Queries.Visits.GetVisits;

public class GetVisitsQuery : IRequest<Response<VisitDetail>>
{
    public string VisitorName { get; set; }
    public string VisitorEmail { get; set; }
    public string VisitorCompany { get; set; }
    public string Employee { get; set; }
    public string Company { get; set; }
}