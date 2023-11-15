﻿using Domain.Model;

namespace Domain.Abstractions;

public interface IEntityRepository<T>
    where T : BaseEntity
{ 
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetById(int id);
}


