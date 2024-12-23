using MemoryBook.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MemoryBook.Repositories
{
    public class RepositoryImpl<T>(ApplicationDbContext context, ILogger<RepositoryImpl<T>> logger) : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly DbSet<T> _dbSet = context.Set<T>();
        private readonly ILogger<RepositoryImpl<T>> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        private bool _disposed = false;

        public async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Запрос на получение записи с Id: {Id}", id);
                var entity = await _dbSet.FindAsync(id);
                if (entity == null)
                {
                    _logger.LogWarning("Запись с Id: {Id} не найдена.", id);
                }
                else
                {
                    _logger.LogInformation("Запись с Id: {Id} успешно найдена.", id);
                }
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении записи с Id: {Id}", id);
                throw;  // Прокидываем исключение дальше, если необходимо
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Запрос на получение всех записей.");
                var entities = await _dbSet.ToListAsync();
                _logger.LogInformation("Получено {Count} записей.", entities.Count);
                return entities;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Ошибка при запросе всех записей.");
                return new List<T>(); // Возвращаем пустой список в случае ошибки
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Неизвестная ошибка при запросе всех записей.");
                return new List<T>(); // Возвращаем пустой список в случае ошибки
            }
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                _logger.LogInformation("Запрос на поиск записей с условием.");
                var entities = await _dbSet.Where(predicate).ToListAsync();
                _logger.LogInformation("Найдено {Count} записей.", entities.Count);
                return entities;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при поиске записей.");
                return new List<T>(); // Возвращаем пустой список в случае ошибки
            }
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                _logger.LogInformation("Добавление новой записи.");
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Запись успешно добавлена.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при добавлении записи.");
                throw; // Прокидываем исключение дальше
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _logger.LogInformation("Обновление записи.");
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Запись успешно обновлена.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при обновлении записи.");
                throw; // Прокидываем исключение дальше
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation("Удаление записи с Id: {Id}", id);
                var entity = await _dbSet.FindAsync(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Запись с Id: {Id} успешно удалена.", id);
                }
                else
                {
                    _logger.LogWarning("Запись с Id: {Id} не найдена для удаления.", id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при удалении записи с Id: {Id}", id);
                throw; // Прокидываем исключение дальше
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            _context?.Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        ~RepositoryImpl()
        {
            Dispose(false);
        }
    }
}
