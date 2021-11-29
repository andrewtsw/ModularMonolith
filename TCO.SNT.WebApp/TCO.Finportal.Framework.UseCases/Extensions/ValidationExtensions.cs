using FluentValidation;
using System;
using System.Collections.Generic;

namespace TCO.Finportal.Framework.UseCases.Extensions
{
    public static class ValidationExtensions
    {
        public static void EnsureIsValid<TEntity>(this AbstractValidator<TEntity> validator, TEntity entity)
        {
            var result = validator.Validate(entity);
            if (!result.IsValid)
            {
                throw new ValidationException(result.ToString());
            }
        }

        public static void ValidateAll<TEntity>(this IEnumerable<TEntity> entities, AbstractValidator<TEntity> validator)
        {
            foreach (var entity in entities)
            {
                validator.EnsureIsValid(entity);
            }
        }

        public static void ValidateAll<TContainer, TEntity>(this IEnumerable<TContainer> entities,
            Func<TContainer, TEntity> selector, AbstractValidator<TEntity> validator)
        {
            foreach (var entity in entities)
            {
                validator.EnsureIsValid(selector(entity));
            }
        }
    }
}
