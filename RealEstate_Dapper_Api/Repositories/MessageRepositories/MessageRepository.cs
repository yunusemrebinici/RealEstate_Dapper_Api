using Dapper;
using RealEstate_Dapper_Api.Dtos.MessageDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.MessageRepositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;
        public MessageRepository(Context context)
        {
              _context = context;
        }

        public async Task<List<ResultInBoxMessageDto>> GetInBoxLast3MessageListByReceiver(int id)
        {

            string query = "select top(3) MessageId ,Name,Subject,Detail,SendDate,IsRead,UserImageUrl from Message inner join AppUser ON Message.Sender=AppUser.UserId where Receiver=@receiverId order by MessageId desc\r\n";
            var paramaters = new DynamicParameters();
            paramaters.Add("@receiverId", id);
            using (var connection = _context.CrateConnection())
            {
                var values = await connection.QueryAsync<ResultInBoxMessageDto>(query, paramaters);
                return values.ToList();
            }
        }
    }
}
