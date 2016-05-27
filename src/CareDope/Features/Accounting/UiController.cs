namespace CareDope.Features.Accounting
{
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using MediatR;

    public class UiController : Controller
    {
        private readonly IMediator _mediator;

        public UiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult> Index(Index.Query query)
        {
            var model = await _mediator.SendAsync(query);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
    }
}