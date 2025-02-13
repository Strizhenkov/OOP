using Itmo.ObjectOrientedProgramming.Lab3.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.TopicEntities;

public interface ITopic
{
    void SentMessage(Message message);
}