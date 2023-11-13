using Domain.Model;

namespace Domain.Abstractions;

public interface IMessageService
{
    void Send(Message message);
}
