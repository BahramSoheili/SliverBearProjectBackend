using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Aggregates;
using Core.Events;
using Core.Storage;
using Marten;

namespace SilverBearDomain.Storage
{
    public class MartenRepository<T> : IRepository<T> where T : class, IAggregate, new()
    {
        private readonly IDocumentSession documentSession;
        public MartenRepository(IDocumentSession documentSession)
        {
            this.documentSession = documentSession ?? throw new ArgumentNullException(nameof(documentSession));
        }

        public Task<T> FindById(Guid id, CancellationToken cancellationToken)
        {
            var res =  documentSession.Events.AggregateStreamAsync<T>(id);
            return res;
        }
        public Task Add(T aggregate, CancellationToken cancellationToken)
        {
            documentSession.Events.StartStream<T>(aggregate.Id);
            return Store(aggregate, cancellationToken);
        }
        public Task Update(T aggregate, CancellationToken cancellationToken)
        {
            return Store(aggregate, cancellationToken);
        }
        public Task Delete(T aggregate, CancellationToken cancellationToken)
        {
            return Store(aggregate, cancellationToken);
        }
        private async Task Store(T aggregate, CancellationToken cancellationToken)
        {
            try
            {                
                await documentSession.SaveChangesAsync();
            }
            catch (Exception e)
            {
            }
           
        }
        public Task<T> Authenticate(string username, string password, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            var res = documentSession.Query<T>().ToArray().ToList();
            return Task.FromResult(res);
        }

        //public Task<T> Search(Guid filter, CancellationToken cancellationToken)
        //{
        //    var res = documentSession.Events.AggregateStreamAsync<T>(filter);
        //    return res;
        //}
        public async Task SearchAll(string filter, CancellationToken cancellationToken)
        {
            var res = documentSession.Events.FetchStream(filter);
        }
        public Task<T> Search(string filter, CancellationToken cancellationToken)
        {
            var res = documentSession.Events.AggregateStreamAsync<T>(filter);
            return res;
        }

        public Task<T> LockerByRowCol(Guid wallId, string row, string col, CancellationToken cancellationToken) 
        {
            var res = documentSession.Query<T>("where data ->> 'Data.wallId' = 'wallId' && 'Data.rowNumber' = 'row' && 'Data.columnNumber' = 'col'").FirstOrDefault();
            return Task.FromResult(res);
        }
    }
}
