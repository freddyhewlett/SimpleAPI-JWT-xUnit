using APIDomain.Entities;
using APIDomain.Interfaces.Repositories;
using APIInfra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIInfra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly APIDbContext _context;
        private DbSet<T> _dataSet;

        public BaseRepository(APIDbContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                _dataSet.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataSet.FirstOrDefaultAsync(u => u.Id == id);
                if (result == null) return false;

                _dataSet.Remove(result);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAllAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataSet.FirstOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataSet.FirstOrDefaultAsync(u => u.Id == item.Id);
                if (result == null) return null;

                _context.Entry(result).CurrentValues.SetValues(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return item;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _dataSet.AnyAsync(u => u.Id == id);
        }
    }
}
