using Application.Common.Results;
using Application.Common.Errors;
using Domain;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces.Persistance.Repositories;

namespace Infrastructure.Persistance.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;
    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Customer>> GetByUserIdAsync(Guid userId)
    {
        var user = await _context.Customers.FirstOrDefaultAsync(c => c.UserId == userId);

        return user is null
            ? Errors.Customer.NotFound(userId)
            : user;
    }

    public async Task<Result> AddAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);

        return Result.Success();
    }

    public async Task<Result<Customer>> UpdateAsync(Customer customer)
    {
        var customerDB = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customer.Id);
        if (customerDB is null)
            return Errors.Customer.NotFound(customer.Id);

        customerDB.FirstName = customer.FirstName;
        customerDB.LastName = customer.LastName;
        customerDB.DateOfBirth = customer.DateOfBirth;
        customerDB.PhoneNumber = customer.PhoneNumber;
        customerDB.Email = customer.Email;
        customerDB.Address = customer.Address;
        _context.Customers.Update(customerDB);

        return customerDB;
    }

    public async Task<Result<Customer>> GetByIdAsync(Guid id)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        return customer is null
            ? Errors.Customer.NotFound(id)
            : customer;
    }
}
