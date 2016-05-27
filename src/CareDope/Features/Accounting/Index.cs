namespace CareDope.Features.Accounting
{
    using System.Threading.Tasks;
    using MediatR;

    public class Index
    {
        public class Query : IAsyncRequest<Result>
        {
        }
        public class Result
        {
        }
        public class Handler : IAsyncRequestHandler<Query, Result>
        {
            public Task<Result> Handle(Query message)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}