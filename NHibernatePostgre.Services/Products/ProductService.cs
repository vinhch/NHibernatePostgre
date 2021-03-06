﻿using System;
using System.Collections.Generic;
using System.Linq;
using NHibernatePostgre.Domains;
using NHibernatePostgre.Repositories;

namespace NHibernatePostgre.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public long AddEntry(Product entry)
        {
            _repository.Add(entry);
            return entry.Id;
        }

        public void EditEntry(Product entry)
        {
            _repository.Edit(entry);
        }

        public IEnumerable<Product> GetAll()
        {
            return _repository.AsQueryable.AsEnumerable();
        }

        public Product GetEntryById(long id)
        {
            return _repository.AsQueryable.SingleOrDefault(s => s.Id == id);
        }

        public void MergeEntry(Product entry)
        {
            _repository.Merge(entry);
        }

        public void RemoveEntry(Product entry)
        {
            _repository.Remove(entry);
        }

        public void RemoveEntryById(long id)
        {
            var entry = _repository.AsQueryable.SingleOrDefault(s => s.Id == id);
            RemoveEntry(entry);
        }
    }
}