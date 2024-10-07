public interface IState
{
// start executing state
    void Enter();
// update in state
    void Tick();
//fixed Update in state
    void FixedTick();
// exiting current sate
    void Exit();
}