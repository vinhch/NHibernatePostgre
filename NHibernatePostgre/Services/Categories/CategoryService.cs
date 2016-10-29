﻿using System;
using System.Collections.Generic;
using System.Linq;
using NHibernatePostgre.Domains;
using NHibernatePostgre.Repositories;

namespace NHibernatePostgre.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public long AddEntry(Category entry)
        {
            _repository.Add(entry);
            _repository.Commit();
            return entry.Id;
        }

        public void EditEntry(Category entry)
        {
            _repository.Edit(entry);
            _repository.Commit();
        }

        public IEnumerable<Category> GetAll()
        {
            return _repository.AsQueryable.AsEnumerable();
        }

        public Category GetEntryById(long id)
        {
            return _repository.AsQueryable.SingleOrDefault(s => s.Id == id);
        }

        public void MergeEntry(Category entry)
        {
            _repository.Merge(entry);
            _repository.Commit();
        }

        public void RemoveEntry(Category entry)
        {
            _repository.Remove(entry);
            _repository.Commit();
        }

        public void RemoveEntryById(long id)
        {
            var entry = _repository.AsQueryable.SingleOrDefault(s => s.Id == id);
            RemoveEntry(entry);
        }
    }
}