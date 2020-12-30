﻿using System;

namespace Infrastructure.Ddd.Domain.State
{
    public abstract class StateBase<TEntity, TStatus>
        where TEntity : class, IHasStatus<TStatus>
        where TStatus : Enum
    {
        protected StateBase(TEntity entity)
        {
            Entity = entity
                     ?? throw new ArgumentNullException(nameof(entity));

            // ReSharper disable once VirtualMemberCallInConstructor
            if (!IsStatusEligible(Entity.Status))
            {
                throw new ArgumentException(
                    $"Can't create state {GetType().Name} "
                    + $"because the entity status \"{Entity.Status}\"is in not eligible",
                    nameof(entity));
            }
        }

        public TEntity Entity { get; }

        public abstract bool IsStatusEligible(TStatus status);
    }
}