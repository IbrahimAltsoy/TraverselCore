﻿using System.Linq.Expressions;
using EntityLayer.Concreate;

namespace BusiinessLayer.Abstract
{
    public interface IRepository<T> where T : class// IRepository interface i Entity lerimiz için gerçekleştireceğimiz veritabanı işlemlerini yapacak olan Repository class ında bulunması gereken metotların imzalarını tutuyor. <T> kodu bu interface e dışarıdan parametre olarak generic bir nesnesinin gönderilebilmesini sağlar. where T : class kodu ise T nin tipinin class olması gerektiğini belirler, böylece string gibi bir veri gönderilmeye kalkılırsa interface bunu kabul etmeyecektir.

    {
        List<T> GetAll(Expression<Func<T, bool>> expression); // Get metodunda entity frazmework x=>x. şeklinde yaptığımız lamda experesion larınını kullabilmek için 
        List<T> GetAll(); // ekledin bekle
        T Get(Expression<Func<T, bool>> expression);// Özel sorgu kullanarak 1 tane kayıt getiren metot imzası 
        T Find(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int SaveChanges();
        // Asekron metotlar
        Task<T> FindAsync(Guid id);
        //Task<T> FindStringAsync(string id);
        Task<T> FirstOfDefaultAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> FindAllAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task<int> SaveChangesAsync();
        List<Reservation> GetListWithReservationByWaitApproal(Guid id);
        List<Reservation> GetListWithReservationByapproved(Guid id);
        Task<Guide> GuidesstatuChangeToTrue(Guid id);
    }
}
