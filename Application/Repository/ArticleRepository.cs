using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class ArticleRepository
    {
        private readonly ApplicationContext _dbContext;

        public ArticleRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Article article)
        {
            await _dbContext.Articles.AddAsync(article);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Article article)
        {
            _dbContext.Entry(article).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Article article)
        {
            _dbContext.Set<Article>().Remove(article);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Article>> GetAllAsync()
        {
            return await _dbContext.Set<Article>().ToListAsync();
        }

        public async Task<Article> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Article>().FindAsync(id);
        }
    }
}
