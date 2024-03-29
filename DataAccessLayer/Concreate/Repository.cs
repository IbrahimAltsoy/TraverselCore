﻿using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BusiinessLayer.Concreate
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected Context context;
        protected DbSet<T> dbSet; // veritabanı için boş generic dbset oluşturduk
        public Repository(Context _context)
        {
            context = _context;
            dbSet = context.Set<T>(); // boş dbset i context içindeki ilgili class ın db seti için ayarladık
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
            SaveChanges();
        }

        public async Task AddAsync(T entity)
        {
            await context.AddAsync(entity);
            //await SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
            //context.SaveChanges();
             
        }

        public T Find(Guid id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> FindAllAsync(Expression<Func<T, bool>> expression)
        {
            return dbSet.Include(expression);
        }

        public async Task<T> FindAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }
         
        //public async Task<T> FindStringAsync(string id)
        //{
        //    return await dbSet.FindAsync(id);
        //}




        public async Task<T> FirstOfDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await dbSet.FirstOrDefaultAsync(expression);
        }


        public T Get(Expression<Func<T, bool>> expression)
        {
            return dbSet.FirstOrDefault(expression);
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression).ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await dbSet.Where(expression).ToListAsync();
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
        //public async Task<int> SaveChangesAsync()
        //{
        //    return await context.SaveChangesAsync();
        //}
        public void Update(T entity)
        {
            context.Update(entity);
        }
        public List<Reservation> GetListWithReservationByWaitApproal(Guid id)
        {
            return context.Reservations.Include(x => x.Destination).Where(x => x.Status == EnumStatu.StatuDurumu.Bekliyor && x.AppUserId == id).ToList();
            //return (context.Reservations.Include(x=>x.Destination).Where(x=>x.Status==EnumStatu.StatuDurumu.Bekliyor && x.AppUserId==id).ToList());
        }
        public List<Reservation> GetListWithReservationByapproved(Guid id)
        {
            return context.Reservations.Include(x => x.Destination).Where(x => x.Status == EnumStatu.StatuDurumu.Onaylanmış && x.AppUserId == id).ToList();
            //return (context.Reservations.Include(x=>x.Destination).Where(x=>x.Status==EnumStatu.StatuDurumu.Bekliyor && x.AppUserId==id).ToList());
        }
        public async Task<Guide> GuidesstatuChangeToTrue(Guid id)
        {
            var model = await context.Guides.FindAsync(id);
            if (model.Statu==true)
            {
                model.Statu = false;
            }
            else
            {
                model.Statu = true;
            }
            await context.SaveChangesAsync(); // Burası değişti await ekledik olması gerekendi hata oluştururssa silersin
            return model;
           
        }
    }
}

