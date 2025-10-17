using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validation
{
    public static class EntityValidator
    {
        public static bool ValidateNewsArticle(NewsArticle article, out string message)
        {
            if (string.IsNullOrWhiteSpace(article.NewsTitle))
            {
                message = "Title is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(article.Headline))
            {
                message = "Headline is required.";
                return false;
            }
            message = "";
            return true;
        }
    }
}
