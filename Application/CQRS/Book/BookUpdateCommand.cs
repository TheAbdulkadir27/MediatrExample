using Application.CQRS.Book.Dto;
using AutoMapper;
using Domain.Common;
using Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Book
{
    public class BookUpdateCommand : IRequest<Books>
    {
        public BookDto BookDto { get; set; }
        public class BookUpdateCommandHandler : IRequestHandler<BookUpdateCommand, Books>
        {
            private readonly IMapper mapper;
            private readonly IUnitOfWork unitOfWork;
            public BookUpdateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                this.mapper = mapper;
                this.unitOfWork = unitOfWork;
            }
            public Task<Books> Handle(BookUpdateCommand request, CancellationToken cancellationToken)
            {
                var books = mapper.Map<Books>(request.BookDto);
                var value = unitOfWork.GetBookService().BookUpdate(unitOfWork.GetBookService().BookGetById(books.Id));
                unitOfWork.Commit();
                return Task.FromResult(value);
            }
        }
    }
}
