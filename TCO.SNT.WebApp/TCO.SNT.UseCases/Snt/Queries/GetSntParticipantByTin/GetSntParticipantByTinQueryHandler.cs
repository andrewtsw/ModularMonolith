using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.UseCases.Snt.Shared;

namespace TCO.SNT.UseCases.Snt.Queries.GetSntParticipantByTin
{
    internal class GetSntParticipantByTinQueryHandler : IRequestHandler<GetSntParticipantByTinQuery, SntParticipantDto>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetSntParticipantByTinQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SntParticipantDto> Handle(GetSntParticipantByTinQuery request, CancellationToken cancellationToken)
        {
            var customerInfo = await _context.SntCustomers
                .Where(x => x.Tin == request.Tin && x.NonResident == false)
                .Join(_context.SntInfos, customer => customer.SntId, info => info.SntId, 
                    (customer, sntInfo) => new { Customer = customer, sntInfo.LastUpdateDateUtc })
                .OrderByDescending(x => x.LastUpdateDateUtc)
                .FirstOrDefaultAsync(cancellationToken);

            var sellerInfo = await _context.SntSellers
                .Where(x => x.Tin == request.Tin && x.NonResident == false)
                .Join(_context.SntInfos, seller => seller.SntId, info => info.SntId,
                    (seller, sntInfo) => new { Seller = seller, sntInfo.LastUpdateDateUtc })
                .OrderByDescending(x => x.LastUpdateDateUtc)
                .FirstOrDefaultAsync(cancellationToken);

            if (customerInfo == null && sellerInfo == null)
                return null;

            if (customerInfo == null)
                return _mapper.Map<SntParticipantDto>(sellerInfo.Seller);

            if (sellerInfo == null)
                return _mapper.Map<SntParticipantDto>(customerInfo.Customer);

            return customerInfo.LastUpdateDateUtc > sellerInfo.LastUpdateDateUtc 
                ? _mapper.Map<SntParticipantDto>(customerInfo.Customer)
                : _mapper.Map<SntParticipantDto>(sellerInfo.Seller);
        }
    }
}
