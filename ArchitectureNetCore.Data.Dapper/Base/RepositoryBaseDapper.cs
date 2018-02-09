using ArchitectureNetCore.Data.Dapper.Mappings;
using ArchitectureNetCore.Domain.Repositories;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Dommel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace ArchitectureNetCore.Data.Dapper
{
    public class RepositoryBaseDapper<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly SqlConnection conn;

        public RepositoryBaseDapper()
        {
            if (FluentMapper.EntityMaps.IsEmpty)
            {
                FluentMapper.Initialize(c =>
                {
                    c.AddMap(new TruckMap());
                    c.ForDommel();
                });
            }

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            conn = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }

        public void Add(TEntity obj)
        {
            conn.Insert(obj);
        }
        
        public virtual IEnumerable<TEntity> GetAll()
        {
           return conn.GetAll<TEntity>();
        }

        public virtual TEntity GetById(int? id)
        {
            return conn.Get<TEntity>(id);
        }

        public void Remove(TEntity obj)
        {
            conn.Delete(obj);
        }

        public void Update(TEntity obj)
        {
            conn.Update(obj);
        }

        public void Dispose()
        {
            conn.Close();
            conn.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
