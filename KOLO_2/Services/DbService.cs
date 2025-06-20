using KOLO_2.Data;
using KOLO_2.Models;
using Microsoft.EntityFrameworkCore;

namespace KOLO_2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    
    
    /*
     public async Task<ICollection<Order>> GetOrdersData(string? clientLastName)
    {
        return await _context.Orders
            .Include(e => e.Client)
            .Include(e => e.OrderPastries)
            .ThenInclude(e => e.Pastry)
            .Where(e => clientLastName == null || e.Client.LastName == clientLastName)
            .ToListAsync();
    }

    public async Task<bool> DoesClientExist(int clientID)
    {
        return await _context.Clients.AnyAsync(e => e.Id == clientID);
    }

    public async Task<bool> DoesEmployeeExist(int employeeID)
    {
        return await _context.Employees.AnyAsync(e => e.Id == employeeID);
    }

    public async Task AddNewOrder(Order order)
    {
        await _context.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task<Pastry?> GetPastryByName(string name)
    {
        return await _context.Pastries.FirstOrDefaultAsync(e => e.Name == name);
    }

    public async Task AddOrderPastries(IEnumerable<OrderPastry> orderPastries)
    {
        await _context.AddRangeAsync(orderPastries);
        await _context.SaveChangesAsync();
    }
    */
    
    
    /*
     * public async Task<Order> GetByIdAsync(int id)
    {
    return await _context.Orders
        .Include(o => o.Items)
        .FirstOrDefaultAsync(o => o.Id == id);
    }
    public async Task<Order> GetByOrderNumberAsync(string orderNumber)
    {
        return await _context.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.OrderNumber == orderNumber);
    }
    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders
            .Include(o => o.Items)
            .ToListAsync();
    }
    public async Task<IEnumerable<Order>> GetByCustomerIdAsync(string customerId)
    {
        return await _context.Orders
            .Include(o => o.Items)
            .Where(o => o.CustomerId == customerId)
            .ToListAsync();
    }
    public async Task<Order> CreateAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }
    public async Task UpdateAsync(Order order)
    {
        _context.Entry(order).State = EntityState.Modified;
        foreach (var item in order.Items)
        {
            if (item.Id == 0)
                _context.OrderItems.Add(item);
            else
                _context.Entry(item).State = EntityState.Modified;
        }
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
     */
}