using ApiBasic.Dtos.Order;

namespace ApiBasic.Services.Interfaces
{
    public interface IOrderServices
    {
        void Create(CreateOrderDto input);

        void GetAll();

        void Update(UpdateOrderDto input);

        void Delete(int IdOrder);
    }
} 
