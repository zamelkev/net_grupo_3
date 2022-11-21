using net_grupo_3.Helpers;
using net_grupo_3.Models;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace net_grupo_3.Repositories;

public class OrderDbRepository : IOrderRepository
{
    // attrs
    private AppDbContext Context;

    // constructor
    public OrderDbRepository(AppDbContext context)
    {
        Context = context;
    }

    // methods
    // basic CRUD API methods
    public Order FindById(int id)
    {
        return Context.Orders.Find(id);
    }
    public IList<Order> FindAll()
    {
        return Context.Orders.ToList();
    }


    public Order FindByIdIncludeClient(int id)
    {
        return Context.Orders
            .Include(order => order.User)
            .Where(order => order.Id == id)
            .FirstOrDefault();
    }

    public Order Create(Order order)
    {
        // Si tiene id asignado entonces es un update y no creamos
        if (order.Id > 0) // 1
            return Update(order);

        Context.Orders.Add(order);
        Context.SaveChanges();
        return order;
    }

    public Order Update(Order order)
    {
        if (order?.Id is null || order.Id == 0)
            return Create(order);

        Context.Orders.Attach(order);

        Context.Entry(order).Property(o => o.OrderDate).IsModified = true;
        Context.Entry(order).Property(o => o.User).IsModified = true;
        Context.Entry(order).Property(o => o.UserId).IsModified = true;
        Context.SaveChanges();

        Context.Orders.Update(order);

        Context.SaveChanges();

        return order;
    }

    public bool Delete(int id)
    {
        Order order = FindById(id);
        if (order == null)
            return false;

        Context.Orders.Remove(order); // Un libro puede tener: author y categories

        Context.SaveChanges();
        return true;
    }

    // Extra API methods
    public IList<Order> Filter(OrderFilter of)
    {
        // collection declaration to apply filters to it later
        var query = Context.Orders.AsQueryable(); ;
        // filter by Id
        if (of.Id.HasValue && of.Id > 0)
        {
            query = query.Where(o => o.Id == of.Id);
        }
        // filter by Date
        if (of.Date.HasValue && of.DateOptions.HasValue && of.DateOptions != 0)
        {
            switch (of.DateOptions)
            {
                case 1:
                    query = query.Where(o => o.OrderDate == of.Date);
                    break;
                case 2:
                    query = query.Where(o => o.OrderDate <= of.Date);
                    break;
                case 3:
                    query = query.Where(o => o.OrderDate >= of.Date);
                    break;
                default:
                    break;
            }

        }
        // filter by Client.Id
        if (of.UserId is not null)
        {
            query = query.Where(o => o.UserId == of.UserId);
        }
        // Then use data (for ex. make a list).
        return query.ToList();
        //query = (DbSet<Order>)query.Where(o => o.ClientId == of.ClientId);
    }

}
