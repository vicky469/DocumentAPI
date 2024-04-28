using Carter;
using Carter.ModelBinding;
using DocumentAPI.Models.SEC;
using DocumentAPI.Services;
using Microsoft.AspNetCore.Mvc;
using DateTime = System.DateTime;

namespace DocumentAPI.Endpoints;

public class SecModule: CarterModule
{
    public SecModule()
        : base("/api/sec"){
        WithTags("Sec");
        IncludeInOpenApi();        
    }
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/sec-parser", async (HttpRequest req, 
            SecDocumentsParserRequest request, 
            ISecService service,HttpResponse res) =>
        {
            var result = req.Validate<SecDocumentsParserRequest>(request);
            if (!result.IsValid)
            {
                return Results.BadRequest(result.GetFormattedErrors());
            } 
            return await service.ParseDocuments(request);
        });

        app.MapGet("/batch-get-sec-urls", async (ISecService service,
            HttpRequest request,
            [FromQuery(Name = "documentType")] SecFormTypeEnum formType,
            [FromQuery(Name = "company")] SecCompanyEnum company,
            [FromQuery(Name = "startDateTime")] DateTime? startDateTime,
            [FromQuery(Name = "endDateTime")] DateTime? endDateTime
        ) => await service.BatchGetDocumentUrls(new SecBatchGetUrlsRequest
        {
            FormTypeEnum = formType, CompanyEnum = company, StartDateTime = startDateTime,
            EndDateTime = endDateTime
        }));
    }
}