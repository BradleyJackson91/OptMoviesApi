using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MoviesApiDTO.Enums;
using MoviesApiDTO.Models;
using MoviesApiSL.Interfaces;

namespace MoviesApiSL.Models
{
    internal class ValidationService : IValidationService
    {
        public ValidationDto ValidatePagePageSize(int page, int pageSize)
        {
            if (page <= 0)
            {
                return new ValidationDto()
                {
                    IsValid = false,
                    Message = "Page value cannot be less than 1."
                };
            }

            if (pageSize <= 0)
            {
                return new ValidationDto()
                {
                    IsValid = false,
                    Message = "Page size cannot be less than 1."
                };
            }

            return new ValidationDto();
        }

        public ValidationDto ValidateGenre(string genre)
        {
            string pattern = "^[a-zA-Z0-9]*$";

            if (Regex.IsMatch(genre, pattern) == false)
            {
                return new ValidationDto()
                {
                    IsValid = false,
                    Message = "Genre can only contain numbers and letters."
                };
            }

            return new ValidationDto();
        }

        public ValidationDto ValidateSortBy(string sortBy)
        {
            bool ableToParse =
                Enum.TryParse<SortBy>(sortBy, ignoreCase: true, out SortBy parsedDirection);

            if (ableToParse == false)
            {
                return new ValidationDto()
                {
                    IsValid = false,
                    Message =
                        $"Sort-by value of '{sortBy}' is not valid. Valid options are 'Title' or 'ReleaseDate'."
                };
            }

            return new ValidationDto();
        }

        public ValidationDto ValidateOrderDirection(string orderDirection)
        {
            bool ableToParse =
                Enum.TryParse<OrderDirection>(orderDirection, ignoreCase: true, out OrderDirection parsedDirection);

            if (ableToParse == false)
            {
                return new ValidationDto()
                {
                    IsValid = false,
                    Message =
                        $"Order-direction of '{orderDirection}' is not valid. Valid options are 'Ascending' or 'Descending'."
                };
            }

            return new ValidationDto();
        }

        public ValidationDto ValidatePagingAndSorting(string sortBy, string orderDirection, int page, int pageSize)
        {
            ValidationDto pagePageSizeValidation = ValidatePagePageSize(page, pageSize);
            if (pagePageSizeValidation.IsValid == false)
            {
                return pagePageSizeValidation;
            }

            ValidationDto sortingValidation = ValidateSortBy(sortBy);
            if (sortingValidation.IsValid == false)
            {
                return sortingValidation;
            }

            ValidationDto orderDirectionValidation = ValidateOrderDirection(orderDirection);
            if (orderDirectionValidation.IsValid == false)
            {
                return orderDirectionValidation;
            }

            return new ValidationDto();
        }
    }
}
