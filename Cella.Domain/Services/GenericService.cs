using Cella.Domain.Interfaces;
using Cella.Infrastructure;
using Cella.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;
namespace Cella.Domain.Services
{
    public class GenericService<TViewModel, TEntity> : IGenericService<TViewModel, TEntity>
       where TEntity : class, new()
    {
        private readonly ApplicationDbContext _context;
        private readonly Func<TViewModel, TEntity> _mapToEntity;

        public GenericService(ApplicationDbContext context, Func<TViewModel, TEntity> mapToEntity)
        {
            _context = context;
            _mapToEntity = mapToEntity;
        }

        public async Task<ServiceResponse<IEnumerable<TEntity>>> GetAllAsync()
        {
            try
            {
                var entities = await _context.Set<TEntity>().ToListAsync();
                return ServiceResponse<IEnumerable<TEntity>>.Create(
                    data: entities,
                    message: "Entities retrieved successfully.",
                    errorCode: (int?)HttpStatusCode.OK
                );
            }
            catch (Exception ex)
            {
                return ServiceResponse<IEnumerable<TEntity>>.Create(
                    message: "Failed to retrieve entities.",
                    errorCode: (int?)HttpStatusCode.BadRequest,
                    exception: ex
                );
            }
        }

        public async Task<ServiceResponse<TEntity>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FindAsync(id);
                if (entity == null)
                {
                    return ServiceResponse<TEntity>.Create(
                        message: "Entity not found.",
                        errorCode: (int?)HttpStatusCode.NotFound
                    );
                }

                return ServiceResponse<TEntity>.Create(
                    data: entity,
                    message: "Entity retrieved successfully.",
                    errorCode: (int?)HttpStatusCode.OK
                );
            }
            catch (Exception ex)
            {
                return ServiceResponse<TEntity>.Create(
                    message: "Failed to retrieve entity.",
                    errorCode: (int?)HttpStatusCode.BadRequest,
                    exception: ex
                );
            }
        }

        public async Task<ServiceResponse<string>> AddAsync(TViewModel viewModel)
        {
            try
            {
                var entity = _mapToEntity(viewModel);
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();

                return ServiceResponse<string>.Create(
                    message: "Entity added successfully.",
                    errorCode: (int?)HttpStatusCode.Created
                );
            }
            catch (Exception ex)
            {
                return ServiceResponse<string>.Create(
                    message: "Failed to add entity.",
                    errorCode: (int?)HttpStatusCode.BadRequest,
                    exception: ex
                );
            }
        }

        public async Task<ServiceResponse<string>> UpdateAsync(TViewModel viewModel)
        {
            try
            {
                var entity = _mapToEntity(viewModel);
                _context.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return ServiceResponse<string>.Create(
                    message: "Entity updated successfully.",
                    errorCode: (int?)HttpStatusCode.OK
                );
            }
            catch (Exception ex)
            {
                return ServiceResponse<string>.Create(
                    message: "Failed to update entity.",
                    errorCode: (int?)HttpStatusCode.BadRequest,
                    exception: ex
                );
            }
        }

        public async Task<ServiceResponse<string>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FindAsync(id);
                if (entity == null)
                {
                    return ServiceResponse<string>.Create(
                        message: "Entity not found.",
                        errorCode: (int?)HttpStatusCode.NotFound
                    );
                }

                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();

                return ServiceResponse<string>.Create(
                    message: "Entity deleted successfully.",
                    errorCode: (int?)HttpStatusCode.OK
                );
            }
            catch (Exception ex)
            {
                return ServiceResponse<string>.Create(
                    message: "Failed to delete entity.",
                    errorCode: (int?)HttpStatusCode.BadRequest,
                    exception: ex
                );
            }
        }
    }


}
