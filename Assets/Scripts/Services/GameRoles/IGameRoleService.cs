namespace Services.GameRoles
{
    public interface IGameRoleService
    {
        void InitializeSession(int playerNum);
        bool TryGetGameRole(out EGameRole role);
    }
}