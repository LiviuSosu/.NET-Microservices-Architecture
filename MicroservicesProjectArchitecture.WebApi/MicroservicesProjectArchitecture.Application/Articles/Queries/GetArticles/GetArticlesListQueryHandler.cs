
using MediatR;
using MicroservicesProjectArchitecture.Persistance;

namespace MicroservicesProjectArchitecture.Application.Articles.Queries.GetArticles
{
    public class GetArticlesListQueryHandler : IRequestHandler<GetArticlesListQuery, ArticlesListViewModel>
    {
        private readonly MicroservicesPatternDbContext _context;
    }
}
