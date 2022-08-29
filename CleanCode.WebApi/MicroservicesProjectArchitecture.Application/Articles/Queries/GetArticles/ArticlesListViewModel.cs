using System.Collections.Generic;

namespace MicroservicesProjectArchitecture.Application.Articles.Queries.GetArticles
{
    public class ArticlesListViewModel
    {
        public IList<ArticleLookupModel> Articles { get; set; }
    }
}
