using MediatR;
using MicroservicesProjectArchitecture.Application.Paging;

namespace MicroservicesProjectArchitecture.Application.Articles.Queries.GetArticles
{
    public class GetArticlesListQuery : IRequest<ArticlesListViewModel>
    {
        public PagingModel PagingModel { get; set; }

        public GetArticlesListQuery(PagingModel pagingModel)
        {
            PagingModel = pagingModel;
        }
    }
}
