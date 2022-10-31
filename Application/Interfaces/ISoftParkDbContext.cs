using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Application.Interfaces
    
{
    internal interface ISoftParkDbContext<T> where T : class
    {
        DbSet<T> DB { get; set; }

       


        Task<Guid> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
