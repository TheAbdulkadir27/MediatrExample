using Application.CQRS.Book.Dto;
using AutoMapper;
using Domain.Common;
using Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Book
{
    public class BookCreateCommand : IRequest<Books>
    {
        public BookDto Books { get; set; }
        public class BookCreateCommandHandler : IRequestHandler<BookCreateCommand, Books>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IMapper mapper;
            public BookCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                this.unitOfWork = unitOfWork;
                this.mapper = mapper;
            }
            public async Task<Books> Handle(BookCreateCommand request, CancellationToken cancellationToken)
            {
                var books = mapper.Map<Books>(request.Books);
                var value = unitOfWork.GetBookService().BookAdd(books);
                unitOfWork.Commit();
                return await Task.FromResult(value);
            }
        }
    }
}
