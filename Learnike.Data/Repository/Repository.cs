using Learnike.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Learnike.Data
{
    /// <inheritdoc/>
    public class Repository<T> : IRepository<T>
        where T : BaseModel
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> entities;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> Get(string[] includes, int offset, int limit, string order)
        {
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset", "offset parameter must to be greater than or equal to 0");

            if (limit > 100)
                throw new ArgumentOutOfRangeException("limit", "limit parameter must to be lower than or equal to 100");

            if (includes != null)
                foreach (var include in includes)
                {
                    entities.Include(include);
                }

            if (string.IsNullOrWhiteSpace(order))
            {
                entities.OrderBy(i => i.Id);
            }

            var result = entities.Skip(offset).Take(limit);
            return result;
        }

        public T Get(int key, string[] includes = null)
        {
            if (key < 1)
                throw new ArgumentOutOfRangeException("key", "key parameter must to be greater than 0");

            if (includes != null)
                foreach (var include in includes)
                {
                    entities.Include(include);
                }


            var query = entities
                            .GroupBy(g => g.UID)
                            .Select(i => i.OrderByDescending(o => o.Revision)
                                          .FirstOrDefault()
                                    );

            var result = query.FirstOrDefault();

            return result;
        }

        public bool Remove(int key)
        {
            if (key < 1)
                throw new ArgumentOutOfRangeException("key", "key parameter must to be greater than 0");

            var entity = this.Get(key);
            var result = entity != null;

            if (result)
            {
                var revAttr = entity.GetType().GetTypeInfo().GetCustomAttribute<RevisionAttribute>(true);

                if (revAttr != null)
                {
                    //A revisão fica negativa, indicando que temos um registro arquivado
                    entity.Revision = -1;

                    entities.Update(entity);
                }
                else
                {
                    entities.Remove(entity);
                }

                context.SaveChanges();
            }

            return result;
        }

        public void Upsert(T item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            if (item.Id == 0)
            {
                entities.Add(item);

                context.SaveChanges();

                item.UID = item.Id;
                entities.Update(item);
            }
            else
            {
                var revAttr = item.GetType().GetTypeInfo().GetCustomAttribute<RevisionAttribute>(true);

                if (revAttr != null)
                {
                    item.UID = item.Id;
                    item.Id = 0;
                    item.Revision += 1;
                    item.CreatedAt = DateTime.UtcNow;

                    entities.Add(item);
                }
                else
                {
                    entities.Update(item);
                }
            }

            context.SaveChanges();
        }
    }
}
