using System;


namespace Shed
{
    public interface IShedController
    {
        void Enter(Action callback);
        void Exit();
    }
}
